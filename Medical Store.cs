using BBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace medical
{
    
    public partial class Form1 : Form
    {
        Blayer blayer = new Blayer();

        public Form1()
        {
            InitializeComponent();
        }

        public static string name;
        public static string getname 
        {
            get { return name; }
            set { name = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getname=textBox1.Text;

            bool check = false;
            List<Admin> adm1= blayer.GetAdmins();
            foreach (var item in adm1)
            {
                if (item.name == textBox1.Text && item.pass == textBox2.Text)
                {
                    this.Hide();
                    Splash f3 = new Splash();
                    f3.Show();

                    check = true;
                }
              
            }
            if (check==false)
            {
                MessageBox.Show("user name or password not valid");

            }

        }



        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        #region show or disappear password
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }


        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        } 
        #endregion




        private void button3_Click(object sender, EventArgs e)
        {

            Reset reset = new Reset();
            reset.Show();
            this.Hide();
        }


    }
}
