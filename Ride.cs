using System;
using System.Collections.Generic;
namespace MyApp
{
    class Ride
    {
        public Location start_loc { get; set; } = new Location();
        public Location end_loc { get; set; } = new Location();
        public double price { get; set; }
        public Driver D { get; set; } = new Driver();
        public passenger p1 { get; set; } = new passenger();
        public string assignPassenger()
        {
            Console.WriteLine("For Passenger : \nEnter Your Name : ");
            p1.Pname = Console.ReadLine();
            Console.WriteLine("Enter the Phone_Number ");
            p1.PN_Passenger = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("\nEnter the Vehicle_TYpe\nCar\nRikshaw\nBike");
                p1.V_Passenger = Console.ReadLine();
                Console.WriteLine("------------");
                if (p1.V_Passenger.ToLower() == "car" || p1.V_Passenger.ToLower() == "rikshaw" || p1.V_Passenger.ToLower() == "bike")
                {

                    return p1.V_Passenger;
                }

                else
                {
                    Console.WriteLine("\nInvalid selection...");
                }
            }
        }
        public Location getLocation()
        {
            Console.WriteLine("Start Location: ");
            start_loc.setLocation();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("End Location: ");
            end_loc.setLocation();
            Console.WriteLine("-----------------------------------");
            return start_loc;
        }
        private double Distance()
        {
                double distance = Math.Pow((end_loc.longitude - start_loc.longitude), 2) + Math.Pow((end_loc.latitude - start_loc.latitude), 2);
                distance = Math.Sqrt(distance);
                return distance;
        }
        public bool CalcultePrice()
        {
            double distance= Distance();
            if (p1.V_Passenger.ToLower() == "bike")
            {
             
                // Price = ((Distance*fuel_price)/fuel_average) + Commission
                price = (((distance) * 272) / 50);
                price = ((0.05)) * price + price; //Commison is added;
                price=Math.Round(price);
                if (price > 0)
                {
                    Console.WriteLine($"Your Bike Fare is ${Convert.ToInt32(price)}");
                    return true;
                }
                else if (price==0)
                {
                    Console.WriteLine("---You are Already on that position----");
                    return false;
                }
                Console.WriteLine($"Your Bike Fare is ${price}");
            }
            else if (p1.V_Passenger.ToLower() == "car")
            {
                price = ((distance) * 272) / 15;
                price = (0.20) * price + price;
                decimal p=Convert.ToDecimal(price);
                if (p > 0)
                {
                    Console.WriteLine($"Your Car Fare is ${Convert.ToInt32(p)}");
                    return true;
                }
                else if (p==0)
                {
                    Console.WriteLine("---You are Already on that position----");
                    return false;
                }
                

                return false;

            }
            else if (p1.V_Passenger.ToLower() == "rikshaw")
            {
           
                price = (((distance) * 272) / 35);
                price = ((.10) * price + price);
                price=Math.Round(price);
                Console.WriteLine("-----------------------------------");
                if (price > 0)
                {
                    Console.WriteLine($"Your Rikshaaw is ${Convert.ToInt32(price)}");
                    return true;
                }
                else if (price==0)
                {
                    Console.WriteLine("---You are Already on that position----");
                    return false;
                }

            }
            return false;



        }
        public void UpdateRideRecord()
        {
            FileStream f1=new FileStream("RideHistory.txt",FileMode.Append);
            StreamWriter Sw=new StreamWriter(f1);
            Sw.WriteLine("\tHistory Of Rides");
            Sw.Write("  Passenger Name : " +p1.Pname+" , "+" Passenger Phone : " +p1.PN_Passenger+" , "+" Passenger Vehicle : " +p1.V_Passenger+" , "+" Start  Location : (  " +start_loc.latitude+","+start_loc.longitude+" ) "+","+"End Location : ( " +end_loc.latitude+","+end_loc.longitude+" ) ,"+"  Price: $"+Convert.ToInt32(price));
            Sw.Close();
            f1.Close();
        }
    }
}