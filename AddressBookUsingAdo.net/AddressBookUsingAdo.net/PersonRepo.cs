using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAdo.net;

    public class PersonRepo
{
    public static string ConnectionString = (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBook_Services;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    SqlConnection Connection = new SqlConnection(ConnectionString);
    public bool AddPersonDetails(PersonModel model)
    {
        try
        {
            PersonModel person = new PersonModel();
            using (this.Connection)
            {
                SqlCommand cmd = new SqlCommand("spAddPerson", this.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@first_name", model.First_Name);
                cmd.Parameters.AddWithValue("@last_name", model.Last_Name);
                cmd.Parameters.AddWithValue("@address", model.Address);
                cmd.Parameters.AddWithValue("@City", model.City);
                cmd.Parameters.AddWithValue("@state", model.State);
                cmd.Parameters.AddWithValue("@zip", model.Zip);
                cmd.Parameters.AddWithValue("@phone_num", model.Phone_Num);
                cmd.Parameters.AddWithValue("@type", model.Type);
                cmd.Parameters.AddWithValue("@email", model.Email);
                this.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("No Data Found");
                    return false;
                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        finally
        {
            this.Connection.Close();
        }
        return true;
    }

    public bool GetPersonDetails()
    {
        try
        {
            PersonModel model = new PersonModel();
            SqlCommand cmd = new SqlCommand("spDetails", this.Connection);
            cmd.CommandType = System.Data.CommandType.Text;
            this.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    model.First_Name = Convert.ToString(reader["first_name"]);
                    model.Address = Convert.ToString(reader["address"]);
                    Console.WriteLine(model.First_Name + " " + model.Address);
                }
            }
            else
            {
                Console.WriteLine("No data Found");
                return false;
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        finally
        {
            this.Connection.Close();

        }
        return true;
    }
    public bool GetSelectedPersonDetails()
    {
        try
        {
            PersonModel model = new PersonModel();
            string query = @"Select*from Addressbook where first_name='sudhanshu'";
            SqlCommand cmd = new SqlCommand(query, this.Connection);
            this.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    model.First_Name = Convert.ToString(reader["first_name"]);
                    model.Address = Convert.ToString(reader["address"]);
                    Console.WriteLine(model.First_Name + " " + model.Address);
                }
            }
            else
            {
                Console.WriteLine("No data Found");
                return false;
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        finally
        {
            this.Connection.Close();

        }
        return true;
    }
}

