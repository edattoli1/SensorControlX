namespace MFCcontrol
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
            this.configureSwitchButton = new System.Windows.Forms.Button();
            this.viewSwitchStateButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.configureSwitchButton);
            this.panel1.Controls.Add(this.viewSwitchStateButton);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 148);
            this.panel1.TabIndex = 0;
            // 
            // configureSwitchButton
            // 
            this.configureSwitchButton.Location = new System.Drawing.Point(32, 96);
            this.configureSwitchButton.Name = "configureSwitchButton";
            this.configureSwitchButton.Size = new System.Drawing.Size(89, 34);
            this.configureSwitchButton.TabIndex = 16;
            this.configureSwitchButton.Text = "Configure";
            this.configureSwitchButton.UseVisualStyleBackColor = true;
            this.configureSwitchButton.Click += new System.EventHandler(this.configureSwitchButton_Click);
            // 
            // viewSwitchStateButton
            // 
            this.viewSwitchStateButton.Location = new System.Drawing.Point(148, 91);
            this.viewSwitchStateButton.Name = "viewSwitchStateButton";
            this.viewSwitchStateButton.Size = new System.Drawing.Size(99, 45);
            this.viewSwitchStateButton.TabIndex = 15;
            this.viewSwitchStateButton.Text = "View Switch State";
            this.viewSwitchStateButton.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(32, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 21);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Control PXI-2535";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
            // SwitchMatrixControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SwitchMatrixControl";
            this.Size = new System.Drawing.Size(280, 155);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button viewSwitchStateButton;
        private System.Windows.Forms.Button configureSwitchButton;
    }
}
