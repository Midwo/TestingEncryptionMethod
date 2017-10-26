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
        string encryptString = "";
        string runWinForm;
        string stopWinForm;
        string returnString;

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

            #region info2
            // In checkedListBox1...
            // 0 is all method encrypt-decrypt winform -> WCF
            // 1 is all method encrypt in database (MS SQL)
            // 2 is all method encrypt in WCF -> MS SQL
            #endregion

            int delay = Decimal.ToInt32(numericUpDown2.Value);
            byte[] byteEncrypt;
            RefWcf.Service1Client client = new RefWcf.Service1Client();
            client.Endpoint.Binding.SendTimeout = new TimeSpan(1, 0, 0);

            RefWcf.Variables variables = new RefWcf.Variables();
            variables.Option = Int32.Parse(checkedListBox1.SelectedIndex.ToString());
            variables.Repeat = Int32.Parse(numericUpDown1.Value.ToString());
            variables.Delay = delay;
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


            if (cBinput.SelectedIndex != -1 && inputText != "")
            {
                Method methodEncrypt = new Method();

                if (checkedListBox1.SelectedIndex != -1)
                {

                    // number 0 is method encrypt - decrypt (windows form encrypt and WCF decrypt)
                    if (checkedListBox1.SelectedIndex == 0)
                    {
                     
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {

                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }

                                runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                encryptString = inputText;
                                variables.Encrypt = encryptString;
                                variables.StartWinForms = runWinForm;
                                variables.NumberMethodMsSQL = 0;
                                variables.NumberMethodWCF = 0;
                                variables.NumberMethodWinForms = 0;
                                variables.Size = cBinput.SelectedIndex;
                                stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                variables.StopWinforms = stopWinForm;
                                client.WindowsFormConnect(variables);
                            
                           
                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                                runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                encryptString = methodEncrypt.Md5Hash(inputText);
                                variables.Encrypt = encryptString;
                                variables.StartWinForms = runWinForm;
                                variables.NumberMethodMsSQL = 0;
                                variables.NumberMethodWCF = 0;
                                variables.NumberMethodWinForms = 1;
                                variables.Size = cBinput.SelectedIndex;
                                stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                variables.StopWinforms = stopWinForm;
                                client.WindowsFormConnect(variables);
                            
                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                                runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                byteEncrypt = methodEncrypt.RsaEncryptByte(inputText);
                                variables.EncryptByte = byteEncrypt;
                                variables.Encrypt = encryptString;
                                variables.StartWinForms = runWinForm;
                                variables.NumberMethodMsSQL = 0;
                                variables.NumberMethodWCF = 0;
                                variables.NumberMethodWinForms = 2;
                                variables.Size = cBinput.SelectedIndex;
                                stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                variables.StopWinforms = stopWinForm;
                                returnString = client.WindowsFormConnect(variables);
                                request = returnString;
                            
                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                                runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                byteEncrypt = methodEncrypt.AesEncryptByte(inputText);
                                variables.EncryptByte = byteEncrypt;
                                variables.Encrypt = encryptString;
                                variables.StartWinForms = runWinForm;
                                variables.NumberMethodMsSQL = 0;
                                variables.NumberMethodWCF = 0;
                                variables.NumberMethodWinForms = 3;
                                variables.Size = cBinput.SelectedIndex;
                                stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                variables.StopWinforms = stopWinForm;
                                returnString = client.WindowsFormConnect(variables);
                                request = returnString;
                            
                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                                runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                encryptString = methodEncrypt.DesEncryptString(inputText);
                                variables.Encrypt = encryptString;
                                variables.StartWinForms = runWinForm;
                                variables.NumberMethodMsSQL = 0;
                                variables.NumberMethodWCF = 0;
                                variables.NumberMethodWinForms = 4;
                                variables.Size = cBinput.SelectedIndex;
                                stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                variables.StopWinforms = stopWinForm;
                                returnString = client.WindowsFormConnect(variables);
                                request = returnString;
                            
                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                                runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                byteEncrypt = methodEncrypt.TripleDesEncrypt(inputText);
                                variables.EncryptByte = byteEncrypt;
                                variables.Encrypt = encryptString;
                                variables.StartWinForms = runWinForm;
                                variables.NumberMethodMsSQL = 0;
                                variables.NumberMethodWCF = 0;
                                variables.NumberMethodWinForms = 5;
                                variables.Size = cBinput.SelectedIndex;
                                stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                variables.StopWinforms = stopWinForm;
                                returnString = client.WindowsFormConnect(variables);
                                request = returnString;
                            
                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                                runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                encryptString = methodEncrypt.Rc4EncryptString(inputText);
                                variables.Encrypt = encryptString;
                                variables.StartWinForms = runWinForm;
                                variables.NumberMethodMsSQL = 0;
                                variables.NumberMethodWCF = 0;
                                variables.NumberMethodWinForms = 6;
                                variables.Size = cBinput.SelectedIndex;
                                stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                                variables.StopWinforms = stopWinForm;
                                returnString = client.WindowsFormConnect(variables);
                                request = returnString;
                            
                        }

                    }
                    if (checkedListBox1.SelectedIndex == 1)
                    {
                        runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                        encryptString = inputText;
                        variables.Encrypt = encryptString;
                        variables.StartWinForms = runWinForm;
                        variables.NumberMethodMsSQL = 0;
                        variables.NumberMethodWCF = 0;
                        variables.NumberMethodWinForms = 0;
                        variables.Size = cBinput.SelectedIndex;
                        stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                        variables.StopWinforms = stopWinForm;
                        client.WindowsFormConnect(variables);
                    }
                    if (checkedListBox1.SelectedIndex == 2)
                    {
                        variables.Encrypt = encryptString;
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {

                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }

                            runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            encryptString = inputText;
                            variables.StartWinForms = runWinForm;
                            variables.NumberMethodMsSQL = 0;
                            variables.NumberMethodWCF = 0;
                            variables.NumberMethodWinForms = 0;
                            variables.Size = cBinput.SelectedIndex;
                            stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StopWinforms = stopWinForm;
                            client.WindowsFormConnect(variables);


                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                            runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StartWinForms = runWinForm;
                            variables.NumberMethodMsSQL = 0;
                            variables.NumberMethodWCF = 1;
                            variables.NumberMethodWinForms = 0;
                            variables.Size = cBinput.SelectedIndex;
                            stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StopWinforms = stopWinForm;
                            client.WindowsFormConnect(variables);

                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                            runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StartWinForms = runWinForm;
                            variables.NumberMethodMsSQL = 0;
                            variables.NumberMethodWCF = 2;
                            variables.NumberMethodWinForms = 0;
                            variables.Size = cBinput.SelectedIndex;
                            stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StopWinforms = stopWinForm;
                            returnString = client.WindowsFormConnect(variables);
                            request = returnString;

                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                            runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StartWinForms = runWinForm;
                            variables.NumberMethodMsSQL = 0;
                            variables.NumberMethodWCF = 3;
                            variables.NumberMethodWinForms = 0;
                            variables.Size = cBinput.SelectedIndex;
                            stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StopWinforms = stopWinForm;
                            returnString = client.WindowsFormConnect(variables);
                            request = returnString;

                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                            runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");

                            variables.StartWinForms = runWinForm;
                            variables.NumberMethodMsSQL = 0;
                            variables.NumberMethodWCF = 4;
                            variables.NumberMethodWinForms = 0;
                            variables.Size = cBinput.SelectedIndex;
                            stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StopWinforms = stopWinForm;
                            returnString = client.WindowsFormConnect(variables);
                            request = returnString;

                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                            runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");

                            variables.StartWinForms = runWinForm;
                            variables.NumberMethodMsSQL = 0;
                            variables.NumberMethodWCF = 5;
                            variables.NumberMethodWinForms = 0;
                            variables.Size = cBinput.SelectedIndex;
                            stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StopWinforms = stopWinForm;
                            returnString = client.WindowsFormConnect(variables);
                            request = returnString;

                        }
                        for (int x = 0; x < Int32.Parse(numericUpDown1.Value.ToString()); x++)
                        {
                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }
                            runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");

                            variables.StartWinForms = runWinForm;
                            variables.NumberMethodMsSQL = 0;
                            variables.NumberMethodWCF = 6;
                            variables.NumberMethodWinForms = 0;
                            variables.Size = cBinput.SelectedIndex;
                            stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StopWinforms = stopWinForm;
                            returnString = client.WindowsFormConnect(variables);
                            request = returnString;

                        }
                    }
                }
                else
                {
                    if (cBAlgorithmWCF.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || cBinput.SelectedIndex == -1 || cBAlgorithmWCF.SelectedIndex == -1)
                    {
                        lStatusInfo.ForeColor = System.Drawing.Color.Red;
                        lStatusInfo.Text = "You must select combobox";
                    }
                    else
                    {

                        // correct option

                        for (int i = 0; i < Int32.Parse(numericUpDown1.Value.ToString()); i++)
                        {

                            if (delay != 0)
                            {
                                var t = Task.Run(async delegate
                                {
                                    await Task.Delay(delay);
                                    return;
                                });
                                t.Wait();
                            }


                            bReset.Enabled = true;
                            runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");


                            // method encrypt



                         
                        
                            switch (cBAlgorithmWinForms.SelectedIndex)
                            {
                                case 0:
                                    encryptString = inputText;
                                    break;
                                case 1:
                                    encryptString = methodEncrypt.Md5Hash(inputText);
                                    break;
                                case 2:
                                    byteEncrypt = methodEncrypt.RsaEncryptByte(inputText);
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
                            variables.Option = Int32.Parse(checkedListBox1.SelectedIndex.ToString());
                            variables.Repeat = Int32.Parse(numericUpDown1.Value.ToString());
                            variables.Delay = delay;
                            //  MessageBox.Show("" + encryptString + "");
                            variables.Encrypt = encryptString;
                            variables.StartWinForms = runWinForm;
                            variables.NumberMethodMsSQL = comboBox3.SelectedIndex;
                            variables.NumberMethodWCF = cBAlgorithmWCF.SelectedIndex;
                            variables.NumberMethodWinForms = cBAlgorithmWinForms.SelectedIndex;
                            variables.Size = cBinput.SelectedIndex;

                            //Show time and sting encrypt
                            // MessageBox.Show("czas start " + runWinForm + " a czas stop " + stopWinForm + "", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
                            variables.StopWinforms = stopWinForm;

                          

                            // MessageBox.Show("" + returnString + "");







                            returnString = client.WindowsFormConnect(variables);
                            request = returnString;
                        }


                        lStatusInfo.Text = request;


                    }

                    lStatusInfo.Visible = true;
                }
            }
            else
            {
                lStatusInfo.ForeColor = System.Drawing.Color.Red;
                lStatusInfo.Text = "You must select combobox or add content";
            }


            //if (cBAlgorithmWCF.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || cBinput.SelectedIndex == -1 || cBAlgorithmWCF.SelectedIndex == -1)
            //{
            //    lStatusInfo.ForeColor = System.Drawing.Color.Red;
            //    lStatusInfo.Text = "You must select combobox";
            //}
            //else
            //{
               
            //    // correct option

            //    for (int i = 0; i < Int32.Parse(numericUpDown1.Value.ToString()); i++)
            //    {

            //        if (delay != 0) {
            //            var t = Task.Run(async delegate
            //            {
            //                await Task.Delay(delay);
            //                return;
            //            });
            //            t.Wait();
            //        }
                

            //        bReset.Enabled = true;
            //    string runWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");

            //    RefWcf.Service1Client client = new RefWcf.Service1Client();

            //    RefWcf.Variables variables = new RefWcf.Variables();

            //    // method encrypt

               

            //    Method methodEncrypt = new Method();
            //    string encryptString = "";
            //    switch (cBAlgorithmWinForms.SelectedIndex)
            //    {
            //        case 0:
            //            encryptString = inputText;
            //            break;
            //        case 1:
            //            encryptString = methodEncrypt.Md5Hash(inputText);
            //            break;
            //        case 2:
            //            byte[] byteEncrypt = methodEncrypt.RsaEncryptByte(inputText);
            //            variables.EncryptByte = byteEncrypt;
            //            break;
            //        case 3:
            //            byteEncrypt = methodEncrypt.AesEncryptByte(inputText);
            //            variables.EncryptByte = byteEncrypt;
            //            break;
            //        case 4:
            //            encryptString = methodEncrypt.DesEncryptString(inputText);
            //            break;
            //        case 5:
            //            byteEncrypt = methodEncrypt.TripleDesEncrypt(inputText);
            //            variables.EncryptByte = byteEncrypt;

            //            //MessageBox.Show(Convert.ToBase64String(variables.EncryptByte));
            //            break;
            //        case 6:
            //            encryptString = methodEncrypt.Rc4EncryptString(inputText);
            //            break;                   

            //    }
            //    //  MessageBox.Show("" + encryptString + "");
            //    variables.Encrypt = encryptString;
            //    variables.StartWinForms = runWinForm;
            //    variables.NumberMethodMsSQL = comboBox3.SelectedIndex;
            //    variables.NumberMethodWCF = cBAlgorithmWCF.SelectedIndex;
            //    variables.NumberMethodWinForms = cBAlgorithmWinForms.SelectedIndex;
            //    variables.Size = cBinput.SelectedIndex;

            //    //Show time and sting encrypt
            //    // MessageBox.Show("czas start " + runWinForm + " a czas stop " + stopWinForm + "", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    string stopWinForm = DateTime.Now.ToString("HH.mm.ss.ffffff");
            //    variables.StopWinforms = stopWinForm;

            //    string returnString;

            //    // MessageBox.Show("" + returnString + "");



               
               
            

            //    returnString = client.WindowsFormConnect(variables);
            //        request = returnString;
            //    }


            //    lStatusInfo.Text = request; 


            //}

            //lStatusInfo.Visible = true;


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
            numericUpDown2.Value = 0;
            numericUpDown1.Value = 1;
            cBAlgorithmWCF.SelectedIndex = -1;
            cBAlgorithmWinForms.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

            checkedListBox1.ClearSelected();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)

            {

                checkedListBox1.SetItemChecked(i, false);

            }

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
            if (numericUpDown1.Value > 100000000)
            {
                numericUpDown1.Value = 100000000;
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox1.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox1.Items.Count; iIndex++)
                checkedListBox1.SetItemCheckState(iIndex, CheckState.Unchecked);
            checkedListBox1.SetItemCheckState(iSelectedIndex, CheckState.Checked);
            bReset.Enabled = true;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            bReset.Enabled = true;
        }

        private void cBAlgorithmWCF_SelectedIndexChanged(object sender, EventArgs e)
        {
            bReset.Enabled = true;
        }

        private void cBAlgorithmWinForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            bReset.Enabled = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            bReset.Enabled = true;
        }
    }
}
