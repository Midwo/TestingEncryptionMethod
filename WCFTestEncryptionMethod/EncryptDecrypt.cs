using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WCFTestEncryptionMethod
{
    public class EncryptDecrypt
    {

        public byte[] RsaEncryptByte(string content)
        {
            var publicKey =
                "<RSAKeyValue><Modulus>wv2+A8oH4yVJ4ZBaeOqM0X1CUOgMPIcFkrbrTCDgsMEYCYO9asamOWlLUCJptp1xKZahtDn7iZa5MwqVFUm5MJKl3bMnyvkUSBUWz8qzvbYbpwy3KZlKxK+crMcUhm5G7SNsMkaB2mxe05fW1Q4kfhbflBM9qXicRLggcWL92PU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";


            var testData = Encoding.UTF8.GetBytes(content);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {

                try
                {


                    // client encrypting data with public key issued by server
                    //

                    rsa.FromXmlString(publicKey);

                    byte[] encryptedData = rsa.Encrypt(testData, true);

                    // var base64Encrypted = Convert.ToBase64String(encryptedData);
                    //MessageBox.Show(base64Encrypted);

                    // server decrypting data with private key
                    //



                    return encryptedData;

                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }
        }

        public byte[] RsaDectryptByte(byte[] RsaEncryptByte)
        {

            var privateKey =
              "<RSAKeyValue><Modulus>wv2+A8oH4yVJ4ZBaeOqM0X1CUOgMPIcFkrbrTCDgsMEYCYO9asamOWlLUCJptp1xKZahtDn7iZa5MwqVFUm5MJKl3bMnyvkUSBUWz8qzvbYbpwy3KZlKxK+crMcUhm5G7SNsMkaB2mxe05fW1Q4kfhbflBM9qXicRLggcWL92PU=</Modulus><Exponent>AQAB</Exponent><P>xTtjhnfGdoEvnOvL/2srpVOw9UqapDmlfA/AM688KnhuQndTTB4lal2DsaLsQ9rvJbjEPotqG2smT48SO0LKAw==</P><Q>/Rdtccp3VpWhIfXaVHZswcesDbF1qEm2ediVGI3JSZDkUYtid0uPpPE4HJeXJIuRFJORM3p+g26nPr3crN9bpw==</Q><DP>VgaeVWNevAeC5fXvJ3vuMJE9aO/eXW0LYf5YvfJb0sZuiS0UtumbNjaNn2hJlxsiHhjl98XFRSpKLn9f21s5Uw==</DP><DQ>cbr3WW0MF4KBuAsMo2vcD3A0pqqaHpeRQkvLJA+C5mYP03z5MHZqBErJVj/gkXGOLlrpouJmu5Ub3pve8GgmfQ==</DQ><InverseQ>YLFKqHn37A61BAtIjaiol5TJy0cBDWufrpgPsuZRRUzAZfMnkb9eZ+zS4KF67MT610IMQebeEYc4atDhizH6lQ==</InverseQ><D>sqv3tVkmqQi+DiZMAIhLyJnSbnhy3fOLM8jRCs0FlnEZKX7BzlmAbxMAo8kkvOS/kLAqNA79YjHuOcr0mLEZMsBJmVyYgydP9k3UIM5z+SPOzAjmnGQyRNAFZDN3zQN/92R58FHfij0gRevDhT0uPrQjaDwp7libTL3Sxbj2H/E=</D></RSAKeyValue>";



            using (var rsa = new RSACryptoServiceProvider(1024))
            {

                try
                {



                    rsa.FromXmlString(privateKey);

                    var decryptedBytes = rsa.Decrypt(RsaEncryptByte, true);
                   // var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    //MessageBox.Show(decryptedData);

                    return decryptedBytes;

                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }
        }

        public string GetMd5Hash(string content)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = CreateMd5Hash(md5Hash, content);

                return hash;
            }

        }

        private string CreateMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public byte[] AesEncryptByte(string content)
        {
            string original = content;

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization 
            // vector (IV).

            byte[] key = Convert.FromBase64String("BYe8YwuIn2aaa3FPWTZFlAa14EjdPAdN9FaZ9RQWihc=");
            byte[] IV = Convert.FromBase64String("bsxnWolsAyO7kCfWuyrnq1==");


            // Encrypt the string to an array of bytes.
            byte[] encrypted = EncryptStringToBytes_Aes(original, key, IV);


            // Decrypt the bytes to a string.
            //   string roundtrip = DecryptStringFromBytes_Aes(encrypted, key, IV);


            return encrypted;


            //    MessageBox.Show("" + resultx + "");

            //Display the original data and the decrypted data.
            //  MessageBox.Show("" + original + "");
            //    MessageBox.Show("" + roundtrip + "");

        }

        public string AesDecryptString(byte [] aesEncryptByte)
        {


            // Create a new instance of the Aes
            // class.  This generates a new key and initialization 
            // vector (IV).

            byte[] key = Convert.FromBase64String("BYe8YwuIn2aaa3FPWTZFlAa14EjdPAdN9FaZ9RQWihc=");
            byte[] IV = Convert.FromBase64String("bsxnWolsAyO7kCfWuyrnq1==");



            // Decrypt the bytes to a string.
            string roundtrip = DecryptStringFromBytes_Aes(aesEncryptByte, key, IV);


            return roundtrip;


            //    MessageBox.Show("" + resultx + "");

            //Display the original data and the decrypted data.
            //  MessageBox.Show("" + original + "");
            //    MessageBox.Show("" + roundtrip + "");

        }

        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // check arguments.

            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                // MessageBox.Show("" + System.Text.Encoding.UTF8.GetString(aesAlg.Key) + "");
                //  MessageBox.Show("" + System.Text.Encoding.UTF8.GetString(aesAlg.IV) + "");
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

                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();

                    }
                }
            }

            // Return the encrypted bytes from the memory stream.

            return encrypted;
        }

        private string DecryptStringFromBytes_Aes(byte[] encryptText, byte[] Key, byte[] IV)
        {
            // check arguments.
            if (encryptText == null || encryptText.Length <= 0)
                throw new ArgumentNullException("encryptText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(encryptText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting  stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        public string Rc4EncryptString(string content)
        {
            string key = "+A8oH4yVJ4ZBaeOqM0X1CUOgMPIcFkrbrTCDgsMEYCYO9asamOWlLUCJptp1xKZahtDn7iZa5MwqVFUm";
            string cypheredText = RC4(content, key);

            return cypheredText;
        }

        public string Rc4DecryptString(string encriptString)
        {
            string key = "+A8oH4yVJ4ZBaeOqM0X1CUOgMPIcFkrbrTCDgsMEYCYO9asamOWlLUCJptp1xKZahtDn7iZa5MwqVFUm";
            string deCypheredText = RC4(encriptString, key);
            return deCypheredText;
        }

        private string RC4(string input, string key)
        {
            StringBuilder result = new StringBuilder();
            int x, y, j = 0;
            int[] box = new int[256];

            for (int i = 0; i < 256; i++)
            {
                box[i] = i;
            }

            for (int i = 0; i < 256; i++)
            {
                j = (key[i % key.Length] + box[i] + j) % 256;
                x = box[i];
                box[i] = box[j];
                box[j] = x;
            }

            for (int i = 0; i < input.Length; i++)
            {
                y = i % 256;
                j = (box[y] + j) % 256;
                x = box[y];
                box[y] = box[j];
                box[j] = x;

                result.Append((char)(input[i] ^ box[(box[y] + box[j]) % 256]));
            }
            return result.ToString();
        }

    }
}
