using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Assignment_5
{
    public  class sqlAdapter:IRepository
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

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
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dataTable = new DataTable())
                            {
                                adapter.Fill(dataTable);

                                Console.WriteLine("------------------------------------------------------------");
                                Console.WriteLine("| ID\t| FirstName\t| LastName\t| Email\t\t\t| PrimaryPhoneNumber\t|");
                                Console.WriteLine("------------------------------------------------------------");

                                foreach (DataRow row in dataTable.Rows)
                                {
                                    Console.WriteLine($"| {row["ID"],-4}\t| {row["FirstName"],-12}\t| {row["LastName"],-12}\t| {row["Email"],-20}\t| {row["PrimaryPhoneNumber"],-17}\t|");
                                }

                                Console.WriteLine("------------------------------------------------------------");
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM [dbo].[Table]";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine("| ID\t| FirstName\t| LastName\t| Email\t\t\t| PrimaryPhoneNumber\t|");
                        Console.WriteLine("------------------------------------------------------------");

                        while (reader.Read())
                        {
                            Console.WriteLine($"| {reader["ID"],-4}\t| {reader["FirstName"],-12}\t| {reader["LastName"],-12}\t| {reader["Email"],-20}\t| {reader["PrimaryPhoneNumber"],-17}\t|");
                        }

                        Console.WriteLine("------------------------------------------------------------");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error showing data: " + ex.Message);
                }
            }
        }

    }
}

