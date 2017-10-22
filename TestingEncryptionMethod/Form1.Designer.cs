namespace TestingEncryptionMethod
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cBinput = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.bRun = new System.Windows.Forms.Button();
            this.bReset = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bOpen = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tBInput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lStatusInfo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cBAlgorithmWCF = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cBAlgorithmWinForms = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBinput
            // 
            this.cBinput.FormattingEnabled = true;
            this.cBinput.Items.AddRange(new object[] {
            "String 20 char",
            "Picture .jpg",
            "File .txt"});
            this.cBinput.Location = new System.Drawing.Point(9, 19);
            this.cBinput.Name = "cBinput";
            this.cBinput.Size = new System.Drawing.Size(498, 21);
            this.cBinput.TabIndex = 3;
            this.cBinput.SelectedIndexChanged += new System.EventHandler(this.cBinput_SelectedIndexChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.87645F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.12355F));
            this.tableLayoutPanel4.Controls.Add(this.bRun, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.bReset, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 195);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(514, 57);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // bRun
            // 
            this.bRun.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bRun.Location = new System.Drawing.Point(3, 3);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(240, 51);
            this.bRun.TabIndex = 0;
            this.bRun.Text = "Run";
            this.bRun.UseVisualStyleBackColor = false;
            this.bRun.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // bReset
            // 
            this.bReset.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bReset.Enabled = false;
            this.bReset.Location = new System.Drawing.Point(249, 3);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(262, 51);
            this.bReset.TabIndex = 1;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = false;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.bOpen);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.tBInput);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(512, 55);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // bOpen
            // 
            this.bOpen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bOpen.Enabled = false;
            this.bOpen.Location = new System.Drawing.Point(3, 3);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(48, 47);
            this.bOpen.TabIndex = 0;
            this.bOpen.Text = "Add .jpg";
            this.bOpen.UseVisualStyleBackColor = false;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(57, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 47);
            this.button2.TabIndex = 11;
            this.button2.Text = "Add .txt";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tBInput
            // 
            this.tBInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.tBInput.Enabled = false;
            this.tBInput.Location = new System.Drawing.Point(112, 3);
            this.tBInput.MaxLength = 20;
            this.tBInput.Multiline = true;
            this.tBInput.Name = "tBInput";
            this.tBInput.Size = new System.Drawing.Size(247, 47);
            this.tBInput.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(365, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repeat";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 16);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(131, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyDown);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPG files (*.txt)|*.JPG";
            this.openFileDialog1.FilterIndex = 2;
            // 
            // lStatusInfo
            // 
            this.lStatusInfo.AutoSize = true;
            this.lStatusInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lStatusInfo.Location = new System.Drawing.Point(3, 16);
            this.lStatusInfo.Name = "lStatusInfo";
            this.lStatusInfo.Size = new System.Drawing.Size(37, 13);
            this.lStatusInfo.TabIndex = 0;
            this.lStatusInfo.Text = "Status";
            this.lStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cBAlgorithmWCF);
            this.groupBox3.Location = new System.Drawing.Point(9, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(153, 48);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "In WCF";
            // 
            // cBAlgorithmWCF
            // 
            this.cBAlgorithmWCF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBAlgorithmWCF.FormattingEnabled = true;
            this.cBAlgorithmWCF.Items.AddRange(new object[] {
            "Clear group",
            "MD5",
            "RSA",
            "AES",
            "DES",
            "Triple DES",
            "RC4",
            "All Group"});
            this.cBAlgorithmWCF.Location = new System.Drawing.Point(3, 16);
            this.cBAlgorithmWCF.Name = "cBAlgorithmWCF";
            this.cBAlgorithmWCF.Size = new System.Drawing.Size(147, 21);
            this.cBAlgorithmWCF.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cBAlgorithmWinForms);
            this.groupBox4.Location = new System.Drawing.Point(177, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 48);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "In Windows Forms";
            // 
            // cBAlgorithmWinForms
            // 
            this.cBAlgorithmWinForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBAlgorithmWinForms.FormattingEnabled = true;
            this.cBAlgorithmWinForms.Items.AddRange(new object[] {
            "Clear group",
            "MD5",
            "RSA",
            "AES",
            "DES",
            "Triple DES",
            "RC4",
            "All Group"});
            this.cBAlgorithmWinForms.Location = new System.Drawing.Point(3, 16);
            this.cBAlgorithmWinForms.Name = "cBAlgorithmWinForms";
            this.cBAlgorithmWinForms.Size = new System.Drawing.Size(151, 21);
            this.cBAlgorithmWinForms.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox3);
            this.groupBox5.Location = new System.Drawing.Point(350, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(162, 48);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MS SQL Server";
            // 
            // comboBox3
            // 
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Clear group",
            "MD4",
            "MD5",
            "SHA",
            "SHA1",
            "SHA2_256",
            "SHA2_512",
            "All Group"});
            this.comboBox3.Location = new System.Drawing.Point(3, 16);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(156, 21);
            this.comboBox3.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(3, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose an algorithm";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cBinput);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(513, 47);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Select input:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.41379F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.58621F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(520, 303);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lStatusInfo);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 258);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(514, 42);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Status Info:";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(521, 304);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MD - Testing the encryption method";
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cBinput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.TextBox tBInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.Label lStatusInfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cBAlgorithmWCF;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cBAlgorithmWinForms;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

