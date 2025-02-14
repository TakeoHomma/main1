using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
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
        public List<string> list4 = new List<string>();
        public bool key = false;
        public int count = 0;

        public void scramble(Label label2)
        {
            int[] skaitlis = new int[14];
            string[] zime = new string[14];

            for (int i = 0; i < 14; i++)
            {
                skaitlis[i] = rand.Next(0, 7);

                if (skaitlis[i] == 0 || skaitlis[i] == 6)
                {
                    zime[i] = "+";
                }
                else
                {
                    int plusvaiminus = rand.Next(0, 2);
                    if (plusvaiminus == 1)
                    {
                        zime[i] = "+";
                    }
                    else
                    {
                        zime[i] = "-";
                    }

                }
            }

            string clock_scramble = "UR" + skaitlis[0] + zime[0] + " DR" + skaitlis[1] + zime[1] + " DL" + skaitlis[2] + zime[2] + " UL" + skaitlis[3] + zime[3] + " U" + skaitlis[4] + zime[4] + " R" + skaitlis[5] + zime[5] + " D" + skaitlis[6] + zime[6] + " L" + skaitlis[7] + zime[7] + " ALL" + skaitlis[8] + zime[8] + " y2" + " U" + skaitlis[9] + zime[9] + " R" + skaitlis[10] + zime[10] + " D" + skaitlis[11] + zime[11] + " L" + skaitlis[12] + zime[12] + " ALL" + skaitlis[13] + zime[13];
            label2.Text = clock_scramble;
        }
        public void Save()
        {
            string solve = label3.Text;
            string scrambleText = label2.Text;
            list1.Insert(0, count + ") " + solve);
            list4.Insert(0, count + ") " + solve + " | " + scrambleText);
            label5.Text = string.Join("\n", list1);
        }
        public void Export()
        {
            if (File.Exists("sessiontimes.txt"))
            {
                list1 = File.ReadAllLines("sessiontimes.txt").ToList();
                count = list1.Count;
                label5.Text = string.Join("\n", list1);
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
        public void invisibility()
        {
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            panel1.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }
        public void visibility()
        {
            label2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            panel1.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
        }

        private void csTimer_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == (char)Keys.Space))
            {
                label3.ForeColor = Color.Red;

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
                    visibility();
                    key = true;

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
                label3.ForeColor = Color.Black;
                if (key == false)
                {
                    stopwatch.Restart();
                    invisibility();
                }
            }
            key = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("sessiontimes.txt", false))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(list1[i].ToString());
                }
            }
            using (StreamWriter writer = new StreamWriter("csTimer.txt", false))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(list4[i].ToString());
                }


            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Export();
        }
    }
}


