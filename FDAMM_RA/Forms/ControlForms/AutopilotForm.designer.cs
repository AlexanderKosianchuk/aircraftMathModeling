namespace FDAMM_RA
{
    partial class AutopilotForm
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
            //if (disposing && (components != null))
            //{
            //    components.Dispose();
            //}
            //base.Dispose(disposing);
            this.Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutopilotForm));
            this.ManeuversChangeHeightLabel = new System.Windows.Forms.Label();
            this.ManeuversChangeHeightTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.executeChangeHeightDuringSim = new System.Windows.Forms.CheckBox();
            this.calcCoefTyteComboBox = new System.Windows.Forms.ComboBox();
            this.ctrlLawComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManeuversChangeHeightLabel
            // 
            this.ManeuversChangeHeightLabel.AutoSize = true;
            this.ManeuversChangeHeightLabel.Location = new System.Drawing.Point(12, 9);
            this.ManeuversChangeHeightLabel.Name = "ManeuversChangeHeightLabel";
            this.ManeuversChangeHeightLabel.Size = new System.Drawing.Size(75, 13);
            this.ManeuversChangeHeightLabel.TabIndex = 0;
            this.ManeuversChangeHeightLabel.Text = "ChangeHeight";
            // 
            // ManeuversChangeHeightTextBox
            // 
            this.ManeuversChangeHeightTextBox.Location = new System.Drawing.Point(12, 26);
            this.ManeuversChangeHeightTextBox.Name = "ManeuversChangeHeightTextBox";
            this.ManeuversChangeHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.ManeuversChangeHeightTextBox.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Calc coefficients";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(40, 147);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(72, 20);
            this.textBox2.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.executeChangeHeightDuringSim);
            this.splitContainer1.Panel1.Controls.Add(this.calcCoefTyteComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.ctrlLawComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.ManeuversChangeHeightLabel);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.ManeuversChangeHeightTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(300, 300);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 7;
            // 
            // executeChangeHeightDuringSim
            // 
            this.executeChangeHeightDuringSim.AutoSize = true;
            this.executeChangeHeightDuringSim.Location = new System.Drawing.Point(12, 173);
            this.executeChangeHeightDuringSim.Name = "executeChangeHeightDuringSim";
            this.executeChangeHeightDuringSim.Size = new System.Drawing.Size(217, 17);
            this.executeChangeHeightDuringSim.TabIndex = 11;
            this.executeChangeHeightDuringSim.Text = "Execute change height during simulation";
            this.executeChangeHeightDuringSim.UseVisualStyleBackColor = true;
            this.executeChangeHeightDuringSim.CheckedChanged += new System.EventHandler(this.executeChangeHeightDuringSim_CheckedChanged);
            // 
            // calcCoefTyteComboBox
            // 
            this.calcCoefTyteComboBox.FormattingEnabled = true;
            this.calcCoefTyteComboBox.Items.AddRange(new object[] {
            "analize coef",
            "find coef",
            "get coef"});
            this.calcCoefTyteComboBox.Location = new System.Drawing.Point(12, 79);
            this.calcCoefTyteComboBox.Name = "calcCoefTyteComboBox";
            this.calcCoefTyteComboBox.Size = new System.Drawing.Size(243, 21);
            this.calcCoefTyteComboBox.TabIndex = 10;
            this.calcCoefTyteComboBox.Text = "analize coef";
            // 
            // ctrlLawComboBox
            // 
            this.ctrlLawComboBox.FormattingEnabled = true;
            this.ctrlLawComboBox.Items.AddRange(new object[] {
            "kH*delH + kdH*dH",
            "kH*delH + kdH*dH + kWz * Wz",
            "kH*delH + kdH*dH + kTETHA*TETHA",
            "kH*delH + kdH*dH + kTETHA*TETHA + kWz*Wz"});
            this.ctrlLawComboBox.Location = new System.Drawing.Point(12, 52);
            this.ctrlLawComboBox.Name = "ctrlLawComboBox";
            this.ctrlLawComboBox.Size = new System.Drawing.Size(243, 21);
            this.ctrlLawComboBox.TabIndex = 9;
            this.ctrlLawComboBox.Text = "kH*delH + kdH*dH";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "kdH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "kH";
            // 
            // AutopilotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.splitContainer1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutopilotForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "Autopilot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutopilotForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ManeuversChangeHeightLabel;
        private System.Windows.Forms.TextBox ManeuversChangeHeightTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox ctrlLawComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox calcCoefTyteComboBox;
        public System.Windows.Forms.CheckBox executeChangeHeightDuringSim;




    }
}