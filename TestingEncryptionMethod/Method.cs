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


        public string RsaKeyPublic;


        public string GetRsa(string content)
        {
            string result = "";
         
            try
            {
                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                //Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] dataToEncrypt = ByteConverter.GetBytes("Data to Encrypt");
                byte[] encryptedData;
              //  byte[] decryptedData;

                //Create a new instance of RSACryptoServiceProvider to generate
                //public and private key data.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Pass the data to ENCRYPT, the public key information 
                    //(using RSACryptoServiceProvider.ExportParameters(false),
                    //and a boolean flag specifying no OAEP padding.
                    encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                    var pubKey = RSA.ExportParameters(false);
                    var privKey = RSA.ExportParameters(false);
                    //Pass the data to DECRYPT, the private key information 
                    //(using RSACryptoServiceProvider.ExportParameters(true),
                    //and a boolean flag specifying no OAEP padding.
                    //decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
                      //we need some buffer
                        var sw = new System.IO.StringWriter();
                        //we need a serializer
                        var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                        //serialize the key into the stream
                        xs.Serialize(sw, pubKey);
                    //get the string from the stream
                    RsaKeyPublic = sw.ToString();
                       //MessageBox.Show("" + RsaKeyPublic + "");
                       
                    



                 //   MessageBox.Show("" + RSA.ExportParameters(false).ToString() + "");
                  //  MessageBox.Show("" + RSA.ExportParameters(true).ToString() + "");
                    //Display the decrypted plaintext

                    // MessageBox.Show("" + ByteConverter.GetString(decryptedData) + "");
                    result = System.Text.Encoding.UTF8.GetString(encryptedData);
                    

                }
            }
            catch (ArgumentNullException)
            {
                //Catch this exception in case the encryption
                //not succeed.
                MessageBox.Show("Encryption failed.", "RSA - information");
                

            }
          

            try
            {
                //Create RSACryptoServiceProvider
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {


                    //Export the key information to an RSAParameters object.
                    //Pass false to export the public key information or pass
                    //true to export public and private key information.
                    RSAParameters RSAParams = RSA.ExportParameters(false);
                }


            }
            catch (CryptographicException ex)
            {
                //exception in case the encryption
                //not succeed.
                MessageBox.Show("" + ex.Message + "", "RSA - information");


            }
            return result;
        }


        static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {

                MessageBox.Show("" + e.Message + "", "RSA - information");

               

                return null;
            }

        }

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
        //        MessageBox.Show(""+ e.ToString() + "", "RSA - information");
 

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
