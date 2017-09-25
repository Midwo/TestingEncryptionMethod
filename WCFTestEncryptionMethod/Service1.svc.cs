using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTestEncryptionMethod
{
    public class Service1 : IService1
    {

        public string WindowsFormConnect(Variables windowsForm)
        {
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
              

                string nameMethodWcf = "";
                string nameMethodWinForms= "";
                string nameMethodMsSQL = "";
                string codeHashCommand = "";
                string sizeInput = "";

                switch (windowsForm.NumberMethodWCF)
                {
                    case 0:
                        nameMethodWcf = "Clear group";
                        break;
                    case 1:
                        nameMethodWcf = "MD5";
                        break;
                    case 2:
                        nameMethodWcf = "RSA";
                        break;
                    case 3:
                        nameMethodWcf = "AES";
                        break;
                    case 4:
                        nameMethodWcf = "DES";
                        break;
                    case 5:
                        nameMethodWcf = "Triple DES";
                        break;
                    case 6:
                        nameMethodWcf = "RC4";
                        break;
                }
                switch (windowsForm.NumberMethodMsSQL)
                {
                    case 0:
                        nameMethodMsSQL = "Clear group";
                        codeHashCommand = "'"+windowsForm.Encrypt+"'";
                        break;
                    case 1:
                        nameMethodMsSQL = "MD4";
                        codeHashCommand = "HASHBYTES('MD4', '"+windowsForm.Encrypt+"')";
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
                switch (windowsForm.Size)
                {
                    case 0:
                        sizeInput = "String 20 char";
                        break;
                    case 1:
                        sizeInput = "JPG.size 0.1 MB < 0.7 MB";
                        break;
                    case 2:
                        sizeInput = "JPG.size 1MB < x MB";
                        break;

                }
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
                        break;
                    case 3:
                        nameMethodWinForms = "AES";
                        break;
                    case 4:
                        nameMethodWinForms = "DES";
                        break;
                    case 5:
                        nameMethodWinForms = "Triple DES";
                        break;
                    case 6:
                        nameMethodWinForms = "RC4";
                        break;
                }

                ConMsSQL conMsSQL = new ConMsSQL();

                //method encrypt


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
                    ,[Size]
                    ,[BaseStop]
                    ,[NameMethodWinForms])
                     Values('" + windowsForm.StartWinForms+"', '"+windowsForm.StopWinforms+"', '"+ runWcf+"', '"+ stopWcf + "', '"+ nameMethodWcf + "', '"+nameMethodMsSQL+"', "+codeHashCommand+",'" +sizeInput+"', GETDATE(), '"+nameMethodWinForms+"')";


                 conMsSQL.sqlcommand(requestInstertInTable);

             }
            catch
            {
                return string.Format("Can't connect to Ms SQL");
            }
      

            return string.Format("You send {0}, oraz {1} oraz {2} opcja algorytmu WCF {3} opcja bazy {4}", windowsForm.Encrypt, windowsForm.StartWinForms, windowsForm.StopWinforms, windowsForm.NumberMethodWCF, windowsForm.NumberMethodMsSQL);

        }

    }
}
