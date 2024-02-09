namespace acctele
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.east_console = new System.Windows.Forms.Panel();
            this.mideast_pane = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.west_pane = new System.Windows.Forms.Panel();
            this.midwest_pane = new System.Windows.Forms.Panel();
            this.mid_dock = new System.Windows.Forms.Panel();
            this.dash_pane = new System.Windows.Forms.Panel();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.version = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mideast_pane.SuspendLayout();
            this.mid_dock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // east_console
            // 
            this.east_console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.east_console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.east_console.Location = new System.Drawing.Point(1143, 20);
            this.east_console.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.east_console.Name = "east_console";
            this.east_console.Size = new System.Drawing.Size(249, 710);
            this.east_console.TabIndex = 0;
            // 
            // mideast_pane
            // 
            this.mideast_pane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mideast_pane.AutoSize = true;
            this.mideast_pane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.mideast_pane.Controls.Add(this.button1);
            this.mideast_pane.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mideast_pane.Location = new System.Drawing.Point(674, 0);
            this.mideast_pane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mideast_pane.Name = "mideast_pane";
            this.mideast_pane.Size = new System.Drawing.Size(180, 388);
            this.mideast_pane.TabIndex = 1;
            this.mideast_pane.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open Console";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Console_Click);
            // 
            // west_pane
            // 
            this.west_pane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.west_pane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.west_pane.Location = new System.Drawing.Point(19, 20);
            this.west_pane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.west_pane.Name = "west_pane";
            this.west_pane.Size = new System.Drawing.Size(254, 705);
            this.west_pane.TabIndex = 2;
            // 
            // midwest_pane
            // 
            this.midwest_pane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.midwest_pane.AutoSize = true;
            this.midwest_pane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.midwest_pane.Location = new System.Drawing.Point(0, 0);
            this.midwest_pane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.midwest_pane.Name = "midwest_pane";
            this.midwest_pane.Size = new System.Drawing.Size(180, 388);
            this.midwest_pane.TabIndex = 3;
            // 
            // mid_dock
            // 
            this.mid_dock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mid_dock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.mid_dock.Controls.Add(this.mideast_pane);
            this.mid_dock.Controls.Add(this.dash_pane);
            this.mid_dock.Controls.Add(this.midwest_pane);
            this.mid_dock.Location = new System.Drawing.Point(281, 20);
            this.mid_dock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mid_dock.Name = "mid_dock";
            this.mid_dock.Size = new System.Drawing.Size(854, 388);
            this.mid_dock.TabIndex = 5;
            // 
            // dash_pane
            // 
            this.dash_pane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dash_pane.AutoSize = true;
            this.dash_pane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.dash_pane.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dash_pane.Location = new System.Drawing.Point(189, 0);
            this.dash_pane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dash_pane.Name = "dash_pane";
            this.dash_pane.Size = new System.Drawing.Size(476, 388);
            this.dash_pane.TabIndex = 2;
            // 
            // clock
            // 
            this.clock.Interval = 8;
            // 
            // version
            // 
            this.version.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.Color.Transparent;
            this.version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.version.Location = new System.Drawing.Point(630, 704);
            this.version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(146, 20);
            this.version.TabIndex = 7;
            this.version.Text = "Version 1.4.1-alpha";
            this.version.Click += new System.EventHandler(this.Version_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 453);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1377, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open Console";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Console_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1407, 745);
            this.Controls.Add(this.version);
            this.Controls.Add(this.mid_dock);
            this.Controls.Add(this.west_pane);
            this.Controls.Add(this.east_console);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1429, 801);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "AccTele";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mideast_pane.ResumeLayout(false);
            this.mid_dock.ResumeLayout(false);
            this.mid_dock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel east_console;
        private System.Windows.Forms.Panel mideast_pane;
        private System.Windows.Forms.Panel west_pane;
        private System.Windows.Forms.Panel midwest_pane;
        private System.Windows.Forms.Panel mid_dock;
        private System.Windows.Forms.Panel dash_pane;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}

