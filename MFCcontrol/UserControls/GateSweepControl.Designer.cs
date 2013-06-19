namespace MFCcontrol.UserControls
{
    partial class GateSweepControl
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
            this.label7 = new System.Windows.Forms.Label();
            this.enableGateCheckBox = new System.Windows.Forms.CheckBox();
            this.lowSweepUpDown = new System.Windows.Forms.NumericUpDown();
            this.hiSweepUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.manSetUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stepSweepUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lowSweepUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiSweepUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manSetUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepSweepUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "GATE SWEEP";
            // 
            // enableGateCheckBox
            // 
            this.enableGateCheckBox.AutoSize = true;
            this.enableGateCheckBox.Location = new System.Drawing.Point(11, 46);
            this.enableGateCheckBox.Name = "enableGateCheckBox";
            this.enableGateCheckBox.Size = new System.Drawing.Size(71, 21);
            this.enableGateCheckBox.TabIndex = 24;
            this.enableGateCheckBox.Text = "Enable";
            this.enableGateCheckBox.UseVisualStyleBackColor = true;
            this.enableGateCheckBox.CheckedChanged += new System.EventHandler(this.enableGateCheckBox_CheckedChanged);
            // 
            // lowSweepUpDown
            // 
            this.lowSweepUpDown.DecimalPlaces = 2;
            this.lowSweepUpDown.Enabled = false;
            this.lowSweepUpDown.Location = new System.Drawing.Point(48, 78);
            this.lowSweepUpDown.Maximum = new decimal(new int[] {
            102,
            0,
            0,
            0});
            this.lowSweepUpDown.Minimum = new decimal(new int[] {
            102,
            0,
            0,
            -2147483648});
            this.lowSweepUpDown.Name = "lowSweepUpDown";
            this.lowSweepUpDown.Size = new System.Drawing.Size(50, 22);
            this.lowSweepUpDown.TabIndex = 25;
            // 
            // hiSweepUpDown
            // 
            this.hiSweepUpDown.DecimalPlaces = 2;
            this.hiSweepUpDown.Enabled = false;
            this.hiSweepUpDown.Location = new System.Drawing.Point(48, 118);
            this.hiSweepUpDown.Maximum = new decimal(new int[] {
            102,
            0,
            0,
            0});
            this.hiSweepUpDown.Minimum = new decimal(new int[] {
            102,
            0,
            0,
            -2147483648});
            this.hiSweepUpDown.Name = "hiSweepUpDown";
            this.hiSweepUpDown.Size = new System.Drawing.Size(53, 22);
            this.hiSweepUpDown.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Low";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "High";
            // 
            // manSetUpDown
            // 
            this.manSetUpDown.DecimalPlaces = 2;
            this.manSetUpDown.Enabled = false;
            this.manSetUpDown.Location = new System.Drawing.Point(173, 44);
            this.manSetUpDown.Maximum = new decimal(new int[] {
            102,
            0,
            0,
            0});
            this.manSetUpDown.Minimum = new decimal(new int[] {
            102,
            0,
            0,
            -2147483648});
            this.manSetUpDown.Name = "manSetUpDown";
            this.manSetUpDown.Size = new System.Drawing.Size(58, 22);
            this.manSetUpDown.TabIndex = 29;
            this.manSetUpDown.ValueChanged += new System.EventHandler(this.manSetUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "Manual Set";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.stepSweepUpDown);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.manSetUpDown);
            this.panel1.Controls.Add(this.enableGateCheckBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lowSweepUpDown);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.hiSweepUpDown);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 154);
            this.panel1.TabIndex = 31;
            // 
            // stepSweepUpDown
            // 
            this.stepSweepUpDown.DecimalPlaces = 3;
            this.stepSweepUpDown.Enabled = false;
            this.stepSweepUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.stepSweepUpDown.Location = new System.Drawing.Point(164, 99);
            this.stepSweepUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.stepSweepUpDown.Name = "stepSweepUpDown";
            this.stepSweepUpDown.Size = new System.Drawing.Size(61, 22);
            this.stepSweepUpDown.TabIndex = 31;
            this.stepSweepUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "Step";
            // 
            // GateSweepControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "GateSweepControl";
            this.Size = new System.Drawing.Size(255, 162);
            this.Load += new System.EventHandler(this.GateSweepControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lowSweepUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiSweepUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manSetUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepSweepUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.NumericUpDown lowSweepUpDown;
        internal System.Windows.Forms.NumericUpDown hiSweepUpDown;
        internal System.Windows.Forms.NumericUpDown manSetUpDown;
        internal System.Windows.Forms.NumericUpDown stepSweepUpDown;
        public System.Windows.Forms.CheckBox enableGateCheckBox;
    }
}
