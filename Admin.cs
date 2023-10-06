namespace MyApp
{
    class Admin
    {
        public List<Driver> Dlist = new List<Driver>();
        public Driver addDriver()
        {
            Console.WriteLine("-----Add_Driver Function------\nEnter Driver_Name");
            Driver new_Driver = new Driver();
            new_Driver.D_Name = Console.ReadLine();
            Console.WriteLine("Driver_ID: ");
            new_Driver.Driver_ID = Console.ReadLine();
            Console.WriteLine("\nEnter the age : ");
            new_Driver.D_age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Current LOcation :  ");
            new_Driver.D_Curr_loc.setLocation();
            Console.WriteLine("Phone_Number: ");
            new_Driver.D_PhoneNum = Console.ReadLine();
            Console.WriteLine("Address: ");
            new_Driver.D_Name = Console.ReadLine();
            Console.WriteLine("Enter the vehcile\n..Car\n..Bike\n..Rikshaw\n(Makesure Spellings)");
            new_Driver.d_vehicle.Vtype = Console.ReadLine();
            Console.WriteLine("Vehicle_Model :");
            new_Driver.d_vehicle.model = Console.ReadLine();
            Console.WriteLine("Number_Plate : ");
            new_Driver.d_vehicle.license_Plate = Console.ReadLine();
            new_Driver.updateAvailbility();
            Dlist.Add(new_Driver);
            WriteIntoFile();
            return new_Driver;
        }
        public void updateDriver(string ID)
        {
            for (int i = 0; i < Dlist.Count; i++)
            {
                if (Dlist[i].Driver_ID == ID)
                {
                    Console.WriteLine("---------Driver_Found----------");
                    Console.WriteLine("Enter Name : ");
                    string nam = Console.ReadLine();
                    if (nam.Length != 0)
                    {
                        Dlist[i].D_Name = nam;
                    }
                    Console.WriteLine("Enter Age : ");
                    nam = Console.ReadLine();
                    if (nam.Length != 0)
                    {
                        Dlist[i].D_age = Convert.ToInt32(nam);
                    }
                    Console.WriteLine("Enter Adress : ");
                    nam = Console.ReadLine();
                    if (nam.Length != 0)
                    {
                        Dlist[i].D_Adress = nam;
                    }
                    Console.WriteLine("Enter Vehicle_Type : ");
                    nam = (Console.ReadLine());
                    if (nam.Length != 0)
                    {
                        Dlist[i].d_vehicle.Vtype = nam;
                    }
                    Console.WriteLine("Enter License_Plate : ");
                    nam = Console.ReadLine();
                    if (nam.Length != 0)
                    {
                        Dlist[i].d_vehicle.license_Plate = nam;
                    }
                    Console.WriteLine("Enter Vehicle_MOdel : ");
                    nam = Console.ReadLine();
                    if (nam.Length != 0)
                    {
                        Dlist[i].d_vehicle.model = nam;
                    }
                    Console.WriteLine("Press 1 if u want to change LOcation :");
                    nam = Console.ReadLine();
                    if (nam == "1")
                    {
                        Dlist[i].updateLocation();
                    }
                    Console.WriteLine("Press 1 For Change Status :  ");
                    nam = Console.ReadLine();
                    if (nam == "1")
                    {
                        Dlist[i].updateAvailbility();
                    }
                    WriteIntoFile();
                    return;
                }
            }
            Console.WriteLine("Not Found");
        }
        public void removeDriver(string ID)
        {

            decimal p = 0;
            for (int i = 0; i < Dlist.Count; i++)
            {
                if (Dlist[i].Driver_ID == ID)
                {
                    p = 1;
                    Dlist.Remove(Dlist[i]);
                }
            }
            if (p == 1)
            {
                Console.WriteLine("Removed Successfully");
            }
            else
            {
                Console.WriteLine("-----Sorry ID_NOT found--------");
            }
            WriteIntoFile();
        }

        public string assignDriver(Location start, string Gari)
        {
            List<double> d = new List<double>();
            List<Driver> s = new List<Driver>();
            double v1 = 0D;
            if (Dlist.Count() == 0)//Driver List is empty
            {
                return "";
            }
            for (int i = 0; i < Dlist.Count; i++)
            {
                v1 = Math.Pow((start.latitude - Dlist[i].D_Curr_loc.latitude), 2) - Math.Pow((start.longitude - Dlist[i].D_Curr_loc.longitude), 2);
                d.Add(v1);
                s.Add(Dlist[i]);
            }
            for (int i = 0; i < Dlist.Count; i++)
            {
                for (int j = 0; j < Dlist.Count; j++)
                {
                    if (d[i] > d[j]) //sorted the drivers obj w.r.t distance
                    {
                        double temp = d[i];
                        d[i] = d[j];
                        d[j] = temp;
                        Driver obj = s[i];
                        s[i] = s[j];
                        s[j] = obj;

                    }
                }
            }
    
            for (int i = 0; i < s.Count; i++)
            {
                if (s[i].D_availibity == true && s[i].d_vehicle.Vtype.ToLower() == Gari.ToLower())
                {
                    s[i].D_availibity=false;
                    return s[i].Driver_ID;
                }
            }
            return "";
        }
        public void WriteIntoFile()
        {
            FileStream f1 = new FileStream("Drivers.txt", FileMode.Create);
            StreamWriter Sw = new StreamWriter(f1);
            for (int i = 0; i < Dlist.Count; i++)
            {
                Sw.WriteLine(Dlist[i].Driver_ID + "," + Dlist[i].D_Name + "," + Dlist[i].D_Adress + "," + Dlist[i].D_age + "," + Dlist[i].D_availibity + "," + Dlist[i].D_Curr_loc.latitude + "," + Dlist[i].D_Curr_loc.longitude + "," + Dlist[i].D_PhoneNum + "," + Dlist[i].d_vehicle.Vtype + "," + Dlist[i].d_vehicle.license_Plate + "," + Dlist[i].d_vehicle.model);
            }
            Sw.Close();
            f1.Close();
        }
        public bool ReadFromFile()
        {
            bool T = false;
            FileStream f1 = new FileStream("Drivers.txt", FileMode.Open);
            StreamReader R1 = new StreamReader(f1);
            int i = 0;
            string m = R1.ReadLine();
            while (m != null)
            {
                var data = m.Split(",");
                if (data != null && data.Length >= 11)
                {
                    Driver D = new Driver();
                    D.Driver_ID = data[0];
                    D.D_Name = data[1];
                    D.D_Adress = data[2];
                    D.D_age = Convert.ToInt32(data[3]);
                    D.D_availibity = bool.Parse(data[4]);
                    D.D_Curr_loc.latitude = float.Parse(data[5]);
                    D.D_Curr_loc.longitude = float.Parse(data[6]);
                    D.D_PhoneNum = data[7];
                    D.d_vehicle.Vtype = data[8];
                    D.d_vehicle.license_Plate = data[9];
                    D.d_vehicle.model = data[10];
                    Dlist.Add(D);
                    i++;
                    T = true;
                }
                m = R1.ReadLine();
            }
            R1.Close();
            f1.Close();
            return T;
        }




    }
}