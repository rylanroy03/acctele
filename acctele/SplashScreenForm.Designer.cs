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
            this.splashVersion = new System.Windows.Forms.Label();
            this.startupPlayback = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.startupPlayback)).BeginInit();
            this.SuspendLayout();
            // 
            // splashVersion
            // 
            this.splashVersion.BackColor = System.Drawing.Color.Transparent;
            this.splashVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splashVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.splashVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splashVersion.ForeColor = System.Drawing.Color.Gray;
            this.splashVersion.Location = new System.Drawing.Point(0, 427);
            this.splashVersion.Name = "splashVersion";
            this.splashVersion.Size = new System.Drawing.Size(800, 23);
            this.splashVersion.TabIndex = 2;
            this.splashVersion.Text = "ACCTele Version 1.4.1-alpha REV1. Pre-release build.";
            this.splashVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startupPlayback
            // 
            this.startupPlayback.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.startupPlayback.Enabled = true;
            this.startupPlayback.Location = new System.Drawing.Point(0, 0);
            this.startupPlayback.Margin = new System.Windows.Forms.Padding(0);
            this.startupPlayback.Name = "startupPlayback";
            this.startupPlayback.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("startupPlayback.OcxState")));
            this.startupPlayback.Size = new System.Drawing.Size(800, 460);
            this.startupPlayback.TabIndex = 1;
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splashVersion);
            this.Controls.Add(this.startupPlayback);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreenForm";
            ((System.ComponentModel.ISupportInitialize)(this.startupPlayback)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AxWMPLib.AxWindowsMediaPlayer startupPlayback;
        private System.Windows.Forms.Label splashVersion;
    }
}