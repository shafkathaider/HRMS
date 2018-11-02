using System;
using System.Security.Cryptography;
using System.Text;

namespace PayRoll.Core.Model.Utility
{
    public class DataHashUtilities
    {
        public static string HashPassword(string password)
        {

            var randomSalt = GetRandomSalt();
            var toHash = randomSalt + password;
            var str = Sha256Hex(toHash);
            return randomSalt + str;
        }

        public static Boolean ValidatePassword(string password, string correctHash)
        {

            if (correctHash.Length < 128)
                throw new Exception("Correct hash must be 128 hex characters!");

            var str = correctHash.Substring(0, 64);
            var strA = correctHash.Substring(64, 64);
            var strB = Sha256Hex(str + password);
            return String.CompareOrdinal(strA, strB) == 0 ? true : false;
        }

        private static string GetRandomSalt()
        {
            var rNgCryptoServiceProvider = new RNGCryptoServiceProvider();
            var array = new byte[32];
            rNgCryptoServiceProvider.GetBytes(array);
            return BytesToHex(array);
        }

        private static string BytesToHex(byte[] toConvert)
        {
            var stringBuilder = new StringBuilder(toConvert.Length * 2);

            foreach (var data in toConvert)
            {
                stringBuilder.Append(data.ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        private static string Sha256Hex(string toHash)
        {
            var sHa256Managed = new SHA256Managed();
            var bytes = Encoding.UTF8.GetBytes(toHash);
            return BytesToHex(sHa256Managed.ComputeHash(bytes));
        }
    }
}
