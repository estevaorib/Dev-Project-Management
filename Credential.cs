using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDesenvolvedoresEProjetos
{
    [Table("Credential")]
    public class Credential
    {
        public const String SALT = "1FN&49mI0Pd";

        public Int32 Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(250)]
        public String Email { get; set; }

        public String _password;

        [Required]
        [StringLength(64)]
        public String Password
        {
            get { return _password; }
            set { _password = ComputeSHA256(value, SALT); }
        }

        public Boolean Active { get; set; }

        public Boolean Administrator { get; set; }

        public Developer Developer { get; set; }

        public Credential(string email, string password, bool active, bool administrator)
        {
            Email = email;
            Password = password;
            Active = active;
            Administrator = administrator;
        }

        public Credential()
        {

        }

        #region Hashing
        public static String ComputeSHA256(String input)
        {
            return ComputeSHA256(input, null);
        }

        public static String ComputeSHA256(String input, String salt)
        {
            String hash = String.Empty;

            // 
            // https://learn.microsoft.com/en-us/dotnet/standard/security/cryptographic-services
            // https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.sha256?view=netframework-4.8
            // https://www.techiedelight.com/generate-sha-256-hash-of-string-csharp/
            // 

            // Initialize a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(salt + input));

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }
        #endregion
    }
}
