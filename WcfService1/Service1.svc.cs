using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            using(SqlConnection con = new SqlConnection(str))
            {
                SqlCommand com = new SqlCommand("Select * from Customers", con);
                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    Customer c = new Customer
                    {
                        Id = (int)r["Id"],
                        Name = r["Name"].ToString(),
                        Surname = r["Surname"].ToString(),
                        YearOfBirth = (int)r["YearOfBirth"],
                    };
                    list.Add(c); 
                }
            }
            return list;
        }

        public List<Order> GetOrders(int id)
        {
            List<Order> list = new List<Order>();
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["myDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(str))
            {
                SqlCommand com = new SqlCommand("Select * from Orders where IdCust=@id", con);
                com.Parameters.Add(new SqlParameter("@id", id));
                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    Order or = new Order
                    {
                        Id = (int)r["Id"],
                        Title = r["Title"].ToString(),
                        IdCust = (int)r["IdCust"],
                        Price = (int)r["Price"],
                        Quant = (int)r["Quant"],
                    };
                    list.Add(or);
                }
            }
            return list;
        }
    }
}
