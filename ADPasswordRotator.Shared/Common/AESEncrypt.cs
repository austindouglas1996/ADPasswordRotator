using System.Security.Cryptography;
using System.Text;

namespace ADPasswordRotator.Shared
{
    /// <summary>
    /// Helps with dealing with encryption and decryption of strings.
    /// </summary>
    public class AESEncrypt
    {
        static List<char> alphabetList = new List<char>
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3','4','5','6','7','8','9'
        };

        static List<char> symbolList = new List<char>
        {
            '!','@','#','$','%','&','*'
        };

        static List<string> emotions = new List<string>
        {
            "Envious",
            "Amused",
            "Disappointed",
            "Frusturated",
            "Guilty",
            "Disgusted",
            "InSecure",
            "Satisified",
            "Resentful",
            "Betrayed",
            "Happy",
            "Mad",
            "Sad",
            "Scared",
            "Restless",
            "Shy",
            "Nervous",
            "Bored",
            "Stressed",
            "Proud",
            "Excited",
            "Lonely",
            "Jealous",
            "Curious",
            "Confused",
            "Ashamed",
            "Relaxed",
            "Playful",
            "Concerned",
            "Useless",
            "Worried",
            "Helpless",
            "Grateful",
            "Numb",
            "Surprised",
            "Anxious",
            "Loving",
            "Humilated",
            "Rejected",
            "Greedy",
            "Neglected",
            "Hopeless",
            "Awkward",
            "Exhausted",
            "Confident",
            "Shocked",
            "Annoyed",
            "Safe",
            "Calm",
            "Impatient",
            "Sily",
            "Tense",
            "Peaceful",
            "Grumpy",
            "Distant",
            "Moody",
            "Hyper",
            "Furious",
            "Stubborn",
            "Hopeful",
            "Overwhelmed",
            "Motivated",
            "Insane",
            "Crazy",
            "Premeditated"
        };

        static List<string> objects = new List<string>
        {
            "Telescope",
            "Microscope",
            "Backpack",
            "Guitar",
            "Piano",
            "Violin",
            "Microphone",
            "Camera",
            "Bicycle",
            "Tablet",
            "Laptop",
            "Tree",
            "River",
            "Glacier",
            "Rainbow",
            "Tornado",
            "Hurricane",
            "Thunderstorm",
            "Ocean",
            "Mars",
            "Earth",
            "Jupiter",
            "ClownNose",
            "PetRock",
            "Car",
            "Truck",
            "Helicopter",
            "Dinosaur",
            "Computer",
            "Book",
            "Chair",
            "Table",
            "Backpack",
            "Window",
            "Toaster",
            "Refridgerator",
            "WashingMachine",
            "Basketball",
            "Plant",
            "Painting",
            "JohnFKennedy",
            "Mirror",
            "Wallet",
            "Suitcase",
            "Forklift",
            "Taxi",
            "TugBoat",
            "SpaceCraft",
            "Train",
            "Submarine",
            "Locomotive",
            "Notebook",
            "Battery",
            "Mouse",
            "Kitty",
            "Putty",
            "Identification",
            "Thompson",
            "Ryan",
            "Austin",
            "Toilet",
            "Blender",
            "Hummer",
            "Shark",
            "Bird",
            "Giraffe",
            "Rhino",
            "Hamster",
            "Phone",
            "Germany",
            "Mexico",
            "Africa",
            "Inflatable",
            "Water",
            "Lava",
            "Zombie",
            "Chicken",
            "Cloud",
            "Moon",
            "Specialist",
            "Pills",
            "Python",
            "CocaCola",
            "Pepsi",
            "Manager",
            "Historian",
            "NoahsBoat",
            "Salmon",
            "CanOpener",
            "OvenMitt",
            "Pillow",
            "Trash",
            "Trailer",
            "Soda",
            "Water",
            "Sand",
            "Thermite",
            "Radiation",
            "Carbon",
            "Granular",
            "Gradient",
            "Hypertherm",
            "Cervasa",
            "Sight"
        };

        /// <summary>
        /// Generate a random password based on a small critera.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="numOfSymbols"></param>
        /// <returns></returns>
        public static string GeneratePassword(int length, int numOfSymbols)
        {
            Random rand = new Random();
            string generatedPassword = "";

            // Generate random digits.
            for (int i = 0; i < length; i++)
            {
                generatedPassword += alphabetList[rand.Next(0, alphabetList.Count() - 1)];
            }

            // Generate random symbols and place randomly.
            for (int i = 0; i < numOfSymbols; i++)
            {
                string symbol = symbolList[rand.Next(0, symbolList.Count() - 1)].ToString();
                generatedPassword = generatedPassword.Insert(rand.Next(0, generatedPassword.Length - 1), symbol);
            }

            return generatedPassword;
        }

        /// <summary>
        /// Generate a dumb but fun password!
        /// </summary>
        /// <returns></returns>
        public static string GenerateDumbPassword()
        {
            Random rand = new Random();
            string emotion = emotions[rand.Next(0, emotions.Count() - 1)].ToString();
            string obj = objects[rand.Next(0, objects.Count() - 1)].ToString();
            string symbol = symbolList[rand.Next(0, symbolList.Count())].ToString();
            string number = rand.Next(10, 99).ToString();

            return emotion + obj + symbol + number;
        }

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        /// <summary>
        /// Decrypt a string.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Hash and salt a string.
        /// </summary>
        /// <param name="plaintextpassword"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string Hash(string plaintextpassword, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(32);
            var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(plaintextpassword), salt, 350000, HashAlgorithmName.SHA512, 32);
            return Convert.ToHexString(hash);
        }

        /// <summary>
        /// Verify a plaintext string with a hash and salt.
        /// </summary>
        /// <param name="plaintextpassword"></param>
        /// <param name="hash"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public bool VerifyHash(string plaintextpassword, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(plaintextpassword, salt, 350000, HashAlgorithmName.SHA512, 32);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
