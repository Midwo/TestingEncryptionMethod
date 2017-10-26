using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFTestEncryptionMethod
{
    public class Service1 : IService1
    {
        
        string delay;
        string repeat;
        string option;
        public string WindowsFormConnect(Variables windowsForm)
        {

       

            WSHttpBinding binding = new WSHttpBinding();
            binding.OpenTimeout = new TimeSpan(0, 10, 0);
            binding.CloseTimeout = new TimeSpan(0, 10, 0);
            binding.SendTimeout = new TimeSpan(0, 10, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 10, 0);







            string runWcf = DateTime.Now.ToString("HH.mm.ss.ffffff");
            //method encrypt
            try
            {
                #region information with number method
                //windwos form and WCF 
                //0 Clear group
                //1 MD5
                //2 RSA
                //3 AES
                //4 DES
                //5 Triple DES
                //6 RC4


                // algorithm in database MS SQL
                //0 Clear group
                //1 MD4
                //2 MD5
                //3 SHA
                //4 SHA1
                //5 SHA2_256
                //6 SHA2_512


                #endregion

                EncryptDecrypt method = new EncryptDecrypt();
                string nameMethodWcf = "";
                string nameMethodWinForms = "";
                string nameMethodMsSQL = "";
                string codeHashCommand = "";
                string sizeInput = "";
                byte[] EncryptByte;

                switch (windowsForm.Size)
                {
                    case 0:
                        sizeInput = "String 20 char";
                        break;
                    case 1:
                        sizeInput = "Picture.jpg";
                        break;
                    case 2:
                        sizeInput = "File.txt";
                        break;

                }

                switch (windowsForm.Option)
                {
                    case -1:
                        option = "normal - single shot";
                        break;
                    case 0:
                        option = "All Encrypt - Decrypt (PROG)";
                        break;
                    case 1:
                        option = "All Encrypt (DATA)";
                        break;
                    case 2:
                        option = "All Encrypt (PROG)";
                        break;

                }





                delay = windowsForm.Delay.ToString();
                repeat = windowsForm.Repeat.ToString();




                if (windowsForm.Option == 1)
                {
                    delay = "not available in ALL method SQL";
                    for (int i = 0; i < windowsForm.Repeat; i++)
                    {

                        nameMethodMsSQL = "Clear group";
                        codeHashCommand = "'" + windowsForm.Encrypt + "'";
                        string stopWcf = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.ffffff");
                        string requestInstertInTable =
                            @"Insert into[BazaTestowa].[dbo].[TestMethodAlgorithms]
                    ([WinStart]
                    ,[WinStop]
                    ,[WcfStart]
                    ,[WcfStop]
                    ,[NameMethodWcf]
                    ,[NameBaseMethod]
                    ,[ContentCrypt]
                    ,[Type]
                    ,[BaseStop]
                    ,[NameMethodWinForms]
                    ,[Option]
                    ,[Repeat]
                    ,[Delay])
                     Values('" + windowsForm.StartWinForms + "', '" + windowsForm.StopWinforms + "', '" + runWcf + "', '" + stopWcf + "', '" + nameMethodWcf + "', '" + nameMethodMsSQL + "', " + codeHashCommand + ",'" + sizeInput + "', GETDATE(), '" + nameMethodWinForms + "','" + option + "','" + repeat + "','" + delay + "')";
                        ConMsSQL conMsSQL = new ConMsSQL();

                        conMsSQL.sqlcommand(requestInstertInTable);
                    }
                    for (int i = 0; i < windowsForm.Repeat; i++)
                    {

                        nameMethodMsSQL = "MD4";
                        codeHashCommand = "HASHBYTES('MD4', '" + windowsForm.Encrypt + "')";
                        string stopWcf = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.ffffff");
                        string requestInstertInTable =
                            @"Insert into[BazaTestowa].[dbo].[TestMethodAlgorithms]
                    ([WinStart]
                    ,[WinStop]
                    ,[WcfStart]
                    ,[WcfStop]
                    ,[NameMethodWcf]
                    ,[NameBaseMethod]
                    ,[ContentCrypt]
                    ,[Type]
                    ,[BaseStop]
                    ,[NameMethodWinForms]
                    ,[Option]
                    ,[Repeat]
                    ,[Delay])
                     Values('" + windowsForm.StartWinForms + "', '" + windowsForm.StopWinforms + "', '" + runWcf + "', '" + stopWcf + "', '" + nameMethodWcf + "', '" + nameMethodMsSQL + "', " + codeHashCommand + ",'" + sizeInput + "', GETDATE(), '" + nameMethodWinForms + "','" + option + "','" + repeat + "','" + delay + "')";
                        ConMsSQL conMsSQL = new ConMsSQL();

                        conMsSQL.sqlcommand(requestInstertInTable);
                    }
                    for (int i = 0; i < windowsForm.Repeat; i++)
                    {

                        nameMethodMsSQL = "MD5";
                        codeHashCommand = "HASHBYTES('MD5', '" + windowsForm.Encrypt + "')";
                        string stopWcf = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.ffffff");
                        string requestInstertInTable =
                            @"Insert into[BazaTestowa].[dbo].[TestMethodAlgorithms]
                    ([WinStart]
                    ,[WinStop]
                    ,[WcfStart]
                    ,[WcfStop]
                    ,[NameMethodWcf]
                    ,[NameBaseMethod]
                    ,[ContentCrypt]
                    ,[Type]
                    ,[BaseStop]
                    ,[NameMethodWinForms]
                    ,[Option]
                    ,[Repeat]
                    ,[Delay])
                     Values('" + windowsForm.StartWinForms + "', '" + windowsForm.StopWinforms + "', '" + runWcf + "', '" + stopWcf + "', '" + nameMethodWcf + "', '" + nameMethodMsSQL + "', " + codeHashCommand + ",'" + sizeInput + "', GETDATE(), '" + nameMethodWinForms + "','" + option + "','" + repeat + "','" + delay + "')";
                        ConMsSQL conMsSQL = new ConMsSQL();

                        conMsSQL.sqlcommand(requestInstertInTable);
                    }
                    for (int i = 0; i < windowsForm.Repeat; i++)
                    {

                        nameMethodMsSQL = "SHA";
                        codeHashCommand = "HASHBYTES('SHA', '" + windowsForm.Encrypt + "')";
                        string stopWcf = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.ffffff");
                        string requestInstertInTable =
                            @"Insert into[BazaTestowa].[dbo].[TestMethodAlgorithms]
                    ([WinStart]
                    ,[WinStop]
                    ,[WcfStart]
                    ,[WcfStop]
                    ,[NameMethodWcf]
                    ,[NameBaseMethod]
                    ,[ContentCrypt]
                    ,[Type]
                    ,[BaseStop]
                    ,[NameMethodWinForms]
                    ,[Option]
                    ,[Repeat]
                    ,[Delay])
                     Values('" + windowsForm.StartWinForms + "', '" + windowsForm.StopWinforms + "', '" + runWcf + "', '" + stopWcf + "', '" + nameMethodWcf + "', '" + nameMethodMsSQL + "', " + codeHashCommand + ",'" + sizeInput + "', GETDATE(), '" + nameMethodWinForms + "','" + option + "','" + repeat + "','" + delay + "')";
                        ConMsSQL conMsSQL = new ConMsSQL();

                        conMsSQL.sqlcommand(requestInstertInTable);
                    }
                    for (int i = 0; i < windowsForm.Repeat; i++)
                    {

                        nameMethodMsSQL = "SHA1";
                        codeHashCommand = "HASHBYTES('SHA1', '" + windowsForm.Encrypt + "')";
                        string stopWcf = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.ffffff");
                        string requestInstertInTable =
                            @"Insert into[BazaTestowa].[dbo].[TestMethodAlgorithms]
                    ([WinStart]
                    ,[WinStop]
                    ,[WcfStart]
                    ,[WcfStop]
                    ,[NameMethodWcf]
                    ,[NameBaseMethod]
                    ,[ContentCrypt]
                    ,[Type]
                    ,[BaseStop]
                    ,[NameMethodWinForms]
                    ,[Option]
                    ,[Repeat]
                    ,[Delay])
                     Values('" + windowsForm.StartWinForms + "', '" + windowsForm.StopWinforms + "', '" + runWcf + "', '" + stopWcf + "', '" + nameMethodWcf + "', '" + nameMethodMsSQL + "', " + codeHashCommand + ",'" + sizeInput + "', GETDATE(), '" + nameMethodWinForms + "','" + option + "','" + repeat + "','" + delay + "')";
                        ConMsSQL conMsSQL = new ConMsSQL();

                        conMsSQL.sqlcommand(requestInstertInTable);
                    }
                    for (int i = 0; i < windowsForm.Repeat; i++)
                    {

                        nameMethodMsSQL = "SHA2_256";
                        codeHashCommand = "HASHBYTES('SHA2_256', '" + windowsForm.Encrypt + "')";
                        string stopWcf = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.ffffff");
                        string requestInstertInTable =
                            @"Insert into[BazaTestowa].[dbo].[TestMethodAlgorithms]
                    ([WinStart]
                    ,[WinStop]
                    ,[WcfStart]
                    ,[WcfStop]
                    ,[NameMethodWcf]
                    ,[NameBaseMethod]
                    ,[ContentCrypt]
                    ,[Type]
                    ,[BaseStop]
                    ,[NameMethodWinForms]
                    ,[Option]
                    ,[Repeat]
                    ,[Delay])
                     Values('" + windowsForm.StartWinForms + "', '" + windowsForm.StopWinforms + "', '" + runWcf + "', '" + stopWcf + "', '" + nameMethodWcf + "', '" + nameMethodMsSQL + "', " + codeHashCommand + ",'" + sizeInput + "', GETDATE(), '" + nameMethodWinForms + "','" + option + "','" + repeat + "','" + delay + "')";
                        ConMsSQL conMsSQL = new ConMsSQL();

                        conMsSQL.sqlcommand(requestInstertInTable);
                    }
                    for (int i = 0; i < windowsForm.Repeat; i++)
                    {

                        nameMethodMsSQL = "SHA2_512";
                        codeHashCommand = "HASHBYTES('SHA2_512', '" + windowsForm.Encrypt + "')";
                        string stopWcf = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.ffffff");
                        string requestInstertInTable =
                            @"Insert into[BazaTestowa].[dbo].[TestMethodAlgorithms]
                    ([WinStart]
                    ,[WinStop]
                    ,[WcfStart]
                    ,[WcfStop]
                    ,[NameMethodWcf]
                    ,[NameBaseMethod]
                    ,[ContentCrypt]
                    ,[Type]
                    ,[BaseStop]
                    ,[NameMethodWinForms]
                    ,[Option]
                    ,[Repeat]
                    ,[Delay])
                     Values('" + windowsForm.StartWinForms + "', '" + windowsForm.StopWinforms + "', '" + runWcf + "', '" + stopWcf + "', '" + nameMethodWcf + "', '" + nameMethodMsSQL + "', " + codeHashCommand + ",'" + sizeInput + "', GETDATE(), '" + nameMethodWinForms + "','" + option + "','" + repeat + "','" + delay + "')";

                        ConMsSQL conMsSQL = new ConMsSQL();
                        conMsSQL.sqlcommand(requestInstertInTable);
                    }




                }
                if (windowsForm.Option == -1 || windowsForm.Option == 0 || windowsForm.Option == 2)
                {
                    switch (windowsForm.NumberMethodWinForms)
                    {
                        case 0:
                            nameMethodWinForms = "Clear group";
                            break;
                        case 1:
                            nameMethodWinForms = "MD5";
                            break;
                        case 2:
                            nameMethodWinForms = "RSA";
                            byte[] encryptByte = method.RsaDectryptByte(windowsForm.EncryptByte);
                            windowsForm.Encrypt = Encoding.UTF8.GetString(encryptByte);
                            break;
                        case 3:
                            nameMethodWinForms = "AES";
                            windowsForm.Encrypt = method.AesDecryptString(windowsForm.EncryptByte);
                            break;
                        case 4:
                            nameMethodWinForms = "DES";
                            windowsForm.Encrypt = method.DesDecrypt(windowsForm.Encrypt);
                            break;
                        case 5:
                            nameMethodWinForms = "Triple DES";
                            windowsForm.Encrypt = method.TripleDesDecrypt(windowsForm.EncryptByte);
                            break;
                        case 6:
                            nameMethodWinForms = "RC4";
                            windowsForm.Encrypt = method.Rc4DecryptString(windowsForm.Encrypt);
                            break;
                    }

                    switch (windowsForm.NumberMethodWCF)
                    {
                        case 0:
                            nameMethodWcf = "Clear group";
                            break;
                        case 1:
                            nameMethodWcf = "MD5";
                            windowsForm.Encrypt = method.GetMd5Hash(windowsForm.Encrypt);
                            break;
                        case 2:
                            nameMethodWcf = "RSA";
                            EncryptByte = method.RsaEncryptByte(windowsForm.Encrypt);
                            windowsForm.Encrypt = Convert.ToBase64String(EncryptByte);
                            break;
                        case 3:
                            nameMethodWcf = "AES";
                            EncryptByte = method.AesEncryptByte(windowsForm.Encrypt);
                            windowsForm.Encrypt = Convert.ToBase64String(EncryptByte);
                            break;
                        case 4:
                            nameMethodWcf = "DES";
                            windowsForm.Encrypt = method.DesEncryptString(windowsForm.Encrypt);
                            break;
                        case 5:
                            nameMethodWcf = "Triple DES";
                            EncryptByte = method.TripleDesEncrypt(windowsForm.Encrypt);
                            windowsForm.Encrypt = Convert.ToBase64String(EncryptByte);
                            break;
                        case 6:
                            nameMethodWcf = "RC4";
                            windowsForm.Encrypt = method.Rc4EncryptString(windowsForm.Encrypt);
                            break;
                    }

                    switch (windowsForm.NumberMethodMsSQL)
                    {
                        case 0:
                            nameMethodMsSQL = "Clear group";
                            codeHashCommand = "'" + windowsForm.Encrypt + "'";
                            break;
                        case 1:
                            nameMethodMsSQL = "MD4";
                            codeHashCommand = "HASHBYTES('MD4', '" + windowsForm.Encrypt + "')";
                            break;
                        case 2:
                            nameMethodMsSQL = "MD5";
                            codeHashCommand = "HASHBYTES('MD5', '" + windowsForm.Encrypt + "')";
                            break;
                        case 3:
                            nameMethodMsSQL = "SHA";
                            codeHashCommand = "HASHBYTES('SHA', '" + windowsForm.Encrypt + "')";
                            break;
                        case 4:
                            nameMethodMsSQL = "SHA1";
                            codeHashCommand = "HASHBYTES('SHA1', '" + windowsForm.Encrypt + "')";
                            break;
                        case 5:
                            nameMethodMsSQL = "SHA2_256";
                            codeHashCommand = "HASHBYTES('SHA2_256', '" + windowsForm.Encrypt + "')";
                            break;
                        case 6:
                            nameMethodMsSQL = "SHA2_512";
                            codeHashCommand = "HASHBYTES('SHA2_512', '" + windowsForm.Encrypt + "')";
                            break;
                    }

                    string stopWcf = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss.ffffff");
                    string requestInstertInTable =
                        @"Insert into[BazaTestowa].[dbo].[TestMethodAlgorithms]
                    ([WinStart]
                    ,[WinStop]
                    ,[WcfStart]
                    ,[WcfStop]
                    ,[NameMethodWcf]
                    ,[NameBaseMethod]
                    ,[ContentCrypt]
                    ,[Type]
                    ,[BaseStop]
                    ,[NameMethodWinForms]
                    ,[Option]
                    ,[Repeat]
                    ,[Delay])
                     Values('" + windowsForm.StartWinForms + "', '" + windowsForm.StopWinforms + "', '" + runWcf + "', '" + stopWcf + "', '" + nameMethodWcf + "', '" + nameMethodMsSQL + "', " + codeHashCommand + ",'" + sizeInput + "', GETDATE(), '" + nameMethodWinForms + "','" + option + "','" + repeat + "','" + delay + "')";
                    ConMsSQL conMsSQL = new ConMsSQL();

                    conMsSQL.sqlcommand(requestInstertInTable);
                }
            

                
             }
            catch
            {
                return string.Format("Can't connect to Ms SQL or Error WCF");
            }
      

            return string.Format("OK - request in WCF and MS SQL - Successful");

        }

    }
}
