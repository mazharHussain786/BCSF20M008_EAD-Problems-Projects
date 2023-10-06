using System;
namespace MyApp
{
    class Location
    {
        public float longitude;
        public float latitude;
        public void setLocation()
        {
            Console.WriteLine("Enter the longitude: ");
            longitude=Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter the latitude ");
            latitude=Convert.ToSingle(Console.ReadLine());
        }
    }
}