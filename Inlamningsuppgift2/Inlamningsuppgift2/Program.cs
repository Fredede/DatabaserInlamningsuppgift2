using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to create a new customer? Press 1");
            Console.WriteLine("Do you want to create a new product? Press 2");
            Console.WriteLine("Do you want to update a products price? Press 3");
            int selection = int.Parse(Console.ReadLine());

            if (selection == 1)
            {
                CreateCustomer();
            }
            else if (selection == 2)
            {
                CreateProduct();
            }
            else if (selection == 3)
            {
                UpdatePrice();
            }
            else
            {
                Console.WriteLine("Please enter a valid number");
            }
 
            Console.WriteLine("Press Enter to exit the application");
            Console.ReadLine();          
        }

        public static void CreateCustomer()
        {
            Console.WriteLine("Enter your customer ID:");
            string customerId = Console.ReadLine();
            Console.WriteLine("Enter your company name:");
            string companyName = Console.ReadLine();
            Console.WriteLine("Enter your contact name:");
            string contactName = Console.ReadLine();
            Console.WriteLine("Enter your contact title:");
            string contactTitle = Console.ReadLine();
            Console.WriteLine("Enter your address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your city:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter your region:");
            string region = Console.ReadLine();
            Console.WriteLine("Enter your postal code:");
            string postalCode = Console.ReadLine();
            Console.WriteLine("Enter your country:");
            string country = Console.ReadLine();
            Console.WriteLine("Enter your phone number:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter your fax number:");
            string fax = Console.ReadLine();

            string cns = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;

            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CustomerInsert";
            cmd.Parameters.AddWithValue("@CustomerID", customerId);
            cmd.Parameters.AddWithValue("@CompanyName", companyName);
            cmd.Parameters.AddWithValue("@ContactName", contactName);
            cmd.Parameters.AddWithValue("@ContactTitle", contactTitle);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@City", city);
            cmd.Parameters.AddWithValue("@Region", region);
            cmd.Parameters.AddWithValue("@PostalCode", postalCode);
            cmd.Parameters.AddWithValue("@Country", country);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Fax", fax);
            cmd.ExecuteNonQuery();
            cn.Close();
            Console.WriteLine("A new customer has been created!");
        }

        public static void CreateProduct()
        {
            Console.WriteLine("Enter a product name:");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter a supplier ID:");
            int supplierId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a category ID:");
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity per unit:");
            string quantityPerUnit = Console.ReadLine();
            Console.WriteLine("Enter unit price:");
            decimal unitPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter units in stock:");
            string unitsInStock = Console.ReadLine();
            Console.WriteLine("Enter units on order:");
            string unitsOnOrder = Console.ReadLine();
            Console.WriteLine("Enter reorder level:");
            string reorderLevel = Console.ReadLine();
            Console.WriteLine("Is your product discontinued? Type 'true' or 'false'");
            bool discontinued = bool.Parse(Console.ReadLine());

            string cns = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ProductInsert";
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@SupplierID", supplierId);
            cmd.Parameters.AddWithValue("@CategoryID", categoryId);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock", unitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
            cmd.Parameters.AddWithValue("@Discontinued", discontinued);
            cmd.ExecuteNonQuery();
            cn.Close();
            Console.WriteLine("A new product has been created!");
        }

        public static void UpdatePrice()
        {
            Console.WriteLine("Enter the product ID of the product you want to change the price on:");
            int productId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a new price:");
            decimal unitPrice = decimal.Parse(Console.ReadLine());

            string cns = ConfigurationManager.ConnectionStrings["cns"].ConnectionString;
            SqlConnection cn = new SqlConnection(cns);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateProductPrice";
            cmd.Parameters.AddWithValue("@ProductID", productId);
            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
            cmd.ExecuteNonQuery();
            cn.Close();
            Console.WriteLine("The price of the selected product has been updated!");
        }


    }
}
