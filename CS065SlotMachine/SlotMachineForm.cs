using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS065SlotMachine
{
    public partial class SlotMachineForm : Form
    {
        public SlotMachineForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Now - casStop;
            label1.Text = t.ToString();
            double v = ((1 / Math.Pow((t.TotalMilliseconds / 1000) + 0.05, 0.2) - 0.63) * 25.1);
            v = (v <= 1) ? 1 : v;
            label2.Text = v.ToString();
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    c.Top += (int)v;
                    if (c.Top > 445)
                    {
                        c.Top = -105;
                    }
                }
            }
        }
        bool tocit = false;
        DateTime casStop = DateTime.Now;
        private void startStopButton_Click(object sender, EventArgs e)
        {
            if (startStopButton.Text == "Start")
            {
                tocit = true;
                startStopButton.Text = "Stop";
            }
            else                                    // platí pro "Stop"
            {
                tocit = false;
                startStopButton.Text = "Start";
                casStop = DateTime.Now;
            }
        }
    }
}
