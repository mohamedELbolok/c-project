using BBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DGVPrinterHelper;

namespace medical
{
    public partial class Form2 : Form
    {
        Blayer blay = new Blayer();



        public Form2()
        {
            InitializeComponent();
            List<Medicine> med1 = blay.GetMedicines();
            dataGridView1.DataSource = med1;
            List<Company> comp1 =blay.GetCompanies();
            dataGridView2.DataSource = comp1;
            List<Sales> sal1 = blay.GetSales();
            dataGridView3.DataSource = sal1;
        }


        /////////////////////////// insert ///////////////////////////////

        #region insertcompany
        private void button6_Click(object sender, EventArgs e)
        {
            string companyid = textBox12.Text;
            string companyname = textBox10.Text;
            string loc = textBox11.Text;
            string contactnumb = textBox9.Text;

            blay.insertcompany(companyid, companyname, loc, contactnumb);
            List<Company> comp1 = blay.GetCompanies();
            dataGridView2.DataSource = comp1;

        }

        #endregion


        #region insert medicine
        private void button1_Click(object sender, EventArgs e)
        {
            string medicineid = textBox1.Text;
            string medicinename = textBox3.Text;
            string companyid = textBox6.Text;
            float price = float.Parse(textBox5.Text.ToString());
            DateTime manfuc = dateTimePicker1.Value;
            DateTime expired = dateTimePicker2.Value;
            int quantity = int.Parse(textBox4.Text.ToString());


            blay.insertmedicine(medicineid, medicinename, companyid, price, manfuc, expired, quantity);
            List<Medicine> med1 = blay.GetMedicines();
            dataGridView1.DataSource = med1;
        }
        #endregion


        #region insert sales
        private void button9_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBox16.Text);
            string medicineid1 = textBox2.Text;
            DateTime salesdate = dateTimePicker3.Value;
            float quanty = float.Parse(textBox14.Text.ToString());
            float price = float.Parse(textBox17.Text.ToString());
            float totlprice = float.Parse(textBox15.Text.ToString());

            blay.insertsales(ID, medicineid1, salesdate, quanty, price, totlprice);
            List<Sales> sal1 = blay.GetSales();
            dataGridView3.DataSource = sal1;

        }
        #endregion


        /////////////////////////// update ///////////////////////////////


        #region update medicine
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox3.Text = selectedRow.Cells[1].Value.ToString();
            textBox6.Text = selectedRow.Cells[2].Value.ToString();
            textBox5.Text = selectedRow.Cells[3].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(selectedRow.Cells[4].Value.ToString());
            dateTimePicker2.Value = DateTime.Parse(selectedRow.Cells[5].Value.ToString());
            textBox4.Text = selectedRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string medicineid = textBox1.Text;
            string medicinename = textBox3.Text;
            string companyid = textBox6.Text;
            float price = float.Parse(textBox5.Text.ToString());
            DateTime manfuc = dateTimePicker1.Value;
            DateTime expired = dateTimePicker2.Value;
            int quantity = int.Parse(textBox4.Text.ToString());

            dataGridView1.DataSource = null;
            blay.updatemedicine(medicineid, medicinename, companyid, price, manfuc, expired, quantity);
            List<Medicine> med1 = blay.GetMedicines();
            dataGridView1.DataSource = med1;

        }
        #endregion


        #region update company
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[index];
            textBox12.Text = selectedRow.Cells[0].Value.ToString();
            textBox10.Text = selectedRow.Cells[1].Value.ToString();
            textBox11.Text = selectedRow.Cells[2].Value.ToString();
            textBox9.Text = selectedRow.Cells[3].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string companyid = textBox12.Text;
            string companyname = textBox10.Text;
            string loc = textBox11.Text;
            string contactnumb = textBox9.Text;

            dataGridView2.DataSource = null;
            blay.updatecompany(companyid, companyname, loc, contactnumb);
            List<Company> comp1 = blay.GetCompanies();
            dataGridView2.DataSource = comp1;
        }

        #endregion


        #region  update sales
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView3.Rows[index];
            textBox16.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            dateTimePicker3.Value = DateTime.Parse(selectedRow.Cells[2].Value.ToString());
            textBox14.Text = selectedRow.Cells[3].Value.ToString();
            textBox17.Text = selectedRow.Cells[4].Value.ToString();
            textBox15.Text = selectedRow.Cells[5].Value.ToString();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBox16.Text);
            string medicineid1 = textBox2.Text;
            DateTime salesdate = dateTimePicker3.Value;
            float quanty = float.Parse(textBox14.Text.ToString());
            float price = float.Parse(textBox17.Text.ToString());
            float totlprice = float.Parse(textBox15.Text.ToString());

            dataGridView3.DataSource = null;
            blay.updatesales(ID, medicineid1, salesdate, quanty, price, totlprice);
            List<Sales> sal1 = blay.GetSales();
            dataGridView3.DataSource = sal1;
        }
        #endregion


        ////////////////////////////  delete  //////////////////////////////

        #region delete sales
        private void button7_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBox16.Text);

            dataGridView3.DataSource = null;
            blay.deletesales(ID);
            List<Sales> sal1 = blay.GetSales();
            dataGridView3.DataSource = sal1;
        }
        #endregion


        #region delete company
        private void button4_Click(object sender, EventArgs e)
        {
            string companyid = textBox12.Text;

            dataGridView2.DataSource = null;
            blay.deletecompany(companyid);
            List<Company> comp1 = blay.GetCompanies();
            dataGridView2.DataSource = comp1;
        }

        #endregion


        #region delete medicine
        private void button3_Click(object sender, EventArgs e)
        {
            string medicineid = textBox1.Text;


            dataGridView1.DataSource = null;
            blay.deletemedicine(medicineid);
            List<Medicine> med1 = blay.GetMedicines();
            dataGridView1.DataSource = med1;
        } 
        #endregion


        /// //////////////////////////////////////////////////////



        private void existbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void button12_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 fo1 = new Form1();
            fo1.ShowDialog();
        }









        /// /////////////////// reports ///////////////////////////////////

        #region reports
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medical_StoreDataSet2.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.medical_StoreDataSet2.Company);
            // TODO: This line of code loads data into the 'medical_StoreDataSet1.Sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter.Fill(this.medical_StoreDataSet1.Sales);
            // TODO: This line of code loads data into the 'medical_StoreDataSet.Medicine' table. You can move, or remove it, as needed.
            this.medicineTableAdapter.Fill(this.medical_StoreDataSet.Medicine);



            /////////////////// to show name in for 2
            button16.Text = Form1.getname;

        }


        private void button17_Click_1(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Medicine Report";
            printer.SubTitle = string.Format(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "................";
            printer.FooterSpacing = 10;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView6);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Sales Report";
            printer.SubTitle = string.Format(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true; 
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "................";
            printer.FooterSpacing = 10;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView5);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Company Report";
            printer.SubTitle = string.Format(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt"));
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "................";
            printer.FooterSpacing = 10;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(dataGridView7);
        }


        #endregion


    }
}
