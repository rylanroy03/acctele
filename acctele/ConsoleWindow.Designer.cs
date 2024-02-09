namespace acctele
{
    partial class ConsoleWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleWindow));
            this.console_txt1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FreezeCon = new System.Windows.Forms.Button();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.consoletable = new System.Windows.Forms.TableLayoutPanel();
            this.console_txt4 = new System.Windows.Forms.TextBox();
            this.console_txt3 = new System.Windows.Forms.TextBox();
            this.console_txt2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.defocusPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.consoletable.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // console_txt1
            // 
            this.console_txt1.BackColor = System.Drawing.Color.Black;
            this.console_txt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.console_txt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console_txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_txt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.console_txt1.Location = new System.Drawing.Point(0, 0);
            this.console_txt1.Margin = new System.Windows.Forms.Padding(0);
            this.console_txt1.Multiline = true;
            this.console_txt1.Name = "console_txt1";
            this.console_txt1.Size = new System.Drawing.Size(257, 640);
            this.console_txt1.TabIndex = 0;
            this.console_txt1.Text = "Waiting for telemetry input.\r\nPlease begin a session.";
            this.console_txt1.WordWrap = false;
            this.console_txt1.TextChanged += new System.EventHandler(this.Consolewindow_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.FreezeCon);
            this.panel2.Location = new System.Drawing.Point(1046, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 640);
            this.panel2.TabIndex = 1;
            // 
            // FreezeCon
            // 
            this.FreezeCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.FreezeCon.FlatAppearance.BorderSize = 0;
            this.FreezeCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FreezeCon.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FreezeCon.ForeColor = System.Drawing.Color.White;
            this.FreezeCon.Location = new System.Drawing.Point(3, 3);
            this.FreezeCon.Name = "FreezeCon";
            this.FreezeCon.Size = new System.Drawing.Size(194, 40);
            this.FreezeCon.TabIndex = 0;
            this.FreezeCon.Text = "Freeze";
            this.FreezeCon.UseVisualStyleBackColor = false;
            this.FreezeCon.Click += new System.EventHandler(this.FreezeCon_Click);
            // 
            // clock
            // 
            this.clock.Interval = 16;
            this.clock.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // consoletable
            // 
            this.consoletable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoletable.ColumnCount = 4;
            this.consoletable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.consoletable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.consoletable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.consoletable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.consoletable.Controls.Add(this.console_txt4, 3, 0);
            this.consoletable.Controls.Add(this.console_txt3, 2, 0);
            this.consoletable.Controls.Add(this.console_txt2, 1, 0);
            this.consoletable.Controls.Add(this.console_txt1, 0, 0);
            this.consoletable.Location = new System.Drawing.Point(12, 12);
            this.consoletable.Margin = new System.Windows.Forms.Padding(0);
            this.consoletable.Name = "consoletable";
            this.consoletable.RowCount = 1;
            this.consoletable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.consoletable.Size = new System.Drawing.Size(1028, 640);
            this.consoletable.TabIndex = 2;
            // 
            // console_txt4
            // 
            this.console_txt4.BackColor = System.Drawing.Color.Black;
            this.console_txt4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.console_txt4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console_txt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_txt4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.console_txt4.Location = new System.Drawing.Point(771, 0);
            this.console_txt4.Margin = new System.Windows.Forms.Padding(0);
            this.console_txt4.Multiline = true;
            this.console_txt4.Name = "console_txt4";
            this.console_txt4.Size = new System.Drawing.Size(257, 640);
            this.console_txt4.TabIndex = 3;
            this.console_txt4.Text = "Waiting for telemetry input.\r\nPlease begin a session.";
            this.console_txt4.WordWrap = false;
            // 
            // console_txt3
            // 
            this.console_txt3.BackColor = System.Drawing.Color.Black;
            this.console_txt3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.console_txt3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console_txt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_txt3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.console_txt3.Location = new System.Drawing.Point(514, 0);
            this.console_txt3.Margin = new System.Windows.Forms.Padding(0);
            this.console_txt3.Multiline = true;
            this.console_txt3.Name = "console_txt3";
            this.console_txt3.Size = new System.Drawing.Size(257, 640);
            this.console_txt3.TabIndex = 2;
            this.console_txt3.Text = "Waiting for telemetry input.\r\nPlease begin a session.";
            this.console_txt3.WordWrap = false;
            // 
            // console_txt2
            // 
            this.console_txt2.BackColor = System.Drawing.Color.Black;
            this.console_txt2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.console_txt2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console_txt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console_txt2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.console_txt2.Location = new System.Drawing.Point(257, 0);
            this.console_txt2.Margin = new System.Windows.Forms.Padding(0);
            this.console_txt2.Multiline = true;
            this.console_txt2.Name = "console_txt2";
            this.console_txt2.Size = new System.Drawing.Size(257, 640);
            this.console_txt2.TabIndex = 1;
            this.console_txt2.Text = "Waiting for telemetry input.\r\nPlease begin a session.";
            this.console_txt2.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Location = new System.Drawing.Point(3, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 102);
            this.panel1.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.AutoSize = true;
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.numericUpDown1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.numericUpDown1.Location = new System.Drawing.Point(0, 77);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(193, 25);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.pollRate_ValueChanged);
            this.numericUpDown1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pollRate_KeyDown);
            // 
            // defocusPanel
            // 
            this.defocusPanel.Location = new System.Drawing.Point(1030, 655);
            this.defocusPanel.Name = "defocusPanel";
            this.defocusPanel.Size = new System.Drawing.Size(10, 10);
            this.defocusPanel.TabIndex = 3;
            this.defocusPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "Polling Rate (Hz)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 6F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(0, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "1-1000; Scroll or enter value and press return to select";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.defocusPanel);
            this.Controls.Add(this.consoletable);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "ConsoleWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ACC Console";
            this.panel2.ResumeLayout(false);
            this.consoletable.ResumeLayout(false);
            this.consoletable.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox console_txt1;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Button FreezeCon;
        private System.Windows.Forms.TableLayoutPanel consoletable;
        private System.Windows.Forms.TextBox console_txt4;
        private System.Windows.Forms.TextBox console_txt3;
        private System.Windows.Forms.TextBox console_txt2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Panel defocusPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}