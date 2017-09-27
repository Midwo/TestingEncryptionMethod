using System;
using System.Collections.Generic;
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
