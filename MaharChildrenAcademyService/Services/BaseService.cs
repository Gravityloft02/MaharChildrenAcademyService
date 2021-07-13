using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MaharChildrenAcademyService.Helper;

namespace MaharChildrenAcademyService.Services
{
    public class BaseService
    {
        protected HttpContent GetRequestContent(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            //var json = Encrypt(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return content;
        }

        protected async Task<string> GetResult(HttpResponseMessage response, bool isEncrypted)
        {
            var stringResult = await response.Content.ReadAsStringAsync();
            string decryptedResult = stringResult;

            if (isEncrypted)
            {
                decryptedResult = Decrypt(stringResult);
            }
            return decryptedResult;
        }

        async Task<T> GetResult<T>(HttpResponseMessage response, bool isEncrypted)
        {
            var stringResult = await response.Content.ReadAsStringAsync();
            string decryptedResult = stringResult;

            if (isEncrypted)
            {
                decryptedResult = Decrypt(stringResult);
            }

            var result = await Task.Run(() => JsonConvert.DeserializeObject<T>(decryptedResult));
            return result;
        }

        async Task<T> GetResult<T>(HttpResponseMessage response)
        {
            var result = await GetResult<T>(response, false);
            return result;
        }

        #region Encryption & Decryption

        /// <summary>
        /// AES Encryption
        /// </summary>
        /// <param name="value">string value to encrypt</param>
        /// <param name="key">Key to encrypt</param>
        /// <param name="IV">IV to encrypt</param>
        /// <returns></returns>
        byte[] StringToBytes(string value, byte[] Key, byte[] IV)
        {
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Padding = PaddingMode.PKCS7;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(value);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// Get String from Byte[]
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        string StringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                aesAlg.Padding = PaddingMode.PKCS7;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        byte[] GetByteArray(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        string Encrypt(object valueToEncrypt, string key)
        {
            try
            {
                var keybytes = Encoding.ASCII.GetBytes(key);
                var iv = Encoding.ASCII.GetBytes(key);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };

                var jsonString = JsonConvert.SerializeObject(valueToEncrypt, settings);

                var encrypted = StringToBytes(jsonString, keybytes, iv);

                return Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        string Encrypt(object valueToEncrypt)
        {
            return Encrypt(valueToEncrypt, Global.APPLICATION_KEY);
        }

        string Decrypt(string encryptedValue, string key)
        {
            string decryptedValue = encryptedValue;
            try
            {
                var keybytes = Encoding.ASCII.GetBytes(key);
                var iv = Encoding.ASCII.GetBytes(key);
                try
                {
                    decryptedValue = JsonConvert.DeserializeObject<string>(encryptedValue);
                }
                catch (Exception ex)
                { }
                var base64String = Convert.FromBase64String(decryptedValue);

                return StringFromBytes(base64String, keybytes, iv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        string Decrypt(string encryptedValue)
        {
            return Decrypt(encryptedValue, Global.APPLICATION_KEY);
        }

        #endregion
    }
}
