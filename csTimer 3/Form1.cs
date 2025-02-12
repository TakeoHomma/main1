using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private Random rand = new Random();

        public csTimer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {
            int a = rand.Next(-6, 7);
            int b = rand.Next(-6, 7);
            int c = rand.Next(-6, 7);
            int d = rand.Next(-6, 7);
            int f = rand.Next(-6, 7);
            int g = rand.Next(-6, 7);
            int h = rand.Next(-6, 7);
            int i = rand.Next(-6, 7);
            int j = rand.Next(-6, 7);
            int k = rand.Next(-6, 7);
            int l = rand.Next(-6, 7);
            int m = rand.Next(-6, 7);
            int n = rand.Next(-6, 7);
            int o = rand.Next(-6, 7);

            label2.Text = "UR" + a.ToString() + " DR" + b.ToString() + " DL" + c.ToString() + " UL" + d.ToString() + " U" + f.ToString() + " R" + g.ToString() + " D" + h.ToString() + " L" + i.ToString() + " ALL" + j.ToString() + " y2" + " U" + k.ToString() + " R" + l.ToString() + " D" + m.ToString() + " L" + n.ToString() + " ALL" + o.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}

