using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        string file;
        string image;
        string request;

        private void bOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string strfilename = "";
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    strfilename = openFileDialog1.InitialDirectory + openFileDialog1.FileName + openFileDialog1.DefaultExt;
                }
                PictureBox picture = new PictureBox();
                picture.Image = Image.FromFile(strfilename);
                Bitmap bmp = new Bitmap(picture.Image);

                byte[] toImage = ImageToByte2(bmp);
                image = Convert.ToBase64String(toImage);
                

                MessageBox.Show("Ok - Loaded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Try another jpg: " + ex.Message, "Error");
            }
        }
        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            #region info
            //                table info in lStatusInfo - combobox:  
            //                0 - String 20 char
            //                1 - Picture.jpg
            //                2 - File.txt
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
                if (cBAlgorithmWinForms.SelectedIndex == 7)
                {
                    
                }

                for (int i = 0; i < Int32.Parse(numericUpDown1.Value.ToString()); i++)
                {
                    bReset.Enabled = true;
                string runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");

                RefWcf.Service1Client client = new RefWcf.Service1Client();

                RefWcf.Variables variables = new RefWcf.Variables();

                // method encrypt

                string inputText = "";
                // options jpg / txt / string
                switch (cBinput.SelectedIndex)
                {
                    case 0:
                        inputText = tBInput.Text;
                        break;
                    case 1:
                        inputText = image;
                        break;
                    case 2:
                        inputText = file;
                        break;
                }

                Method methodEncrypt = new Method();
                string encryptString = "";
                switch (cBAlgorithmWinForms.SelectedIndex)
                {
                    case 0:
                        encryptString = inputText;
                        break;
                    case 1:
                        encryptString = methodEncrypt.Md5Hash(inputText);
                        break;
                    case 2:
                        byte[] byteEncrypt = methodEncrypt.RsaEncryptByte(inputText);
                        variables.EncryptByte = byteEncrypt;
                        break;
                    case 3:
                        byteEncrypt = methodEncrypt.AesEncryptByte(inputText);
                        variables.EncryptByte = byteEncrypt;
                        break;
                    case 4:
                        encryptString = methodEncrypt.DesEncryptString(inputText);
                        break;
                    case 5:
                        byteEncrypt = methodEncrypt.TripleDesEncrypt(inputText);
                        variables.EncryptByte = byteEncrypt;

                        //MessageBox.Show(Convert.ToBase64String(variables.EncryptByte));
                        break;
                    case 6:
                        encryptString = methodEncrypt.Rc4EncryptString(inputText);
                        break;                   

                }
                //  MessageBox.Show("" + encryptString + "");
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



               
               
            

                returnString = client.WindowsFormConnect(variables);
                    request = returnString;
                }


                lStatusInfo.Text = request; 


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
            button2.Enabled = false;
        }

        private void cBinput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBinput.SelectedIndex ==0)
            {
                tBInput.Enabled = true;
                bOpen.Enabled = false;
                button2.Enabled = false;
            }
            if (cBinput.SelectedIndex == 1)
            {
                tBInput.Enabled = false;
                bOpen.Enabled = true;
                button2.Enabled = false ;
                tBInput.Clear();
            }
            if (cBinput.SelectedIndex == 2)
            {
                tBInput.Enabled = false;
                bOpen.Enabled = false;
                button2.Enabled = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string strfilename = "";
                if (openFileDialog2.ShowDialog(this) == DialogResult.OK)
                {
                    strfilename = openFileDialog2.InitialDirectory + openFileDialog2.FileName;
                }



                file = File.ReadAllText(strfilename);


            }
            catch (Exception ex)
            {


                MessageBox.Show("Try another file: " + ex.Message, "Error");
            }
    }
    }
}
