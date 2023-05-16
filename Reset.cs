using BBL;
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
    public partial class Reset : Form
    {
        Blayer blayer2= new Blayer();

        public Reset()
        {
            InitializeComponent();
        }



        private void existbutton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            bool check = false;
            List<Admin> adm1 = blayer2.GetAdmins();
            foreach (var item in adm1)
            {
                if (item.email == textBox1.Text && item.pass==textBox2.Text )
                {
                    blayer2.updateadmin(textBox1.Text, textBox3.Text);
                    check = true;
                }

            }
            if (check == false)
            {
                MessageBox.Show("email or password is not valid");

            }
            if (check==true) { MessageBox.Show("sussesful set new password"); }
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();


        }
    }
}
