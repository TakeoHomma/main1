using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace csTimer
{
    public partial class csTimer : Form
    {
        public Random rand = new Random();
        public Stopwatch stopwatch = new Stopwatch();
        public List<string> list1 = new List<string>();
        public List<double> list2 = new List<double>();
        public List<double> list3 = new List<double>();
        public bool key = false;
        public int count = 0;

        public void scramble(Label label2)
        {
            int a = rand.Next(-5, 7);
            int b = rand.Next(-5, 7);
            int c = rand.Next(-5, 7);
            int d = rand.Next(-5, 7);
            int f = rand.Next(-5, 7);
            int g = rand.Next(-5, 7);
            int h = rand.Next(-5, 7);
            int i = rand.Next(-5, 7);
            int j = rand.Next(-5, 7);
            int k = rand.Next(-5, 7);
            int l = rand.Next(-5, 7);
            int m = rand.Next(-5, 7);
            int n = rand.Next(-5, 7);
            int o = rand.Next(-5, 7);

            label2.Text = "UR" + a.ToString() + " DR" + b.ToString() + " DL" + c.ToString() + " UL" + d.ToString() + " U" + f.ToString() + " R" + g.ToString() + " D" + h.ToString() + " L" + i.ToString() + " ALL" + j.ToString() + " y2" + " U" + k.ToString() + " R" + l.ToString() + " D" + m.ToString() + " L" + n.ToString() + " ALL" + o.ToString();
        }
        public void Save()
        {
            string solve = label3.Text;
            list1.Insert(0, count + ") " + solve);
            label5.Text = string.Join("\n", list1);
            if (list1.Count >= 10)
            {
                list1.RemoveAt(9);
            }
        }
        public csTimer()
        {
        InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            scramble(label2);


        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time = stopwatch.Elapsed;
            label3.Text = time.Minutes.ToString() + ":" + time.Seconds.ToString("D2") + "." + (time.Milliseconds / 10).ToString("D2");
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void mo3()
        {
            if (list1.Count >= 3)
            {

                if (list2.Count > 3)
                {
                    list2.RemoveAt(list2.Count - 1);
                }
                double average = list2.Average() / 1000.0;
                label7.Text = "mo3: " + average.ToString("F2");
            }
        }

        private void ao5()
        {
            if (list3.Count >= 5)
            {
                var five = list3.Take(5).ToList();
                five.Sort();
                var three = five.Skip(1).Take(3).ToList();

                double average2 = three.Average() / 1000.0;
                label8.Text = "ao5: " + average2.ToString("F2");

                if (list3.Count > 5)
                {
                    list3.RemoveAt(list3.Count - 1);
                } 
            }
        }

        private void csTimer_KeyDown(object sender, KeyEventArgs e)
        {
            if (key)
            {
                return;
            }

            if ((e.KeyValue == (char)Keys.Space)) {
                key = true;
                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                    timer1_Tick(null, null); // Updating the timer
                    count++;
                    Save();
                    var timeTaken = stopwatch.ElapsedMilliseconds;
                    list2.Insert(0, timeTaken);
                    list3.Insert(0, timeTaken);
                    mo3();
                    ao5();
                    scramble(label2);
                }
                else
                {
                    if ((e.KeyValue == (char)Keys.Space))
                    {
                        stopwatch.Restart();

                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            scramble(label2);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void csTimer_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == (char)Keys.Space))
            {
                key = false;
            }
        }
    }
}

