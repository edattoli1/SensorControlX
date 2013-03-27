namespace MFCcontrol
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mfcMainControlEnable = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.configMFCsButton = new System.Windows.Forms.Button();
            this.picoammSettingsButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.controlPicoammBox = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.configBiasOutputButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.VdsUpDown = new System.Windows.Forms.NumericUpDown();
            this.VgsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.vdsLockCheckBox = new System.Windows.Forms.CheckBox();
            this.vgsLockCheckBox = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.vdsPresValTextBox = new System.Windows.Forms.TextBox();
            this.vgsPresValTextBox = new System.Windows.Forms.TextBox();
            this.biasOutsBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mfcRecipeControl1 = new MFCcontrol.MfcRecipeControl();
            this.mfcControl4 = new MFCcontrol.MFCcontrolTemplate();
            this.mfcControl1 = new MFCcontrol.MFCcontrolTemplate();
            this.mfcControl2 = new MFCcontrol.MFCcontrolTemplate();
            this.mfcControl3 = new MFCcontrol.MFCcontrolTemplate();
            this.graphMfcs1 = new MFCcontrol.GraphMfcs();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VdsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VgsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "MFC MAIN CONTROL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Enable?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(299, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Set Flow";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.mfcMainControlEnable);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.configMFCsButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(43, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 303);
            this.panel1.TabIndex = 13;
            // 
            // mfcMainControlEnable
            // 
            this.mfcMainControlEnable.AutoSize = true;
            this.mfcMainControlEnable.Location = new System.Drawing.Point(26, 267);
            this.mfcMainControlEnable.Name = "mfcMainControlEnable";
            this.mfcMainControlEnable.Size = new System.Drawing.Size(111, 21);
            this.mfcMainControlEnable.TabIndex = 37;
            this.mfcMainControlEnable.Text = "Control MFCs";
            this.mfcMainControlEnable.UseVisualStyleBackColor = true;
            this.mfcMainControlEnable.CheckedChanged += new System.EventHandler(this.mfcMainControlEnable_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.mfcControl4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.mfcControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.mfcControl2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.mfcControl3, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 75);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(498, 174);
            this.tableLayoutPanel2.TabIndex = 36;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 30);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 8);
            this.label16.Margin = new System.Windows.Forms.Padding(8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "MFC";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(456, 8);
            this.label9.Margin = new System.Windows.Forms.Padding(8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Plot?";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(376, 8);
            this.label10.Margin = new System.Windows.Forms.Padding(8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Pres. Flow";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(230, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Max Flow";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Gas";
            // 
            // configMFCsButton
            // 
            this.configMFCsButton.Location = new System.Drawing.Point(236, 255);
            this.configMFCsButton.Name = "configMFCsButton";
            this.configMFCsButton.Size = new System.Drawing.Size(87, 43);
            this.configMFCsButton.TabIndex = 25;
            this.configMFCsButton.Text = "Configure MFCs";
            this.configMFCsButton.UseVisualStyleBackColor = true;
            this.configMFCsButton.Click += new System.EventHandler(this.configMFCbuttonClick);
            // 
            // picoammSettingsButton
            // 
            this.picoammSettingsButton.Location = new System.Drawing.Point(193, 55);
            this.picoammSettingsButton.Name = "picoammSettingsButton";
            this.picoammSettingsButton.Size = new System.Drawing.Size(88, 31);
            this.picoammSettingsButton.TabIndex = 20;
            this.picoammSettingsButton.Text = "Settings";
            this.picoammSettingsButton.UseVisualStyleBackColor = true;
            this.picoammSettingsButton.Click += new System.EventHandler(this.ke648xStart_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "PICOAMMETER";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.controlPicoammBox);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.picoammSettingsButton);
            this.panel5.Location = new System.Drawing.Point(47, 668);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(305, 100);
            this.panel5.TabIndex = 23;
            // 
            // controlPicoammBox
            // 
            this.controlPicoammBox.AutoSize = true;
            this.controlPicoammBox.Location = new System.Drawing.Point(22, 61);
            this.controlPicoammBox.Name = "controlPicoammBox";
            this.controlPicoammBox.Size = new System.Drawing.Size(158, 21);
            this.controlPicoammBox.TabIndex = 22;
            this.controlPicoammBox.Text = "Control Picoammeter";
            this.controlPicoammBox.UseVisualStyleBackColor = true;
            this.controlPicoammBox.CheckedChanged += new System.EventHandler(this.controlPicoammBox_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.configBiasOutputButton);
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Controls.Add(this.biasOutsBox);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(389, 668);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(480, 159);
            this.panel4.TabIndex = 24;
            // 
            // configBiasOutputButton
            // 
            this.configBiasOutputButton.Location = new System.Drawing.Point(16, 100);
            this.configBiasOutputButton.Name = "configBiasOutputButton";
            this.configBiasOutputButton.Size = new System.Drawing.Size(93, 30);
            this.configBiasOutputButton.TabIndex = 28;
            this.configBiasOutputButton.Text = "Configure";
            this.configBiasOutputButton.UseVisualStyleBackColor = true;
            this.configBiasOutputButton.Click += new System.EventHandler(this.configBiasOutputButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.12613F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.54817F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.5382F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel3.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label19, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.VdsUpDown, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.VgsUpDown, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label20, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.vdsLockCheckBox, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.vgsLockCheckBox, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.label24, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.vdsPresValTextBox, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.vgsPresValTextBox, 2, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(147, 44);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(322, 98);
            this.tableLayoutPanel3.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 69);
            this.label17.Margin = new System.Windows.Forms.Padding(5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 17);
            this.label17.TabIndex = 29;
            this.label17.Text = "Vgs";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 37);
            this.label15.Margin = new System.Windows.Forms.Padding(5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 17);
            this.label15.TabIndex = 28;
            this.label15.Text = "Vds";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(58, 5);
            this.label19.Margin = new System.Windows.Forms.Padding(5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 17);
            this.label19.TabIndex = 30;
            this.label19.Text = "Set V";
            // 
            // VdsUpDown
            // 
            this.VdsUpDown.DecimalPlaces = 2;
            this.VdsUpDown.Enabled = false;
            this.VdsUpDown.Location = new System.Drawing.Point(58, 37);
            this.VdsUpDown.Margin = new System.Windows.Forms.Padding(5);
            this.VdsUpDown.Name = "VdsUpDown";
            this.VdsUpDown.Size = new System.Drawing.Size(63, 22);
            this.VdsUpDown.TabIndex = 34;
            this.VdsUpDown.ValueChanged += new System.EventHandler(this.VdsUpDown_ValueChanged);
            // 
            // VgsUpDown
            // 
            this.VgsUpDown.DecimalPlaces = 2;
            this.VgsUpDown.Enabled = false;
            this.VgsUpDown.Location = new System.Drawing.Point(58, 69);
            this.VgsUpDown.Margin = new System.Windows.Forms.Padding(5);
            this.VgsUpDown.Name = "VgsUpDown";
            this.VgsUpDown.Size = new System.Drawing.Size(63, 22);
            this.VgsUpDown.TabIndex = 35;
            this.VgsUpDown.ValueChanged += new System.EventHandler(this.VgsUpDown_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(210, 5);
            this.label20.Margin = new System.Windows.Forms.Padding(5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 17);
            this.label20.TabIndex = 31;
            this.label20.Text = "Lock?";
            // 
            // vdsLockCheckBox
            // 
            this.vdsLockCheckBox.AutoSize = true;
            this.vdsLockCheckBox.Location = new System.Drawing.Point(208, 35);
            this.vdsLockCheckBox.Name = "vdsLockCheckBox";
            this.vdsLockCheckBox.Padding = new System.Windows.Forms.Padding(8);
            this.vdsLockCheckBox.Size = new System.Drawing.Size(31, 26);
            this.vdsLockCheckBox.TabIndex = 32;
            this.vdsLockCheckBox.UseVisualStyleBackColor = true;
            this.vdsLockCheckBox.CheckedChanged += new System.EventHandler(this.vdsLockCheckBox_CheckedChanged);
            // 
            // vgsLockCheckBox
            // 
            this.vgsLockCheckBox.AutoSize = true;
            this.vgsLockCheckBox.Location = new System.Drawing.Point(208, 67);
            this.vgsLockCheckBox.Name = "vgsLockCheckBox";
            this.vgsLockCheckBox.Padding = new System.Windows.Forms.Padding(8);
            this.vgsLockCheckBox.Size = new System.Drawing.Size(31, 28);
            this.vgsLockCheckBox.TabIndex = 33;
            this.vgsLockCheckBox.UseVisualStyleBackColor = true;
            this.vgsLockCheckBox.CheckedChanged += new System.EventHandler(this.vgsLockCheckBox_CheckedChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(131, 5);
            this.label24.Margin = new System.Windows.Forms.Padding(5);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 17);
            this.label24.TabIndex = 36;
            this.label24.Text = "Pres. V";
            // 
            // vdsPresValTextBox
            // 
            this.vdsPresValTextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.vdsPresValTextBox.Location = new System.Drawing.Point(132, 38);
            this.vdsPresValTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.vdsPresValTextBox.Name = "vdsPresValTextBox";
            this.vdsPresValTextBox.Size = new System.Drawing.Size(67, 22);
            this.vdsPresValTextBox.TabIndex = 37;
            // 
            // vgsPresValTextBox
            // 
            this.vgsPresValTextBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.vgsPresValTextBox.Location = new System.Drawing.Point(132, 70);
            this.vgsPresValTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.vgsPresValTextBox.Name = "vgsPresValTextBox";
            this.vgsPresValTextBox.Size = new System.Drawing.Size(67, 22);
            this.vgsPresValTextBox.TabIndex = 38;
            // 
            // biasOutsBox
            // 
            this.biasOutsBox.AutoSize = true;
            this.biasOutsBox.Location = new System.Drawing.Point(15, 56);
            this.biasOutsBox.Name = "biasOutsBox";
            this.biasOutsBox.Size = new System.Drawing.Size(117, 21);
            this.biasOutsBox.TabIndex = 26;
            this.biasOutsBox.Text = "Enable Biases";
            this.biasOutsBox.UseVisualStyleBackColor = true;
            this.biasOutsBox.CheckedChanged += new System.EventHandler(this.biasOutsBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "ANALOG DAQ OUTPUT";
            // 
            // mfcRecipeControl1
            // 
            this.mfcRecipeControl1.Location = new System.Drawing.Point(567, 352);
            this.mfcRecipeControl1.Name = "mfcRecipeControl1";
            this.mfcRecipeControl1.Size = new System.Drawing.Size(302, 273);
            this.mfcRecipeControl1.TabIndex = 25;
            // 
            // mfcControl4
            // 
            this.mfcControl4.Location = new System.Drawing.Point(3, 132);
            this.mfcControl4.Name = "mfcControl4";
            this.mfcControl4.Size = new System.Drawing.Size(487, 39);
            this.mfcControl4.TabIndex = 35;
            // 
            // mfcControl1
            // 
            this.mfcControl1.Location = new System.Drawing.Point(3, 3);
            this.mfcControl1.Name = "mfcControl1";
            this.mfcControl1.Size = new System.Drawing.Size(492, 37);
            this.mfcControl1.TabIndex = 36;
            // 
            // mfcControl2
            // 
            this.mfcControl2.Location = new System.Drawing.Point(3, 46);
            this.mfcControl2.Name = "mfcControl2";
            this.mfcControl2.Size = new System.Drawing.Size(492, 31);
            this.mfcControl2.TabIndex = 37;
            // 
            // mfcControl3
            // 
            this.mfcControl3.Location = new System.Drawing.Point(3, 89);
            this.mfcControl3.Name = "mfcControl3";
            this.mfcControl3.Size = new System.Drawing.Size(492, 33);
            this.mfcControl3.TabIndex = 38;
            // 
            // graphMfcs1
            // 
            this.graphMfcs1.Location = new System.Drawing.Point(25, 5);
            this.graphMfcs1.Name = "graphMfcs1";
            this.graphMfcs1.Size = new System.Drawing.Size(919, 325);
            this.graphMfcs1.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 867);
            this.Controls.Add(this.graphMfcs1);
            this.Controls.Add(this.mfcRecipeControl1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "Main Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VdsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VgsUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button picoammSettingsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox controlPicoammBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox mfcMainControlEnable;
        private System.Windows.Forms.CheckBox biasOutsBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox vdsLockCheckBox;
        private System.Windows.Forms.CheckBox vgsLockCheckBox;
        private System.Windows.Forms.NumericUpDown VdsUpDown;
        private System.Windows.Forms.NumericUpDown VgsUpDown;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox vdsPresValTextBox;
        private System.Windows.Forms.TextBox vgsPresValTextBox;
        private System.Windows.Forms.Button configBiasOutputButton;
        internal System.Windows.Forms.Button configMFCsButton;
        internal MFCcontrolTemplate mfcControl4;
        internal MFCcontrolTemplate mfcControl1;
        internal MFCcontrolTemplate mfcControl2;
        internal MFCcontrolTemplate mfcControl3;
        private MfcRecipeControl mfcRecipeControl1;
        private GraphMfcs graphMfcs1;
        
    }
}

