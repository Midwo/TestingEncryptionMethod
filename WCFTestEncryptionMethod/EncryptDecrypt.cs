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
          "<RSAKeyValue><Modulus>rxTOhmM+OOk0Ew+uLHBCh0IpZN2Xq9vAzy8leFcDyYE7Nyx2KI/AY4iJPcBdBVphA4SS6aPcTgc1x7+jg2pDcICGFpjdOoAtX7OQJ8hEghSlXo9GIoJKqvZ8VIXOqOLIq7S0bVbS7/laQ8ez7TcNk/7d2QIksDObbIiS6jCjS+er3mWjwtCZzfHHvSZz7yZNmJd/fOaSvARHPC6F3Ei/2JiJ0ZW+uF/bXTMupy/xWJDL8ttehCH0N9gnsBLe31Rmhl7pbRhmY0paDIAoEoOkAUsTLgC5VD3/Ymg2UyVGvV6K+VWBobhXMajrz5zqmAjrl9PcR9DgApf4mu2DtkM5JQ==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";


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
                      "<RSAKeyValue><Modulus>rxTOhmM+OOk0Ew+uLHBCh0IpZN2Xq9vAzy8leFcDyYE7Nyx2KI/AY4iJPcBdBVphA4SS6aPcTgc1x7+jg2pDcICGFpjdOoAtX7OQJ8hEghSlXo9GIoJKqvZ8VIXOqOLIq7S0bVbS7/laQ8ez7TcNk/7d2QIksDObbIiS6jCjS+er3mWjwtCZzfHHvSZz7yZNmJd/fOaSvARHPC6F3Ei/2JiJ0ZW+uF/bXTMupy/xWJDL8ttehCH0N9gnsBLe31Rmhl7pbRhmY0paDIAoEoOkAUsTLgC5VD3/Ymg2UyVGvV6K+VWBobhXMajrz5zqmAjrl9PcR9DgApf4mu2DtkM5JQ==</Modulus><Exponent>AQAB</Exponent><P>0DHEw8LMkmFIN7qslF2KiJcyeHWOR/UXgU9bIZHQXNXUaBxbuZuuZQMLrLfeepILwf3kfpXDbFdzkA7bGPqQ1tDkPJ4+4LekX7s/UZ3N2oqofKw/vEpaRBcMMa5tWoVhxelIGuFO1n+tzVGfve4nDoULmZMi2f67/5FPxEPir0c=</P><Q>10iO+adFF52b+e5TKgir2Hy2qB6ax4tG0MyHHUy+cFGRiKfSbQRANAecpdQyqIw+tesJx7fduW4zYbW31UOU3pLUND/bktuFOxuu4n5bZQScTTVTmkzxDlwG1/leMgAP0uiJNO9jBD4IHEQgJiIC7YaZG5t/UR9tvbB9G2LGQjM=</Q><DP>BpkdMEsTKqx0mneLEqSoSE3qZpDrMnKdDRcTv0ucu+R299m2Onqpmz/udcnZ/i50uvAt9qkOaXeYDP+7h94hCv3Rze4B9iM7zWDkz9RdesicMF9RIcmFdNT6KPTrOEwz3g7Xnyp20it3uaMVmfJbQIWM6ZAVMa12DdJwIbs5Cu8=</DP><DQ>mglEo8TXXuparB2mS7EgpCm319ruDFDPPp7ZHlHHAT6bzxelLHOaLKA1qUGHbanLRQcDXG9mqkL7aLJI8sMERazxQOFgDlgboAtSuqSGaGVAIM5DH2hmIkweaXH3v/bjW5kec03Fn0dzLiZgimhTh/iCnIpKMpU2RD9/hJTMHpk=</DQ><InverseQ>YbnBwGX7XBv0RLsA3Bk4hOh/HV1Bh9wAfKXBSAQ5knv83GsnegR6AVDjEAP39vvWToUOqrpiLygv5r6EfeZ3X+uGCaj01B/8WVtaRCv3UAgRZwObK9OSQRhrT/Ct4QteAHzJ2hIaHcFrmWV9ppeABK9/PSQ0t/yQidEw+BkI0V8=</InverseQ><D>nS1NtyHTU14wbMhP8f8aCrmf1biFmDihYJ6PwfhEIxuMYJzeus1Kx1Bk/PX7zHl1zKWxCmUbu0UHx/pIPgsg3hfTyOeU/BbkJR1b1gsZTbphN4HiUcqsY80CkxLJE578zgFdVSd0GRG/MkhPRC9/VhShb1dYPoMmDgqR8gKWJuYpnPjg1V0chsJIsHCL2pKhv/+WntS7wsnbRRKVTOUpdmDZPEp7Jb5P7zBQJ1zBgVlvyrV6XjvGmoeJQ5FJIjp7tYLDioN6/9PWNK6B2PEPaboxBZbR5JTsIbRSdMYJwnlKb6Vi36c2BRXtMqs1WLcQUMZoEFh49vXq+7ms74DuxQ==</D></RSAKeyValue>";


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

        public string DesDecrypt(string encryptContent)
        {
            byte[] Key = Convert.FromBase64String("QfqMuY1ls/s=");
            byte[] IV = Convert.FromBase64String("VcaktTcHn70=");

            return DesDecryptStringMethod(encryptContent, Key, IV);
        }

        public string DesEncryptString(string content)
        {
            // generate new key and IV

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(cryptoProvider.Key, cryptoProvider.IV), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(content);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        private string DesDecryptStringMethod(string cryptContent, byte[] Key, byte[] IV)
        {
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(cryptContent));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(Key, IV), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }

        private static byte[] TripleDesEncryptTextToMemory(string Data, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }

        private static string TripleDescryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return new ASCIIEncoding().GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }

        public byte[] TripleDesEncrypt(string content)
        {
            // Create a new TripleDESCryptoServiceProvider object
            // to generate a key and initialization vector (IV).
             TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();

            // Encrypt the string to an in-memory buffer.
            return TripleDesEncryptTextToMemory(content, tDESalg.Key, tDESalg.IV);
        }

        public string TripleDesDecrypt(byte[] content)
        {
            // Create a new TripleDESCryptoServiceProvider object
            // to generate a key and initialization vector (IV).

            //  TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();
            byte[] Key = Convert.FromBase64String("kKPaDX9RR46Ybpbc5hkNbOiPrZnYU1r7");
            byte[] IV = Convert.FromBase64String("MbP5zXAzWDY=");


            // Decrypt the buffer back to a string.
            return TripleDescryptTextFromMemory(content, Key, IV);

        }

    }
}
