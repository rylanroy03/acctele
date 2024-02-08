﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acctele
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval = 2000 // wait time on splash
            };
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                this.Close();
            };
            timer.Start();
        }
        private void SplashScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
