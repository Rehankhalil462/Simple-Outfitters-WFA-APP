using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Security.Policy;

namespace Outfitters
{
    class DataAccess
    {
        public int InsertintoShirts(string SName, string SDescription, int SPrice)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("dbConnectionString")))
            {
                var value = connection.Execute("insert into Shirts values('" + SName + "', '" + SDescription + "', " + SPrice + ")");
                return value;
            }
        }

        public int InsertintoCustomer(string Cname, string Ccnic, string Caddress, string phone, string sname, string squantity, int payment)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("dbConnectionString")))
            {
                var value = connection.Execute("insert into Customer values('" + Cname + "', '" + Ccnic + "','" + Caddress + "','" + phone + "','" + sname + "','" + squantity + "', '" + payment + "')");
                return value;
            }
        }
        public List<ProductClass> getAllShirts()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("dbConnectionString")))
            {
                var value = connection.Query<ProductClass>("select SName, SDescription, SPrice,SName from Shirts").ToList();
                return value;
            }

        }
        public List<CustomerClass> getallCustomers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("dbConnectionString")))
            {
                var value = connection.Query<CustomerClass>("select Cname,Caddress,Ccnic,Cphone,sname,squantity,payment from Customer").ToList();
                return value;
            }

        }
    }
}
