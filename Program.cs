using Assignment_5;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Assignment5
{
    class Program
    {


        static void Menu<T>(T repository)
           where T : IRepository
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Insert Employee");
                Console.WriteLine("2. Delete Employee by ID");
                Console.WriteLine("3. Select Employee by ID");
                Console.WriteLine("4. Update Employee by ID");
                Console.WriteLine("5. ShowAllEmployee");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        
                        Console.Write("Enter First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter Primary Phone Number: ");
                        string primaryPhoneNumber = Console.ReadLine();
                        Console.Write("Enter Created By: ");
                        string createdBy = Console.ReadLine();
                        repository.InsertData(firstName, lastName, email, primaryPhoneNumber, createdBy);
                        break;
                    case 2:
                        
                        Console.Write("Enter the ID of the employee to delete: ");
                        long deleteId = long.Parse(Console.ReadLine());
                        repository.DeleteData(deleteId);
                        break;
                    case 3:
                        // Input the ID of the employee to select and call the SelectEmpoloyee method
                        Console.Write("Enter the ID of the employee to select: ");
                        long selectId = long.Parse(Console.ReadLine());
                        repository.SelectEmployee(selectId);
                        break;
                    case 4:
                        // Input the ID of the employee to update and other details, then call the upadetEmploye method
                        Console.Write("Enter the ID of the employee to update: ");
                        long updateId = long.Parse(Console.ReadLine());
                        Console.Write("Enter First Name: ");
                        string updateFirstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string updateLastName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string updateEmail = Console.ReadLine();
                        Console.Write("Enter Primary Phone Number: ");
                        string updatePrimaryPhoneNumber = Console.ReadLine();
                        Console.Write("Enter Modified By: ");
                        string updateModifiedBy = Console.ReadLine();
                        repository.UpdateEmployee(updateId, updateFirstName, updateLastName, updateEmail, updatePrimaryPhoneNumber, updateModifiedBy);
                        break;
                    case 5:
                        repository.showAll();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
           

            while (true)
            {
                int a;
                Console.WriteLine("1. SqlAdapter\n2. SqlReader\n3. Exit\n----------------------\nChoice: ");
                try
                {

                     a = int.Parse(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            
                switch (a)
                {
                    case 1:
                        Menu(new sqlAdapter());
                        break;
                    case 2:
                        Menu(new Repsoitory());
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }


        }
    }

}
