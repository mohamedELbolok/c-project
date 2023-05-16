using DDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BBL
{
    public class Blayer
    {
        Datalayer dataLayer = new Datalayer();



        #region GET functions
        public  List<Medicine> GetMedicines()
        {
            DataTable dataTable = dataLayer.Getmedicine();
            List<Medicine> med = new List<Medicine>();

            foreach (DataRow medrow in dataTable.Rows)
            {
                Medicine med1 = new Medicine();
                med1.medicineid = medrow["MedicineID"].ToString();
                med1.medicinename = medrow["MedicineName"].ToString();
                med1.companyid = medrow["CompanyID"].ToString();
                med1.price = float.Parse(medrow["Price"].ToString());
                med1.manufactuting = DateTime.Parse(medrow["Manufacturing"].ToString());
                med1.expired = DateTime.Parse(medrow["Expiry"].ToString());
                med1.quantity = int.Parse(medrow["Quntity"].ToString());

                med.Add(med1);

            }
            return med;
        }

        public List<Company> GetCompanies()
        {
            DataTable dataTable = dataLayer.Getcompany();
            List<Company> comp = new List<Company>();

            foreach (DataRow comprow in dataTable.Rows)
            {
                Company comp1 = new Company();
                comp1.companyid = comprow["CompanyID"].ToString();
                comp1.companyname = comprow["CompanyName"].ToString();
                comp1.location = comprow["Location"].ToString();
                comp1.contactnumber = comprow["ContactNumber"].ToString();

                comp.Add(comp1);

            }
            return comp;
        }

        public List<Admin> GetAdmins()
        {
            DataTable dataTable = dataLayer.Getadmin();
            List<Admin> adm = new List<Admin>();

            foreach (DataRow admrow in dataTable.Rows)
            {
                Admin admin1 = new Admin();
                admin1.email = admrow["Email"].ToString();
                admin1.name = admrow["UserName"].ToString();
                admin1.pass = admrow["Pass"].ToString();

                adm.Add(admin1);

            }
            return adm;
        }

        public List<Sales> GetSales()
        {
            DataTable dataTable = dataLayer.Getsales();
            List<Sales> sal = new List<Sales>();

            foreach (DataRow salrow in dataTable.Rows)
            {
                Sales sal1 = new Sales();
                sal1.idsale = int.Parse(salrow["idsale"].ToString());
                sal1.medicineid = salrow["MedicineID"].ToString();
                sal1.salesdate = DateTime.Parse(salrow["SalesDate"].ToString());
                sal1.quantity = float.Parse(salrow["Quantity"].ToString());
                sal1.price = float.Parse(salrow["price"].ToString());
                sal1.totalprice = float.Parse(salrow["Totalprice"].ToString());

                sal.Add(sal1);


            }
            return sal;
        }
        #endregion


        #region insert functions
        public int insertmedicine(string MedicineID, string MedicineName, string CompanyID, float Price, DateTime manufacturing, DateTime expiredate, int quantity)
        {
            int count = dataLayer.insertmedicine(MedicineID, MedicineName, CompanyID, Price, manufacturing, expiredate, quantity);
            return count;
        }

        public int insertcompany(string CompanyID, string CompanyName, string location, string ContactNum)
        {
            int count = dataLayer.insertcompany(CompanyID, CompanyName, location, ContactNum);
            return count;
        }

        public int insertsales(int idsale, string MedicineiD, DateTime SALESDATE, float quantity, float price, float totalprice)
        {
            int count = dataLayer.insertsales(idsale, MedicineiD, SALESDATE, quantity, price, totalprice);
            return count;
        }

        #endregion


        #region update functions
        public int updatemedicine(string MedicineID, string MedicineName, string CompanyID, float Price, DateTime manufacturing, DateTime expiredate, int quantity)
        {
            int count = dataLayer.updatemedicine(MedicineID, MedicineName, CompanyID, Price, manufacturing, expiredate, quantity);
            return count;
        }

        public int updatecompany(string CompanyID, string CompanyName, string location, string ContactNum)
        {
            int count = dataLayer.updatecompany(CompanyID, CompanyName, location, ContactNum);
            return count;
        }

        public int updatesales(int idsale, string MedicineiD, DateTime SALESDATE, float quantity, float price, float totalprice)
        {
            int count = dataLayer.updatesales(idsale, MedicineiD, SALESDATE, quantity, price, totalprice);
            return count;
        }

        public int updateadmin(string email, string pass)
        {
            int count = dataLayer.updateadmins(email, pass);
            return count;
        } 
        #endregion


    }
}

