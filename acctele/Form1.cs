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
            datetime.Text = DateTime.Now.ToString();

            Memory_reader reader = new Memory_reader();
            string[] teleVals = reader.ReadFromSharedMemory();
            if (freezeVal != true)
            {

                tele_box.Text = string.Join(Environment.NewLine, teleVals);
            }
        }



        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Tele_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void Copy_con_Click(object sender, EventArgs e)
        {
            Memory_reader reader = new Memory_reader();
            string[] teleVals = reader.ReadFromSharedMemory();

            if (teleVals != null)
            {
                Clipboard.SetText(string.Join(Environment.NewLine, teleVals));
                string message = $"Following values copied to clipboard:\n{string.Join(Environment.NewLine, teleVals)}";
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Nothing copied to clipboard.");
            }
        }

        bool freezeVal = false;
        private void FreezeCon_Click(object sender, EventArgs e)
        {
            
            if (freezeVal != true)
            {
                freezeVal = true;
                FreezeCon.Text = ("Resume");
                var (canScroll, _) = ScrollAllow();
                if (canScroll == true)
                {
                    tele_box.ScrollBars = ScrollBars.Vertical;
                }     
            }
            else
            {
                freezeVal = false;
                FreezeCon.Text = ("Freeze");
                tele_box.ScrollBars = ScrollBars.None;
            }
        }

        private void Tele_box_SizeChanged(object sender, EventArgs e)
        {
            var (canScroll, _) = ScrollAllow();
            if (canScroll == true && freezeVal == true)
            {
                tele_box.ScrollBars = ScrollBars.Vertical;
            }
            else
            {
                tele_box.ScrollBars = ScrollBars.None;
            }
        }

        private (bool canScroll, int tLength) ScrollAllow()
        {
            Memory_reader reader = new Memory_reader();
            string[] teleVals = reader.ReadFromSharedMemory();
            int tLength = teleVals.Length * 16;
            if (this.ClientSize.Height < tLength)
            {
                bool canScroll = true;
                return (canScroll, tLength);
            }
            else
            {
                bool canScroll = false;
                return (canScroll, tLength);
            }
        }

        private void Version_Click(object sender, EventArgs e)
        {

        }
    }
}
