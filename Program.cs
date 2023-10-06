// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;
namespace MyApp
{
    class Menu
    {
        public static int a;

        static void Main(string[] args)
        {
            Admin ad = new Admin();
            Ride R1 = new Ride();
            try{
            FileStream g1=new FileStream("Drivers.txt",FileMode.CreateNew);
            g1.Close();
            }
            catch(IOException e)
            {

            }
            ad.ReadFromFile();
            while (true)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1..Book A Ride\n2..Enter As Driver.\n3..Enter As Admin\n-1 Exit");
                Console.WriteLine("------------------------------------------");
                a = Convert.ToInt32(Console.ReadLine());
                if (a == -1)
                {
                    break;
                }
                else if (a == 1)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("\tBook A Ride\t");
                    Console.WriteLine("------------------------------------");

                    string gari = R1.assignPassenger();

                    Location L = R1.getLocation();
                    string IdOfDriver =ad.assignDriver(L, gari);
                    if (!R1.CalcultePrice() || IdOfDriver=="")
                    {
                        if(IdOfDriver=="")
                        {
                            Console.WriteLine("Driver is not availaible ");
                        }
                        else
                        {
                            Console.WriteLine("Location is not valid");
                        }
                        continue;
                    }
                    Console.WriteLine("Nearest Driver : "+IdOfDriver);
                    R1.UpdateRideRecord();
                    FileStream f1 = new FileStream("RideHistory.txt", FileMode.Append);
                    StreamWriter Sw = new StreamWriter(f1);
                    Sw.Write(" Driver Id : " + IdOfDriver);
                    Sw.WriteLine();
                    Sw.Close();
                    f1.Close();
                    Console.WriteLine("Enter the Y if want to COntinue Else Press N ");
                    string ch;
                    ch = Console.ReadLine();
                    if (ch.ToLower() == "y")
                    {

                        Console.WriteLine("Happy_Travel");
                    }
                    else if (ch == "N")
                    {
                        Console.WriteLine("Cancelled");
                    }

                }
                else if (a == 2)
                {
                    Console.WriteLine("----Enter As Driver----");
                    Console.WriteLine("Enter the ID ");
                    string Id = Console.ReadLine();
                    bool check = false;
                    foreach (var variable in ad.Dlist)
                    {
                        if (Id == variable.Driver_ID)
                        {
                            check = true;
                            Console.WriteLine("Hello  " + variable.Driver_ID);
                            while (true)
                            {
                                Console.WriteLine("1..For Update Avaialiblity\n2..For Update Location\n3..For Exit As driver");
                                int input;
                                input = Convert.ToInt32(Console.ReadLine());

                                if (input == 1)
                                {
                                    variable.updateAvailbility();
                                    continue;
                                }
                                else if (input == 2)
                                {
                                    variable.updateLocation();
                                }
                                else if (input == 3)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (check == false)
                    {
                        Console.WriteLine("-------\nId does_not Exists\n---------");
                    }
                }
                else if (a == 3)
                {
                    Console.WriteLine("----Enter As Admin----");
                    Console.WriteLine("1..For Add Driver\n2..Remove Driver\n3..For Update Driver");
                    int a;
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a == 1)
                    {
                        ad.addDriver();
                    }


                    if (a == 2)
                    {
                        Console.WriteLine("Enter the ID : ");
                        string Id = Console.ReadLine();
                        ad.removeDriver(Id);
                    }
                    if (a == 3)
                    {
                        Console.WriteLine("Enter the ID for update Record:  ");
                        string Id = Console.ReadLine();
                        ad.updateDriver(Id);
                    }


                }
            }
        }

    }

}




