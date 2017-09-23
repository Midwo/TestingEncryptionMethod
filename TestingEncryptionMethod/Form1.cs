using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            if (comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || cBinput.SelectedIndex == -1)
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

                variables.Encrypt = tBInput.Text;
                variables.StartWinForms = runWinForm;
                variables.NumberMethodMsSQL = comboBox3.SelectedIndex;
                variables.NumberMethodWCF = comboBox2.SelectedIndex;
                variables.Size = cBinput.SelectedIndex;

                //Show time and sting encrypt
                // MessageBox.Show("czas start " + runWinForm + " a czas stop " + stopWinForm + "", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                variables.StopWinforms = stopWinForm;

                string returnString;
                returnString = client.WindowsFormConnect(variables);
                MessageBox.Show("" + returnString + "");
            }

            lStatusInfo.Visible = true;

       






        }

        private void bReset_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            cBinput.SelectedIndex = -1;
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
    }
}
