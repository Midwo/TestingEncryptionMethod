using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingEncryptionMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lStatusInfo.ResetText();
        }


        private void bOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            #region info
            //                table info in lStatusInfo - combobox:  
            //                0 - String 20 char
            //                1 - JPG.size 0.1 MB < 0.7 MB
            //                2 - JPG.size 1MB < x MB
            // lStatusInfo.Text = cBinput.SelectedIndex.ToString();

            //Index in combobox - windwos form and WCF choose
            //0 Clear group
            //1 MD5
            //2 RSA
            //3 AES
            //4 DES
            //5 Triple DES
            //6 RC4
            //lStatusInfo.Text= comboBox2.SelectedIndex.ToString();

            //index in combobox - choose algorithm in database MS SQL
            // 0 Clear group
            //1 MD4
            //2 MD5
            //3 SHA
            //4 SHA1
            //5 SHA2_256
            //6 SHA2_512
            //lStatusInfo.Text = comboBox3.SelectedIndex.ToString();
#endregion

            if (cBAlgorithmWCF.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || cBinput.SelectedIndex == -1 || cBAlgorithmWCF.SelectedIndex == -1)
            {
                lStatusInfo.ForeColor = System.Drawing.Color.Red;
                lStatusInfo.Text = "You must select combobox";
            }
            else
            {
                // correct option

                bReset.Enabled = true;
                string runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");

                RefWcf.Service1Client client = new RefWcf.Service1Client();

                RefWcf.Variables variables = new RefWcf.Variables();

                // method encrypt

                Method methodEncrypt = new Method();
                string encryptString = "";
                switch (cBAlgorithmWinForms.SelectedIndex)
                {
                    case 0:
                        encryptString = tBInput.Text;
                        break;
                    case 1:
                        encryptString = methodEncrypt.GetMd5Hash(tBInput.Text);
                        break;
                    case 2:
                        encryptString = methodEncrypt.GetRsa(tBInput.Text);
                        #region information with rsa to database
                        // you can't save it in database, because this string have specjal char - escape
                        // you can use in database: 
                        //        set @myString = replace(
                        //replace(
                        //replace(
                        //replace(@myString
                        //, '\', '\\' )
                        //, '%', '\%')
                        //, '_', '\_')
                        //, '[', '\[')

                        //or you can use:
                        encryptString = encryptString.Replace("\n", "\\");
                        encryptString = encryptString.Replace("%", "\n%");
                        encryptString = encryptString.Replace("_", "\n_");
                        encryptString = encryptString.Replace("[", "\n[");
                        #endregion
                        //encryptString = "RSA";
                        break;
                    case 3:
                        encryptString = methodEncrypt.GetMd5Hash(tBInput.Text);
                        break;
                    case 4:
                        encryptString = methodEncrypt.GetMd5Hash(tBInput.Text);
                        break;
                    case 5:
                        encryptString = methodEncrypt.GetMd5Hash(tBInput.Text);
                        break;
                    case 6:
                        encryptString = methodEncrypt.GetMd5Hash(tBInput.Text);
                        break;
                }
                MessageBox.Show("" + encryptString + "");
                variables.Encrypt = encryptString;
                variables.StartWinForms = runWinForm;
                variables.NumberMethodMsSQL = comboBox3.SelectedIndex;
                variables.NumberMethodWCF = cBAlgorithmWCF.SelectedIndex;
                variables.NumberMethodWinForms = cBAlgorithmWinForms.SelectedIndex;
                variables.Size = cBinput.SelectedIndex;

                //Show time and sting encrypt
                // MessageBox.Show("czas start " + runWinForm + " a czas stop " + stopWinForm + "", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                variables.StopWinforms = stopWinForm;

                string returnString;
        
                // MessageBox.Show("" + returnString + "");


               
                for (int  i = 1; i < Int32.Parse(numericUpDown1.Value.ToString()); i++)
                {
                    client.WindowsFormConnect(variables);
                }

                returnString = client.WindowsFormConnect(variables);


              
            }

            lStatusInfo.Visible = true;

       






        }

    



        private void bReset_Click(object sender, EventArgs e)
        {
            cBAlgorithmWCF.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            cBinput.SelectedIndex = -1;
            cBAlgorithmWCF.SelectedIndex = -1;
            bRun.Enabled = true;
            bReset.Enabled = false;
            tBInput.Enabled = false;
            bOpen.Enabled = false;
        }

        private void cBinput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBinput.SelectedIndex ==0)
            {
                tBInput.Enabled = true;
                bOpen.Enabled = false;
            }
            if (cBinput.SelectedIndex == 1)
            {
                tBInput.Enabled = false;
                bOpen.Enabled = true;
                tBInput.Clear();
            }
            if (cBinput.SelectedIndex == 2)
            {
                tBInput.Enabled = false;
                bOpen.Enabled = true;
                tBInput.Clear();
            }

        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (numericUpDown1.Value > 10000)
            {
                numericUpDown1.Value = 10000;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
