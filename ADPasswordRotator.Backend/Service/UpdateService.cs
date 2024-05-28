using ADPasswordRotator.Shared;
using ADPasswordRotator.Shared.Common;
using ADPasswordRotator.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ADPasswordRotator.Backend.Service
{
    public class UpdateService(ADWorker worker)
    {
        private ADWorker worker = worker;

        /// <summary>
        /// Perform a heart beat check for each <see cref="DomainController"/>. Updating their status if a change is seen.
        /// </summary>
        /// <returns></returns>
        public async Task PerformHeartBeat()
        {
            var DCs = await worker.DomainControllers.GetAllAsync();
            foreach (var dc in DCs)
            {
                bool result = false;

                try
                {
                    LDAPConnection connection = new LDAPConnection(dc.HostName, dc.Port.ToString(), dc.UserName, dc.Password);
                    result = await connection.TryConnectAsync();

                    // Check back in service accounts.
                    if (result && dc.Status != ConnectionStatus.Connected)
                    {
                        foreach (ServiceAccount sa in dc.Location.Accounts)
                        {
                            var user = connection.GetUser(sa.UserName);
                            if (user == null && sa.Status != AccountStatus.Missing)
                            {
                                await ChangeUserStatus(sa, AccountStatus.Missing);
                            }
                            else if (user != null & sa.Status == AccountStatus.Missing)
                            {
                                // We set 'exists' here so on the next update cycle we can move back into
                                // the controlled group. If an account goes missing, but comes back
                                // we want to reset the password in case it was compromised.
                                await ChangeUserStatus(sa, AccountStatus.Exists);
                            }
                            else if (user != null & sa.Status == AccountStatus.Exists)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("***ADD ACCOUNT CONTROL IN UPDATE SERVICE.***");
                                Console.WriteLine("***ADD ACCOUNT CONTROL IN UPDATE SERVICE.***");
                                Console.WriteLine("***ADD ACCOUNT CONTROL IN UPDATE SERVICE.***");
                                Console.WriteLine("***ADD ACCOUNT CONTROL IN UPDATE SERVICE.***");
                                Console.ForegroundColor = ConsoleColor.White;

                                await ChangeUserStatus(sa, AccountStatus.Controlled);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // TODO: System logs.
                }

                if (result && dc.Status != Shared.ConnectionStatus.Connected)
                {
                    await ChangeConnectionStatus(dc, true);
                }
                else if (!result && dc.Status != Shared.ConnectionStatus.Disconnected)
                {
                    await ChangeConnectionStatus(dc, false);
                }
            }
        }

        /// <summary>
        /// Change the status of a <see cref="DomainController"/>. Create a new notification too.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        private async Task ChangeConnectionStatus(DomainController dc, bool newStatus)
        {
            Notification newNotification = new Notification();
            newNotification.DomainControllerId = dc.Id;

            if (newStatus)
            {
                dc.Status = ConnectionStatus.Connected;
                newNotification.Message = $"{dc.DisplayName} has been connected. Controller online.";
            }
            else
            {
                dc.Status = ConnectionStatus.Disconnected;
                newNotification.Message = $"{dc.DisplayName} has been disconnected. Controller offline.";
            }

            worker.DomainControllers.UpdateAsync(dc);
            await worker.Notifications.AddAsync(newNotification);
            await worker.SaveChanges();
        }

        /// <summary>
        /// Change the status of a <see cref="ServiceAccount"/>.
        /// </summary>
        /// <param name="sa"></param>
        /// <param name="newStatus"></param>
        /// <returns></returns>
        private async Task ChangeUserStatus(ServiceAccount sa, AccountStatus newStatus)
        {
            // Update status.
            sa.Status = newStatus;

            Notification newNotification = new Notification();
            newNotification.ServiceAccountId = sa.Id;

            if (newStatus == AccountStatus.Missing && sa.Status != AccountStatus.Missing)
            {
                newNotification.Message = $"{sa.UserName} cannot be found in the domain. Account is missing.";
            }
            else if (newStatus == AccountStatus.Exists && sa.Status != AccountStatus.Missing)
            {
                newNotification.Message = $"{sa.UserName} was missing but has been found in the domain. Updated to exists.";
            }
            else if (newStatus == AccountStatus.Controlled && sa.Status != AccountStatus.Exists)
            {
                newNotification.Message = $"{sa.UserName} status has been updated to controlled. Account is now system managed.";
            }

            worker.ServiceAccounts.UpdateAsync(sa);
            await worker.Notifications.AddAsync(newNotification);
            await worker.SaveChanges();
        }
    }
}
