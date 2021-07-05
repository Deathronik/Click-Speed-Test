using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace CPS
{
    public partial class CPS : Form
    {
        public CPS()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        int i = 60,
            tk,
            counter = 1,
            score = 0,
            time = 60,
            pause = 2;
        string c;

        private void button2_Click(object sender, EventArgs e)
        {
            if (counter == 1)
            {
                if (time == 60)
                    c = "1m";
                else if (time == 30)
                    c = "30s";
                else
                    c = "05s";


                score++;
                label1.Text = c;
                label4.Text = $"Your Clicks: {score}";
                button2.Text = "Click! Click! Click!";
                label5.Visible = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                timer1.Interval = 1000;
                timer1.Enabled = true;
                timer1.Start();
                counter++;
            }
            else
            {
                score++;
                label4.Text = $"Your Clicks: {score}";
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            tk = --i;
            TimeSpan span = TimeSpan.FromMinutes(tk);
            string label = span.ToString(@"mm\s");
            label1.Text = label.ToString();
            if (i < 0)
            {
                timer1.Stop();
                label1.Text = "CPS";
                button2.Text = "Restart";
                label5.Visible = true;
                double res = (double)score / (double)time;
                label5.Text = $"Your CPS: {Math.Round(res, 4)}";
                counter = 1;
                i = time;
                score = 0;
                button2.Enabled = false;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                timer2.Interval = 1000;
                timer2.Enabled = true;
                timer2.Start();
            } 
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            i = 30;
            time = i;
            label2.Text = "Clicks in 30 seconds";
            label3.Text = "How fast can you click in 30 seconds?";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            i = 5;
            time = i;
            label2.Text = "Clicks in 5 seconds";
            label3.Text = "How fast can you click in 5 seconds?";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tk = --pause;

            if (pause < 0)
            {
                button2.Enabled = true;
                pause = 2;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            i = 60;
            time = i;
            label2.Text = "Clicks in 1 minute";
            label3.Text = "How fast can you click in 1 minute?";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
