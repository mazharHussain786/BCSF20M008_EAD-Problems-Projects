namespace MyApp
{
    class Driver
    {
        public string? D_Name{get;set;}
        public float D_age {get;set;}
        public string? D_Adress {get;set;}
        public string? D_PhoneNum {get;set;}
        public Location D_Curr_loc=new Location();
        public Vehicle d_vehicle=new Vehicle();
        public List<int> D_rating=new List<int>();
        public bool D_availibity{get;set;}
        public string? Driver_ID{get;set;}
        public void updateAvailbility()
        {
            Console.WriteLine("Enter the Availibity (True Or False)");
            D_availibity = bool.Parse(Console.ReadLine());
        }
        public double getRating()
        {
            if (D_rating.Count == 0)
            {
                Console.WriteLine("-----Zero_Rating Yet----------");
                return 0;
            }
            double t_rating = 0;
            for (int i = 0; i < D_rating.Count; i++)
            {
                t_rating = t_rating + D_rating[i];
            }
            Console.WriteLine(t_rating/D_rating.Count);
            return t_rating;
        }
        public void updateLocation()
        {
            D_Curr_loc.setLocation();
        }

    }

}