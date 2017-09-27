using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingEncryptionMethod
{
    class Method
    {
        public byte [] RsaEncryptByte(string content)
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

                    byte [] encryptedData = rsa.Encrypt(testData, true);
                    
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    MessageBox.Show(base64Encrypted);

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

        public byte[] RsaDectryptByte(byte [] RsaEncryptByte)
        {
    

            var privateKey =
              "<RSAKeyValue><Modulus>wv2+A8oH4yVJ4ZBaeOqM0X1CUOgMPIcFkrbrTCDgsMEYCYO9asamOWlLUCJptp1xKZahtDn7iZa5MwqVFUm5MJKl3bMnyvkUSBUWz8qzvbYbpwy3KZlKxK+crMcUhm5G7SNsMkaB2mxe05fW1Q4kfhbflBM9qXicRLggcWL92PU=</Modulus><Exponent>AQAB</Exponent><P>xTtjhnfGdoEvnOvL/2srpVOw9UqapDmlfA/AM688KnhuQndTTB4lal2DsaLsQ9rvJbjEPotqG2smT48SO0LKAw==</P><Q>/Rdtccp3VpWhIfXaVHZswcesDbF1qEm2ediVGI3JSZDkUYtid0uPpPE4HJeXJIuRFJORM3p+g26nPr3crN9bpw==</Q><DP>VgaeVWNevAeC5fXvJ3vuMJE9aO/eXW0LYf5YvfJb0sZuiS0UtumbNjaNn2hJlxsiHhjl98XFRSpKLn9f21s5Uw==</DP><DQ>cbr3WW0MF4KBuAsMo2vcD3A0pqqaHpeRQkvLJA+C5mYP03z5MHZqBErJVj/gkXGOLlrpouJmu5Ub3pve8GgmfQ==</DQ><InverseQ>YLFKqHn37A61BAtIjaiol5TJy0cBDWufrpgPsuZRRUzAZfMnkb9eZ+zS4KF67MT610IMQebeEYc4atDhizH6lQ==</InverseQ><D>sqv3tVkmqQi+DiZMAIhLyJnSbnhy3fOLM8jRCs0FlnEZKX7BzlmAbxMAo8kkvOS/kLAqNA79YjHuOcr0mLEZMsBJmVyYgydP9k3UIM5z+SPOzAjmnGQyRNAFZDN3zQN/92R58FHfij0gRevDhT0uPrQjaDwp7libTL3Sxbj2H/E=</D></RSAKeyValue>";

         

            using (var rsa = new RSACryptoServiceProvider(1024))
            {

                try
                {



                    rsa.FromXmlString(privateKey);

                    var decryptedBytes = rsa.Decrypt(RsaEncryptByte, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    MessageBox.Show(decryptedData);

                    return decryptedBytes;

                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }
        }


        //public byte [] GetRsa(string content)
        //{
        //    byte[] encryptedData = new byte[0];

        //    try
        //    {
        //        //Create a UnicodeEncoder to convert between byte array and string.
        //        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        //        //Create byte arrays to hold original, encrypted, and decrypted data.
        //        byte[] dataToEncrypt = ByteConverter.GetBytes(content);

        //      byte[] decryptedData;

        //        //Create a new instance of RSACryptoServiceProvider to generate
        //        //public and private key data.
        //        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        //        {

        //            //Pass the data to ENCRYPT, the public key information 
        //            //(using RSACryptoServiceProvider.ExportParameters(false),
        //            //and a boolean flag specifying no OAEP padding.
        //            encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

        //            //Pass the data to DECRYPT, the private key information 
        //            // (using RSACryptoServiceProvider.ExportParameters(true),
        //            //and a boolean flag specifying no OAEP padding.

        //            byte[] dane = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
        //            decryptedData = dane;
        //            MessageBox.Show(ByteConverter.GetString(decryptedData), "lol");
        //            RSAParameters RSAParams = RSA.ExportParameters(true);
        //            MessageBox.Show(RSAParams.GetHashCode().ToString());
        //           decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);

        //            //Display the decrypted plaintext

        //            MessageBox.Show("" + ByteConverter.GetString(decryptedData) + "", "hmm");
        //            return encryptedData;


        //        }
        //    }
        //    catch (ArgumentNullException)
        //    {
        //        //Catch this exception in case the encryption
        //        //not succeed.
        //        MessageBox.Show("Encryption failed.", "RSA - information");


        //    }


        //    try
        //    {
        //        //Create RSACryptoServiceProvider
        //        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        //        {


        //            //Export the key information to an RSAParameters object.
        //            //Pass false to export the public key information or pass
        //            //true to export public and private key information.
        //            RSAParameters RSAParams = RSA.ExportParameters(false);
        //        }


        //    }
        //    catch (CryptographicException ex)
        //    {
        //        //exception in case the encryption
        //        //not succeed.
        //        MessageBox.Show("" + ex.Message + "", "RSA - information");


        //    }
        //    return encryptedData;
        //}


        //static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        //{
        //    try
        //    {
        //        byte[] encryptedData;
        //        //Create a new instance of RSACryptoServiceProvider.
        //        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        //        {

        //            //Import the RSA Key information. This only needs
        //            //toinclude the public key information.
        //            RSA.ImportParameters(RSAKeyInfo);

        //            //Encrypt the passed byte array and specify OAEP padding.  
        //            //OAEP padding is only available on Microsoft Windows XP or
        //            //later.  
        //            encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
        //        }
        //        return encryptedData;
        //    }
        //    //Catch and display a CryptographicException  
        //    //to the console.
        //    catch (CryptographicException e)
        //    {

        //        MessageBox.Show("" + e.Message + "", "RSA - information");



        //        return null;
        //    }

        //}

        //static public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        //{
        //    try
        //    {
        //        byte[] decryptedData;
        //        //Create a new instance of RSACryptoServiceProvider.
        //        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        //        {
        //            //Import the RSA Key information. This needs
        //            //to include the private key information.
        //            RSA.ImportParameters(RSAKeyInfo);

        //            //Decrypt the passed byte array and specify OAEP padding.  
        //            //OAEP padding is only available on Microsoft Windows XP or
        //            //later.  
        //            decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
        //        }
        //        return decryptedData;
        //    }
        //    //Catch and display a CryptographicException  
        //    //to the console.
        //    catch (CryptographicException e)
        //    {
        //        MessageBox.Show("" + e.ToString() + "", "RSA - information");


        //        return null;
        //    }

        //}

        public string GetMd5Hash(string content)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = CreateMd5Hash(md5Hash, content);

                return hash;
            }
            
        }


        static string CreateMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
