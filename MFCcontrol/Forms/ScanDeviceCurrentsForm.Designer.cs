namespace MFCcontrol
{
    partial class ScanDeviceCurrentsForm
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
            this.scanCurrentsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scanCurrentsButton
            // 
            this.scanCurrentsButton.Location = new System.Drawing.Point(23, 581);
            this.scanCurrentsButton.Name = "scanCurrentsButton";
            this.scanCurrentsButton.Size = new System.Drawing.Size(85, 48);
            this.scanCurrentsButton.TabIndex = 0;
            this.scanCurrentsButton.Text = "Scan Currents";
            this.scanCurrentsButton.UseVisualStyleBackColor = true;
            this.scanCurrentsButton.Click += new System.EventHandler(this.scanCurrentsButton_Click);
            // 
            // ScanDeviceCurrentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 641);
            this.Controls.Add(this.scanCurrentsButton);
            this.Name = "ScanDeviceCurrentsForm";
            this.Text = "ScanDeviceCurrentsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanDeviceCurrentsForm_FormClosing);
            this.Load += new System.EventHandler(this.ScanDeviceCurrentsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button scanCurrentsButton;
    }
}