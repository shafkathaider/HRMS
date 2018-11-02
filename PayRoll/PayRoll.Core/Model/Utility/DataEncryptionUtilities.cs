using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PayRoll.Core.Model.Utility
{
    public class DataEncryptionUtilities
    {
        public string GenerateEncryptedString(string valueToEncrypt, string clientName)
        {
            var uTf8Encoding = new UTF8Encoding();
            var rijndaelManaged = new RijndaelManaged();
            var bytes = Encoding.ASCII.GetBytes(clientName);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes("19 15 21 20 08", bytes);
            rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
            rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
            var transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            var bytes2 = uTf8Encoding.GetBytes(valueToEncrypt);
            cryptoStream.Write(bytes2, 0, bytes2.Length);
            cryptoStream.FlushFinalBlock();
            var inArray = memoryStream.ToArray();
            return Convert.ToBase64String(inArray);
        }

        public string GenerateDecryptedString(string valueToDecrypt, string clientName)
        {
            var buffer = Convert.FromBase64String(valueToDecrypt);
            var rijndaelManaged = new RijndaelManaged();
            var bytes = Encoding.ASCII.GetBytes(clientName);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes("19 15 21 20 08", bytes);
            rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
            rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
            var transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
            var stream = new MemoryStream(buffer);
            var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            var streamReader = new StreamReader(stream2);
            return streamReader.ReadLine();
        }

        public string GenerateSqlServerLoginPass(string valueToEncrypt, string clientName)
        {
            var uTf8Encoding = new UTF8Encoding();
            var rijndaelManaged = new RijndaelManaged();
            var bytes = Encoding.ASCII.GetBytes(clientName);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes("20 05 03 08", bytes);
            rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
            rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
            var transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
            var bytes2 = uTf8Encoding.GetBytes(valueToEncrypt);
            cryptoStream.Write(bytes2, 0, bytes2.Length);
            cryptoStream.FlushFinalBlock();
            var inArray = memoryStream.ToArray();
            return Convert.ToBase64String(inArray);
        }
    }
}
