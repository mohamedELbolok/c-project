using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DDL
{
    public class Datalayer
    {
        
        SqlCommand sqlcommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        SqlConnection sqlconnection;



        public Datalayer() 
        {
            sqlconnection = new SqlConnection("Data Source=.;Initial Catalog=Medical_Store;Integrated Security=True");
            sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlconnection;
        }



        #region get functions
        public DataTable Getadmin()
        {
            sqlcommand.CommandText = "select * from LoginTable";
            sqlDataAdapter = new SqlDataAdapter(sqlcommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable Getmedicine()
        {
            sqlcommand.CommandText = "select * from Medicine";
            sqlDataAdapter = new SqlDataAdapter(sqlcommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable Getcompany()
        {
            sqlcommand.CommandText = "select * from Company";
            sqlDataAdapter = new SqlDataAdapter(sqlcommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public DataTable Getsales()
        {
            sqlcommand.CommandText = "select * from Sales";
            sqlDataAdapter = new SqlDataAdapter(sqlcommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }
        #endregion



        #region insert functions
        public int insertmedicine(string MedicineID, string MedicineName, string CompanyID, float Price, DateTime manufacturing, DateTime expiredate, int quantity)
        {
            int count;
            sqlcommand.CommandText = $"INSERT INTO [dbo].[Medicine] ([MedicineID],[MedicineName],[CompanyID],[Price],[Manufacturing],[Expiry],[Quntity]) VALUES('{MedicineID}','{MedicineName}','{CompanyID}','{Price}','{manufacturing}','{expiredate}','{quantity}')";
            sqlconnection.Open();
            count = sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            Getmedicine();
            return count;
        }

        public int insertcompany(string CompanyID, string CompanyName, string location, string ContactNum)
        {
            int count;
            sqlcommand.CommandText = $"INSERT INTO [dbo].[Company]([CompanyID],[CompanyName],[Location],[ContactNumber]) VALUES('{CompanyID}','{CompanyName}','{location}','{ContactNum}')";
            sqlconnection.Open();
            count = sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            Getcompany();
            return count;
        }

        public int insertsales(int idsale, string MedicineiD, DateTime SALESDATE, float quantity, float price, float totalprice)
        {
            int count;
            sqlcommand.CommandText = $"INSERT INTO [dbo].[Sales]([idsale],[MedicineID],[SalesDate],[Quantity],[price],[Totalprice]) VALUES('{idsale}','{MedicineiD}','{SALESDATE}','{quantity}','{price}','{totalprice}')";
            sqlconnection.Open();
            count = sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            Getsales();
            return count;
        }

        #endregion



        #region update functions
        public int updatemedicine(string MedicineID, string MedicineName, string CompanyID, float Price, DateTime manufacturing, DateTime expiredate, int quantity)
        {
            int count;
            sqlcommand.CommandText = $"UPDATE [dbo].[Medicine] SET [MedicineID] = '{MedicineID}',[MedicineName] = '{MedicineName}',[CompanyID] = '{CompanyID}',[Price] = '{Price}',[Manufacturing] = '{manufacturing}',[Expiry] = '{expiredate}' ,[Quntity] = '{quantity}' WHERE MedicineID='{MedicineID}' ";
            sqlconnection.Open();
            count = sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            return count;
        }

        public int updatecompany(string CompanyID, string CompanyName, string location, string ContactNum)
        {
            int count;
            sqlcommand.CommandText = $"UPDATE [dbo].[Company] SET [CompanyID] = '{CompanyID}',[CompanyName] = '{CompanyName}',[Location] = '{location}',[ContactNumber] = '{ContactNum}' WHERE [CompanyID]='{CompanyID}' ";
            sqlconnection.Open();
            count = sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            return count;
        }

        public int updatesales(int idsale, string MedicineiD, DateTime SALESDATE, float quantity, float price, float totalprice)
        {
            int count;
            sqlcommand.CommandText = $"UPDATE [dbo].[Sales] SET [idsale]  = '{idsale}',[MedicineID] = '{MedicineiD}',[SalesDate] = '{SALESDATE}',[Quantity] = '{quantity}',[price] = '{price}',[Totalprice] = '{totalprice}' WHERE [idsale]='{idsale}'  ";
            sqlconnection.Open();
            count = sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            return count;
        }

        public int updateadmins(string email, string pass)
        {
            int count;
            sqlcommand.CommandText = $"UPDATE [dbo].[LoginTable] SET [Pass]  = '{pass}' WHERE [Email]='{email}'  ";
            sqlconnection.Open();
            count = sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
            return count;
        } 
        #endregion



    }
}
