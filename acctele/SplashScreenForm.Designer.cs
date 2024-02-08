namespace acctele
{
    partial class SplashScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.startupPlayback = new AxWMPLib.AxWindowsMediaPlayer();
            this.splashVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startupPlayback)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::acctele.Properties.Resources.acctele_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // startupPlayback
            // 
            this.startupPlayback.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.startupPlayback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startupPlayback.Enabled = true;
            this.startupPlayback.Location = new System.Drawing.Point(0, 0);
            this.startupPlayback.Name = "startupPlayback";
            this.startupPlayback.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("startupPlayback.OcxState")));
            this.startupPlayback.Size = new System.Drawing.Size(800, 450);
            this.startupPlayback.TabIndex = 1;
            // 
            // splashVersion
            // 
            this.splashVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.splashVersion.AutoSize = true;
            this.splashVersion.BackColor = System.Drawing.Color.Black;
            this.splashVersion.ForeColor = System.Drawing.Color.Gray;
            this.splashVersion.Location = new System.Drawing.Point(276, 421);
            this.splashVersion.Name = "splashVersion";
            this.splashVersion.Size = new System.Drawing.Size(213, 20);
            this.splashVersion.TabIndex = 2;
            this.splashVersion.Text = "ACCTele Version 1.3.4-alpha";
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splashVersion);
            this.Controls.Add(this.startupPlayback);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreenForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startupPlayback)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private AxWMPLib.AxWindowsMediaPlayer startupPlayback;
        private System.Windows.Forms.Label splashVersion;
    }
}