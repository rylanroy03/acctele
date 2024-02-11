using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace acctele
{
    public partial class ConsoleWindow : Form
    {
        public int pollRate = 8;
        public ConsoleWindow()
        {
            InitializeComponent();
            
            clock.Interval = pollRate;
            clock.Enabled = true;
            clock.Tick += Timer1_Tick;
            numericUpDown1.ValueChanged += PollRate_ValueChanged;
            numericUpDown1.KeyDown += PollRate_KeyDown;

            console_txt1.MouseWheel += Console_MouseWheel;
            console_txt2.MouseWheel += Console_MouseWheel;
            console_txt3.MouseWheel += Console_MouseWheel;
            console_txt4.MouseWheel += Console_MouseWheel;
        }

        // Init Vars
        bool freezeVal = false;
        public string telemetryname = "acpmf_physics";
        public int telemetrylen = 90;
        public bool mouseOver1 = false;
        public bool mouseOver2 = false;
        public bool mouseOver3 = false;
        public bool mouseOver4 = false;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Memory_reader reader = new Memory_reader();
            string[] teleVals = reader.ReadFromSharedMemory(telemetryname, telemetrylen);
            if (freezeVal != true)
            {
                int maxRows = GetMaxRows();

                // Split the string array from index 0 to maxRows
                string[] firstChunk = teleVals.Take(maxRows).ToArray();
                string[] secondChunk = teleVals.Skip(maxRows).ToArray();
                console_txt1.Text = string.Join(Environment.NewLine, firstChunk);

                if (secondChunk.Length > 0) 
                {
                    string[] secondPrint = secondChunk.Take(maxRows).ToArray();
                    string[] thirdChunk = secondChunk.Skip(maxRows).ToArray();
                    console_txt2.Text = string.Join(Environment.NewLine, secondPrint);

                    if (thirdChunk.Length > 0)
                    {
                        string[] thirdPrint = thirdChunk.Take(maxRows).ToArray();
                        string[] fourthChunk = thirdChunk.Skip(maxRows).ToArray();
                        console_txt3.Text = string.Join(Environment.NewLine, thirdPrint);

                        if (fourthChunk.Length > 0)
                        {
                            console_txt4.Text = string.Join(Environment.NewLine, fourthChunk);
                        }
                        else
                        {
                            console_txt4.Clear();
                        }
                    }
                    else
                    {
                        console_txt3.Clear();
                        console_txt4.Clear();
                    }
                }
                else
                {
                    console_txt2.Clear();
                    console_txt3.Clear();
                    console_txt4.Clear();
                }

            }
        }


        private void FreezeCon_Click(object sender, EventArgs e)
        {

            if (freezeVal != true)
            {
                freezeVal = true;
                FreezeCon.Text = ("Resume");
            }
            else
            {
                freezeVal = false;
                FreezeCon.Text = ("Freeze");
            }
        }

        private void Consolewindow_TextChanged(object sender, EventArgs e)
        {

        }

        private int GetMaxRows()
        {
            int consoleHeight = console_txt1.Height;
            int fontHeight = console_txt1.Font.Height;
            int maxRows = (consoleHeight / fontHeight) - 2;
            return maxRows;
        }

        
        private void PollRate_ValueChanged(object sender, EventArgs e)
        {
            pollRate = 1000 / (int)numericUpDown1.Value;
            clock.Interval = pollRate;
        }

        private void PollRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                RemoveFocus();
            }
        }
        private void RemoveFocus()
        {
            this.Focus();
        }

        private void ShowPhysicsCon(object sender, EventArgs e)
        {
            telemetryname = "acpmf_physics";
            telemetrylen = 90;
        }

        private void ShowGraphicCon(object sender, EventArgs e)
        {
            telemetryname = "acpmf_graphics";
            telemetrylen = 360;
        }
        private void ShowStaticCon(object sender, EventArgs e)
        {
            telemetryname = "acpmf_static";
            telemetrylen = 360;
        }

        private void Console_MouseWheel(object sender, MouseEventArgs e)
        {
            if (mouseOver1 == true || mouseOver2 == true || mouseOver3 == true || mouseOver4 == true)
            {
                // Adjust the font size based on the mouse wheel delta
                int fontSizeIncrement = e.Delta > 0 ? 1 : -1;
                ChangeFontSize(console_txt1, fontSizeIncrement);
                ChangeFontSize(console_txt2, fontSizeIncrement);
                ChangeFontSize(console_txt3, fontSizeIncrement);
                ChangeFontSize(console_txt4, fontSizeIncrement);

            }
        }

        private void ChangeFontSize(TextBox textBox, int increment)
        {
            // Adjust the font size of the TextBox
            int newFontSize = Math.Max(1, (int)textBox.Font.Size + increment);
            if (newFontSize > 4 && newFontSize < 20)
            {
                textBox.Font = new Font(textBox.Font.FontFamily, newFontSize);
            }
        }

        private void Txt1_Enter(object sender, EventArgs e)
        {
            mouseOver1 = true;
        }

        private void Txt1_Leave(object sender, EventArgs e)
        {
            mouseOver1 = false;
        }
        private void Txt2_Enter(object sender, EventArgs e)
        {
            mouseOver2 = true;
        }

        private void Txt2_Leave(object sender, EventArgs e)
        {
            mouseOver2 = false;
        }
        private void Txt3_Enter(object sender, EventArgs e)
        {
            mouseOver3 = true;
        }

        private void Txt3_Leave(object sender, EventArgs e)
        {
            mouseOver3 = false;
        }
        private void Txt4_Enter(object sender, EventArgs e)
        {
            mouseOver4 = true;
        }

        private void Txt4_Leave(object sender, EventArgs e)
        {
            mouseOver4 = false;
        }


    }
}
