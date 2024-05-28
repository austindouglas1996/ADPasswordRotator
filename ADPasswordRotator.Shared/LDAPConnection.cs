using ADPasswordRotator.Shared.Model;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net.Mime;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Shared
{
    /// <summary>
    /// Helps with our connection into a server with LDAP. 
    /// </summary>
    public class LDAPConnection(string HostName, string port, string username, string password)
    {
        private bool _ConnectCalled = false;

        public string HostName { get; private set; } = HostName;
        public string Port { get; private set; } = port;
        public string Username { get; private set; } = username;
        private string Password { get; set; } = password;

        public async Task<bool> TryConnectAsync()
        {
            using (TcpClient tcp = new TcpClient())
            {
                try
                {
                    await tcp.ConnectAsync(HostName, int.Parse(Port));
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Port is not open or cannot be seen. Message: {ex.Message}");
                }
            }

            try
            {
                ValidateCredentials(Username, Password);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Failed to validate credentials. Message: {ex.Message}");
            }

            return true;
        }

        public async Task ConnectAsync()
        {
            _ConnectCalled = await TryConnectAsync();
        }

        public bool ValidateCredentials(string username, string password)
        {
            try
            {
                using (PrincipalContext context = CreateContext())
                {
                    return context.ValidateCredentials(username, password);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to validate credentials against the LDAP server.", ex);
            }
        }

        public UserPrincipal GetUser(string username)
        {
            if (!_ConnectCalled)
            {
                throw new InvalidOperationException("A connection must be created first.");
            }

            PrincipalContext context = CreateContext();
            return UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username);
        }

        public bool RemoveUser(string username)
        {
            if (!_ConnectCalled)
            {
                throw new InvalidOperationException("A connection must be created first.");
            }

            using (PrincipalContext context = CreateContext())
            {
                using (var foundUser = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, username))
                {
                    foundUser.Delete();
                    return true;
                }
            }

            return false;
        }

        public List<UserPrincipal> GetUsers()
        {
            if (!_ConnectCalled)
            {
                throw new InvalidOperationException("A connection must be created first.");
            }

            List<UserPrincipal> users = new List<UserPrincipal>();

            using (PrincipalContext context = CreateContext())
            using (PrincipalSearcher searcher = new PrincipalSearcher(new UserPrincipal(context)))
            {
                try
                {
                    foreach (var result in searcher.FindAll())
                    {
                        if (result is UserPrincipal user)
                        {
                            users.Add(user);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("An error occurred while searching for users.", ex);
                }
            }

            return users;
        }

        public bool ChangeUserPassword(string username, string oldPassword, string newPassword)
        {
            if (!_ConnectCalled)
            {
                throw new InvalidOperationException("Connect must be called.");
            }

            try
            {
                // Verify user exists.
                if (GetUser(username) == null)
                {
                    throw new ArgumentException(string.Format("Cannot find a user by the name '{0}'.", username));
                }

                // We use a different route to change the password.
                using (PrincipalContext context = CreateContext())
                {
                    UserPrincipal user = GetUser(username);
                    user.ChangePassword(oldPassword, newPassword);
                    user.Save();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong while resetting a password. {ex.Message}");
            }

            return true;
        }

        public bool ChangeUserPassword(ServiceAccount account, string oldPassword, string newPassword, bool force = false)
        {
            return ChangeUserPassword(account.UserName, oldPassword, AESEncrypt.GeneratePassword(10, 10));
        }


        public PrincipalContext CreateContext()
        {
            PrincipalContext context = new PrincipalContext(ContextType.Domain, HostName, Username, Password);

            // This will throw an exception if wrong.
            context.ValidateCredentials(Username, Password);

            return context;
        }

        private PrincipalContext _context= null;
    }
}
