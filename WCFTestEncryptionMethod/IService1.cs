using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTestEncryptionMethod
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string WindowsFormConnect(Variables windowsForm);



        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Variables
    {
        string encrypt;
        string startWinForms;
        string stopWinforms;
        int numberMethodWCF;
        int numberMethodMsSQL;
        int numberMethodWinForms;
        int size;
        byte[] encryptByte;
        int delay;
        int option;
        int repeat;

        [DataMember]
        public int Repeat
        {
            get { return repeat; }
            set { repeat = value; }
        }


        [DataMember]
        public byte [] EncryptByte
        {
            get { return encryptByte; }
            set { encryptByte = value; }
        }

        [DataMember]
        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        } 

        [DataMember]
        public int Option
        {
            get { return option; }
            set { option = value; }
        }

        [DataMember]
        public int NumberMethodWinForms
        {
            get { return numberMethodWinForms; }
            set { numberMethodWinForms = value; }
        }

        [DataMember]
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        [DataMember]
        public int NumberMethodWCF
        {
            get { return numberMethodWCF; }
            set { numberMethodWCF = value; }
        }
        [DataMember]
        public int NumberMethodMsSQL
        {
            get { return numberMethodMsSQL; }
            set { numberMethodMsSQL = value; }
        }


        [DataMember]
        public string Encrypt
        {
            get { return encrypt; }
            set { encrypt = value; }
        }
        [DataMember]
        public string StartWinForms
        {
            get { return startWinForms; }
            set { startWinForms = value; }
        }
        [DataMember]
        public string StopWinforms
        {
            get { return stopWinforms; }
            set { stopWinforms = value; }
        }
    }




}
