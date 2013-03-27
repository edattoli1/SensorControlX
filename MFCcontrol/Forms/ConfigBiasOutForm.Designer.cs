namespace MFCcontrol
{
    partial class ConfigBiasOutForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vgsAOaddressTextbox = new System.Windows.Forms.TextBox();
            this.vdsAOaddressTextbox = new System.Windows.Forms.TextBox();
            this.saveConfigBiasForm = new System.Windows.Forms.Button();
            this.cancelConfigBiasForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vds DAQ AO Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vgs DAQ AO Address";
            // 
            // vgsAOaddressTextbox
            // 
            this.vgsAOaddressTextbox.Location = new System.Drawing.Point(243, 117);
            this.vgsAOaddressTextbox.Name = "vgsAOaddressTextbox";
            this.vgsAOaddressTextbox.Size = new System.Drawing.Size(211, 22);
            this.vgsAOaddressTextbox.TabIndex = 2;
            // 
            // vdsAOaddressTextbox
            // 
            this.vdsAOaddressTextbox.Location = new System.Drawing.Point(243, 69);
            this.vdsAOaddressTextbox.Name = "vdsAOaddressTextbox";
            this.vdsAOaddressTextbox.Size = new System.Drawing.Size(211, 22);
            this.vdsAOaddressTextbox.TabIndex = 3;
            // 
            // saveConfigBiasForm
            // 
            this.saveConfigBiasForm.Location = new System.Drawing.Point(126, 192);
            this.saveConfigBiasForm.Name = "saveConfigBiasForm";
            this.saveConfigBiasForm.Size = new System.Drawing.Size(130, 43);
            this.saveConfigBiasForm.TabIndex = 4;
            this.saveConfigBiasForm.Text = "Save and Apply Changes";
            this.saveConfigBiasForm.UseVisualStyleBackColor = true;
            this.saveConfigBiasForm.Click += new System.EventHandler(this.saveConfigBiasForm_Click);
            // 
            // cancelConfigBiasForm
            // 
            this.cancelConfigBiasForm.Location = new System.Drawing.Point(306, 202);
            this.cancelConfigBiasForm.Name = "cancelConfigBiasForm";
            this.cancelConfigBiasForm.Size = new System.Drawing.Size(75, 23);
            this.cancelConfigBiasForm.TabIndex = 5;
            this.cancelConfigBiasForm.Text = "Cancel";
            this.cancelConfigBiasForm.UseVisualStyleBackColor = true;
            this.cancelConfigBiasForm.Click += new System.EventHandler(this.cancelConfigBiasForm_Click);
            // 
            // ConfigBiasOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 258);
            this.Controls.Add(this.cancelConfigBiasForm);
            this.Controls.Add(this.saveConfigBiasForm);
            this.Controls.Add(this.vdsAOaddressTextbox);
            this.Controls.Add(this.vgsAOaddressTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConfigBiasOutForm";
            this.Text = "ConfigBiasOutForm";
            this.Load += new System.EventHandler(this.ConfigBiasOutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vgsAOaddressTextbox;
        private System.Windows.Forms.TextBox vdsAOaddressTextbox;
        private System.Windows.Forms.Button saveConfigBiasForm;
        private System.Windows.Forms.Button cancelConfigBiasForm;
    }
}