namespace Patterns
{
    public class CarProduct
    {
        public string? Engine { get; set; }
        public string? Wheels { get; set; }
        public string? Interior { get; set; }
    }

    public interface ICarBuilder
    {
        void BuildEngine();
        void BuildWheels();
        void BuildInterior();
        CarProduct GetCar();
    }

    public class LuxuryCarBuilder : ICarBuilder
    {
        private CarProduct car = new CarProduct();

        public void BuildEngine()
        {
            car.Engine = "Powerful Engine";
        }

        public void BuildWheels()
        {
            car.Wheels = "Alloy Wheels";
        }

        public void BuildInterior()
        {
            car.Interior = "Leather Interior";
        }

        public CarProduct GetCar()
        {
            return car;
        }
    }

    public class CarDirector
    {
        public void ConstructLuxuryCar(ICarBuilder builder)
        {
            builder.BuildEngine();
            builder.BuildWheels();
            builder.BuildInterior();
        }
    }

    public class HouseProduct
    {
        public string? Foundation { get; set; }
        public string? Walls { get; set; }
        public string? Roof { get; set; }
    }

    public interface IHouseBuilder
    {
        void BuildFoundation();
        void BuildWalls();
        void BuildRoof();
        HouseProduct GetHouse();
    }

    public class FancyHouseBuilder : IHouseBuilder
    {
        private HouseProduct house = new HouseProduct();

        public void BuildFoundation()
        {
            house.Foundation = "Strong Foundation";
        }

        public void BuildWalls()
        {
            house.Walls = "Decorative Walls";
        }

        public void BuildRoof()
        {
            house.Roof = "Luxury Roof";
        }

        public HouseProduct GetHouse()
        {
            return house;
        }
    }

    public class HouseDirector
    {
        public void ConstructFancyHouse(IHouseBuilder builder)
        {
            builder.BuildFoundation();
            builder.BuildWalls();
            builder.BuildRoof();
        }
    }
}


