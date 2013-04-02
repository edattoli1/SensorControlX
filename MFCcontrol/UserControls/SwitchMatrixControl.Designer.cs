﻿namespace MFCcontrol
{
    partial class SwitchMatrixControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.enableSwitchCheckBox = new System.Windows.Forms.CheckBox();
            this.configureSwitchButton = new System.Windows.Forms.Button();
            this.viewSwitchStateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.loadDeviceListButton = new System.Windows.Forms.Button();
            this.viewDeviceListButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.viewDeviceListButton);
            this.panel1.Controls.Add(this.loadDeviceListButton);
            this.panel1.Controls.Add(this.enableSwitchCheckBox);
            this.panel1.Controls.Add(this.configureSwitchButton);
            this.panel1.Controls.Add(this.viewSwitchStateButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 203);
            this.panel1.TabIndex = 0;
            // 
            // enableSwitchCheckBox
            // 
            this.enableSwitchCheckBox.AutoSize = true;
            this.enableSwitchCheckBox.Location = new System.Drawing.Point(26, 50);
            this.enableSwitchCheckBox.Name = "enableSwitchCheckBox";
            this.enableSwitchCheckBox.Size = new System.Drawing.Size(157, 21);
            this.enableSwitchCheckBox.TabIndex = 1;
            this.enableSwitchCheckBox.Text = "Control Switch Matrix";
            this.enableSwitchCheckBox.UseVisualStyleBackColor = true;
            this.enableSwitchCheckBox.CheckedChanged += new System.EventHandler(this.enableSwitchCheckBox_CheckedChanged);
            // 
            // configureSwitchButton
            // 
            this.configureSwitchButton.Location = new System.Drawing.Point(25, 85);
            this.configureSwitchButton.Name = "configureSwitchButton";
            this.configureSwitchButton.Size = new System.Drawing.Size(89, 34);
            this.configureSwitchButton.TabIndex = 16;
            this.configureSwitchButton.Text = "Configure";
            this.configureSwitchButton.UseVisualStyleBackColor = true;
            this.configureSwitchButton.Click += new System.EventHandler(this.configureSwitchButton_Click);
            // 
            // viewSwitchStateButton
            // 
            this.viewSwitchStateButton.Enabled = false;
            this.viewSwitchStateButton.Location = new System.Drawing.Point(135, 80);
            this.viewSwitchStateButton.Name = "viewSwitchStateButton";
            this.viewSwitchStateButton.Size = new System.Drawing.Size(99, 45);
            this.viewSwitchStateButton.TabIndex = 15;
            this.viewSwitchStateButton.Text = "View, Edit Switch State";
            this.viewSwitchStateButton.UseVisualStyleBackColor = true;
            this.viewSwitchStateButton.Click += new System.EventHandler(this.viewSwitchStateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "SWITCH MATRIX CONTROL";
            // 
            // loadDeviceListButton
            // 
            this.loadDeviceListButton.Location = new System.Drawing.Point(26, 140);
            this.loadDeviceListButton.Name = "loadDeviceListButton";
            this.loadDeviceListButton.Size = new System.Drawing.Size(89, 50);
            this.loadDeviceListButton.TabIndex = 17;
            this.loadDeviceListButton.Text = "Load Device List";
            this.loadDeviceListButton.UseVisualStyleBackColor = true;
            this.loadDeviceListButton.Click += new System.EventHandler(this.loadDeviceListButton_Click);
            // 
            // viewDeviceListButton
            // 
            this.viewDeviceListButton.Enabled = false;
            this.viewDeviceListButton.Location = new System.Drawing.Point(135, 140);
            this.viewDeviceListButton.Name = "viewDeviceListButton";
            this.viewDeviceListButton.Size = new System.Drawing.Size(90, 50);
            this.viewDeviceListButton.TabIndex = 18;
            this.viewDeviceListButton.Text = "View Device List";
            this.viewDeviceListButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SwitchMatrixControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SwitchMatrixControl";
            this.Size = new System.Drawing.Size(268, 209);
            this.Load += new System.EventHandler(this.SwitchMatrixControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.CheckBox enableSwitchCheckBox;
        internal System.Windows.Forms.Button viewSwitchStateButton;
        internal System.Windows.Forms.Button configureSwitchButton;
        private System.Windows.Forms.Button loadDeviceListButton;
        private System.Windows.Forms.Button viewDeviceListButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
