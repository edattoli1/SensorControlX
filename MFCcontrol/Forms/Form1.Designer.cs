﻿namespace MFCcontrol
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
            this.graphMfcs1 = new MFCcontrol.GraphMfcs();
            this.mfcRecipeControl1 = new MFCcontrol.MfcRecipeControl();
            this.mfcControl4 = new MFCcontrol.MFCcontrolTemplate();
            this.mfcControl1 = new MFCcontrol.MFCcontrolTemplate();
            this.mfcControl2 = new MFCcontrol.MFCcontrolTemplate();
            this.mfcControl3 = new MFCcontrol.MFCcontrolTemplate();
            this.sensorBiasControl1 = new MFCcontrol.SensorBiasControl();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
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
            // graphMfcs1
            // 
            this.graphMfcs1.Location = new System.Drawing.Point(25, 5);
            this.graphMfcs1.Name = "graphMfcs1";
            this.graphMfcs1.Size = new System.Drawing.Size(919, 325);
            this.graphMfcs1.TabIndex = 26;
            // 
            // mfcRecipeControl1
            // 
            this.mfcRecipeControl1.Location = new System.Drawing.Point(567, 347);
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
            // sensorBiasControl1
            // 
            this.sensorBiasControl1.Location = new System.Drawing.Point(384, 658);
            this.sensorBiasControl1.Name = "sensorBiasControl1";
            this.sensorBiasControl1.Size = new System.Drawing.Size(485, 161);
            this.sensorBiasControl1.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 867);
            this.Controls.Add(this.sensorBiasControl1);
            this.Controls.Add(this.graphMfcs1);
            this.Controls.Add(this.mfcRecipeControl1);
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
        private System.Windows.Forms.CheckBox mfcMainControlEnable;
        internal System.Windows.Forms.Button configMFCsButton;
        internal MFCcontrolTemplate mfcControl4;
        internal MFCcontrolTemplate mfcControl1;
        internal MFCcontrolTemplate mfcControl2;
        internal MFCcontrolTemplate mfcControl3;
        private MfcRecipeControl mfcRecipeControl1;
        private GraphMfcs graphMfcs1;
        private SensorBiasControl sensorBiasControl1;
        
    }
}
