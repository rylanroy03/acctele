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
            this.east_console = new System.Windows.Forms.Panel();
            this.tele_box = new System.Windows.Forms.TextBox();
            this.mideast_pane = new System.Windows.Forms.Panel();
            this.west_pane = new System.Windows.Forms.Panel();
            this.midwest_pane = new System.Windows.Forms.Panel();
            this.mid_dock = new System.Windows.Forms.Panel();
            this.dash_pane = new System.Windows.Forms.Panel();
            this.datetime = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.title = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.con_buttons = new System.Windows.Forms.Panel();
            this.FreezeCon = new System.Windows.Forms.Button();
            this.copy_con = new System.Windows.Forms.Button();
            this.east_console.SuspendLayout();
            this.mid_dock.SuspendLayout();
            this.con_buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // east_console
            // 
            this.east_console.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.east_console.BackColor = System.Drawing.Color.Black;
            this.east_console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.east_console.Controls.Add(this.tele_box);
            this.east_console.Location = new System.Drawing.Point(1152, 66);
            this.east_console.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.east_console.Name = "east_console";
            this.east_console.Size = new System.Drawing.Size(240, 608);
            this.east_console.TabIndex = 0;
            // 
            // tele_box
            // 
            this.tele_box.BackColor = System.Drawing.Color.Black;
            this.tele_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tele_box.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tele_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tele_box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tele_box.HideSelection = false;
            this.tele_box.Location = new System.Drawing.Point(0, 0);
            this.tele_box.Multiline = true;
            this.tele_box.Name = "tele_box";
            this.tele_box.ReadOnly = true;
            this.tele_box.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tele_box.Size = new System.Drawing.Size(238, 606);
            this.tele_box.TabIndex = 0;
            this.tele_box.Text = "Waiting for telemetry data...";
            this.tele_box.WordWrap = false;
            this.tele_box.SizeChanged += new System.EventHandler(this.Tele_box_SizeChanged);
            this.tele_box.TextChanged += new System.EventHandler(this.Tele_box_TextChanged);
            // 
            // mideast_pane
            // 
            this.mideast_pane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mideast_pane.AutoSize = true;
            this.mideast_pane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.mideast_pane.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mideast_pane.Location = new System.Drawing.Point(695, 0);
            this.mideast_pane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mideast_pane.Name = "mideast_pane";
            this.mideast_pane.Size = new System.Drawing.Size(180, 342);
            this.mideast_pane.TabIndex = 1;
            this.mideast_pane.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2_Paint);
            // 
            // west_pane
            // 
            this.west_pane.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.west_pane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.west_pane.Location = new System.Drawing.Point(19, 66);
            this.west_pane.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.west_pane.Name = "west_pane";
            this.west_pane.Size = new System.Drawing.Size(241, 659);
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
            this.midwest_pane.Size = new System.Drawing.Size(180, 342);
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
            this.mid_dock.Location = new System.Drawing.Point(268, 66);
            this.mid_dock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mid_dock.Name = "mid_dock";
            this.mid_dock.Size = new System.Drawing.Size(875, 342);
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
            this.dash_pane.Size = new System.Drawing.Size(497, 342);
            this.dash_pane.TabIndex = 2;
            // 
            // datetime
            // 
            this.datetime.AutoSize = true;
            this.datetime.ForeColor = System.Drawing.Color.Gray;
            this.datetime.Location = new System.Drawing.Point(237, 12);
            this.datetime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.datetime.Name = "datetime";
            this.datetime.Size = new System.Drawing.Size(116, 20);
            this.datetime.TabIndex = 0;
            this.datetime.Text = "Loading Time...";
            this.datetime.Click += new System.EventHandler(this.Label1_Click);
            // 
            // clock
            // 
            this.clock.Interval = 8;
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.title.Location = new System.Drawing.Point(19, 7);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(210, 49);
            this.title.TabIndex = 6;
            this.title.Text = "ACCTele";
            // 
            // version
            // 
            this.version.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.version.AutoSize = true;
            this.version.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.version.Location = new System.Drawing.Point(237, 32);
            this.version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(98, 20);
            this.version.TabIndex = 7;
            this.version.Text = "Version 1.3a";
            this.version.Click += new System.EventHandler(this.Version_Click);
            // 
            // con_buttons
            // 
            this.con_buttons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.con_buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.con_buttons.Controls.Add(this.FreezeCon);
            this.con_buttons.Controls.Add(this.copy_con);
            this.con_buttons.Location = new System.Drawing.Point(1152, 682);
            this.con_buttons.Name = "con_buttons";
            this.con_buttons.Size = new System.Drawing.Size(240, 42);
            this.con_buttons.TabIndex = 8;
            // 
            // FreezeCon
            // 
            this.FreezeCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.FreezeCon.FlatAppearance.BorderSize = 0;
            this.FreezeCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FreezeCon.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FreezeCon.ForeColor = System.Drawing.Color.White;
            this.FreezeCon.Location = new System.Drawing.Point(123, 4);
            this.FreezeCon.Name = "FreezeCon";
            this.FreezeCon.Size = new System.Drawing.Size(113, 35);
            this.FreezeCon.TabIndex = 1;
            this.FreezeCon.Text = "Freeze";
            this.FreezeCon.UseVisualStyleBackColor = false;
            this.FreezeCon.Click += new System.EventHandler(this.FreezeCon_Click);
            // 
            // copy_con
            // 
            this.copy_con.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(150)))));
            this.copy_con.FlatAppearance.BorderSize = 0;
            this.copy_con.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copy_con.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copy_con.ForeColor = System.Drawing.Color.White;
            this.copy_con.Location = new System.Drawing.Point(4, 4);
            this.copy_con.Name = "copy_con";
            this.copy_con.Size = new System.Drawing.Size(113, 35);
            this.copy_con.TabIndex = 0;
            this.copy_con.Text = "Copy Text";
            this.copy_con.UseVisualStyleBackColor = false;
            this.copy_con.Click += new System.EventHandler(this.Copy_con_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1407, 745);
            this.Controls.Add(this.con_buttons);
            this.Controls.Add(this.version);
            this.Controls.Add(this.title);
            this.Controls.Add(this.datetime);
            this.Controls.Add(this.mid_dock);
            this.Controls.Add(this.west_pane);
            this.Controls.Add(this.east_console);
            this.HelpButton = true;
            this.MinimumSize = new System.Drawing.Size(1429, 801);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "AccTele";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.east_console.ResumeLayout(false);
            this.east_console.PerformLayout();
            this.mid_dock.ResumeLayout(false);
            this.mid_dock.PerformLayout();
            this.con_buttons.ResumeLayout(false);
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
        private System.Windows.Forms.Label datetime;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.TextBox tele_box;
        private System.Windows.Forms.Panel con_buttons;
        private System.Windows.Forms.Button FreezeCon;
        private System.Windows.Forms.Button copy_con;
    }
}

