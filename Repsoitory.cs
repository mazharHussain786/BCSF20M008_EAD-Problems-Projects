using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    public class Repsoitory:IRepository
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        // now we havet to open connection..


        public void InsertData(string firstName, string lastName, string email, string primaryPhoneNumber, string createdBy)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(primaryPhoneNumber) || string.IsNullOrEmpty(createdBy))
            {
                Console.WriteLine("Invalid input. All fields are mandatory.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine(connectionString);
                    string query = "INSERT INTO [dbo].[Table] (FirstName, LastName, Email, PrimaryPhoneNumber, CreatedBy, CreatedOn) VALUES (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @CreatedBy, @CreatedOn)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                        cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                        cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data is inserted Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Insertion failed.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteData(long id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid ID. ID must be greater than 0.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM [dbo].[Table] WHERE ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data is deleted Successfully");
                        }
                        else
                        {
                            Console.WriteLine("No data found for deletion.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting data: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void SelectEmployee(long id)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid ID. ID must be greater than 0.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM [dbo].[Table] WHERE ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("\n--------------------------------------");

                                    Console.WriteLine($"ID: {reader["ID"]} \t FirstName: {reader["FirstName"]} \t LastName: {reader["LastName"]}\n Email: {reader["Email"]}\t PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"]}\n SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"]}\t CreatedBy: {reader["CreatedBy"]}\n CreatedOn: {reader["CreatedOn"]}\t ModifiedBy: {reader["ModifiedBy"]}\t ModifiedOn: {reader["ModifiedOn"]}");

                                    Console.WriteLine("\n--------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No data found for the given ID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error selecting data: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void UpdateEmployee(long id, string firstName, string lastName, string email, string primaryPhoneNumber, string modifiedBy)
        {
            if (id <= 0)
            {
                Console.WriteLine("Invalid ID. ID must be greater than 0.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE [dbo].[Table] SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PrimaryPhoneNumber = @PrimaryPhoneNumber, ModifiedBy = @ModifiedBy, ModifiedOn = GETDATE() WHERE ID = @ID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                        cmd.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Data is updated Successfully");
                        }
                        else
                        {
                            Console.WriteLine("No data found for the given ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating data: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void showAll()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand s1 = new SqlCommand("Select * from [dbo].[Table]", connection);
                SqlDataReader reader = s1.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine($"| ID: {reader["ID"],-4} | FirstName: {reader["FirstName"],-15} | LastName: {reader["LastName"],-15} ");
                    Console.WriteLine($"| Email: {reader["Email"],-20} | PrimaryPhoneNumber: {reader["PrimaryPhoneNumber"],-15} |");
                    Console.WriteLine($"| SecondaryPhoneNumber: {reader["SecondaryPhoneNumber"],-15} | CreatedBy: {reader["CreatedBy"],-15} ");
                    Console.WriteLine($"| CreatedOn: {reader["CreatedOn"],-20:yyyy-MM-dd HH:mm:ss} | ModifiedBy: {reader["ModifiedBy"],-15} ");
                    Console.WriteLine($"| ModifiedOn: {reader["ModifiedOn"],-20:yyyy-MM-dd HH:mm:ss} ");
                    Console.WriteLine("------------------------------------------------------------");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }



        }
    }
}
