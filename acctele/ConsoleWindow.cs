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
            numericUpDown1.ValueChanged += pollRate_ValueChanged;
            numericUpDown1.KeyDown += pollRate_KeyDown;

        }

        // Init Vars
        bool freezeVal = false;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Memory_reader reader = new Memory_reader();
            string[] teleVals = reader.ReadFromSharedMemory();
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

        
        private void pollRate_ValueChanged(object sender, EventArgs e)
        {
            pollRate = 1000 / (int)numericUpDown1.Value;
            clock.Interval = pollRate;
        }

        private void pollRate_KeyDown(object sender, KeyEventArgs e)
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

    }
}
