using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace medical
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Top -= 3;
            if (label1.Top < 100) { timer1.Stop(); timer2.Start(); }
 
        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Top += 10;
            if (label1.Top < 450) { timer1.Start(); timer2.Stop(); }
        }



        private void timer3_Tick(object sender, EventArgs e)
        {
            panel2.Width += 15;
            if (panel2.Width>=300) 
            {   
                timer3.Stop();
                timer1.Stop();
                timer2.Stop();
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();

            }
        }

    }
}
