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
            string runWCF = DateTime.Now.ToString("HH.mm.ss.ffffff");
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
                string runWcf = DateTime.Now.ToString("HH.mm.ss.ffffff");

                string nameMethodApi = "";
                string nameMethodMsSQL = "";

                switch (windowsForm.NumberMethodWCF)
                {
                    case 0:
                        nameMethodApi = "Clear group";
                        break;
                    case 1:
                        nameMethodApi = "MD5";
                        break;
                    case 2:
                        nameMethodApi = "RSA";
                        break;
                    case 3:
                        nameMethodApi = "AES";
                        break;
                    case 4:
                        nameMethodApi = "DES";
                        break;
                    case 5:
                        nameMethodApi = "Triple DES";
                        break;
                    case 6:
                        nameMethodApi = "RC4";
                        break;
                }
                switch (windowsForm.NumberMethodMsSQL)
                {
                    case 0:
                        nameMethodMsSQL = "Clear group";
                        break;
                    case 1:
                        nameMethodMsSQL = "MD4";
                        break;
                    case 2:
                        nameMethodMsSQL = "MD5";
                        break;
                    case 3:
                        nameMethodMsSQL = "SHA";
                        break;
                    case 4:
                        nameMethodMsSQL = "SHA1";
                        break;
                    case 5:
                        nameMethodMsSQL = "SHA2_256";
                        break;
                    case 6:
                        nameMethodMsSQL = "SHA2_512";
                        break;
                }

                ConMsSQL conMsSQL = new ConMsSQL();



                //method encrypt
                string stopWcf = DateTime.Now.ToString("HH.mm.ss.ffffff");
                string requestInstertInTable =
                    @"Insert into[BazaTestowa].[dbo].[TestMethodAlgorithms]
                    ([WinStart]
                    ,[WinStop]
                    ,[WcfStart]
                    ,[WcfStop]
                    ,[NameAplicationMethod]
                    ,[NameBaseMethod]
                    ,[ContentCrypt])
                     Values('"+windowsForm.StartWinForms+"', '"+windowsForm.StopWinforms+"', '"+ runWcf+"', '"+ stopWcf + "', '"+ nameMethodApi + "', '"+nameMethodMsSQL+"', '"+windowsForm.Encrypt+"')";


                 conMsSQL.sqlcommand(requestInstertInTable);

             }
            catch
            {
                return string.Format("Can't connect to Ms SQL");
            }
            string stopWCF = DateTime.Now.ToString("HH.mm.ss.ffffff");

            return string.Format("You send {0}, oraz {1} oraz {2} opcja algorytmu WCF {3} opcja bazy {4}", windowsForm.Encrypt, windowsForm.StartWinForms, windowsForm.StopWinforms, windowsForm.NumberMethodWCF, windowsForm.NumberMethodMsSQL);

        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
