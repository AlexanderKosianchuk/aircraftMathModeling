namespace FDAMM_RA
{
    partial class HardwareDeviceAttachingForm
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
            /*if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);*/
            this.Hide();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HardwareDeviceAttachingForm));
            this.button1_HardwareDeviceAttaching_Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1_HardwareDeviceAttaching_Refresh
            // 
            this.button1_HardwareDeviceAttaching_Refresh.ForeColor = System.Drawing.Color.Black;
            this.button1_HardwareDeviceAttaching_Refresh.Location = new System.Drawing.Point(10, 10);
            this.button1_HardwareDeviceAttaching_Refresh.Name = "button1_HardwareDeviceAttaching_Refresh";
            this.button1_HardwareDeviceAttaching_Refresh.Size = new System.Drawing.Size(280, 50);
            this.button1_HardwareDeviceAttaching_Refresh.TabIndex = 0;
            this.button1_HardwareDeviceAttaching_Refresh.Text = "Refresh";
            this.button1_HardwareDeviceAttaching_Refresh.UseVisualStyleBackColor = true;
            this.button1_HardwareDeviceAttaching_Refresh.Click += new System.EventHandler(this.button1_HardwareDeviceAttaching_Refresh_Click);
            // 
            // HardwareDeviceAttachingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 70);
            this.Controls.Add(this.button1_HardwareDeviceAttaching_Refresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HardwareDeviceAttachingForm";
            this.Text = "HardwareDeviceAttaching";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HardwareDeviceAttachingForm_FormClosing);
            this.Load += new System.EventHandler(this.HardwareDeviceAttaching_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1_HardwareDeviceAttaching_Refresh;
        
    }
}