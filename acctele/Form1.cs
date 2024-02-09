using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace acctele
{



    public partial class Form1 : Form
    {
        


        public Form1()
        {
            InitializeComponent();

            clock.Interval = 8;
            clock.Enabled = true;
            clock.Tick += Timer1_Tick;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Resize += Form1_Resize; // Subscribes to resize event
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int thresholdHeight = (int)(this.ClientSize.Height * 0.4);
            if (this.ClientSize.Height > thresholdHeight)
            {
                mid_dock.Height = thresholdHeight;
            }
            else
            {
                mid_dock.Height = this.ClientSize.Height;
            }

        }
        
        private void Form1_Resize(object sender, EventArgs e) 
        {
            int thresholdHeight = (int)(this.ClientSize.Height * 0.4); // main dock scale
            if (this.ClientSize.Height > thresholdHeight)
            {
                mid_dock.Height = thresholdHeight;
            }
            else
            {
                mid_dock.Height = this.ClientSize.Height;
            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }



        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Version_Click(object sender, EventArgs e)
        {

        }

        private void Console_Click(object sender, EventArgs e)
        {
            ConsoleWindow ConsoleWindow = new ConsoleWindow();
            ConsoleWindow.Show();
        }
    }
}
