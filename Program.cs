namespace Patterns{
class Program
{
    static void Main(string[] args)
    {
        // Singleton examples
            Console.WriteLine("Singleton Pattern:");
            Singleton singleton = Singleton.GetInstance();
            singleton.DisplayMessage();

            Console.WriteLine("\n------------------------\n");

            Console.WriteLine("Thread-Safe Singleton Pattern:");
            ThreadSafeSingleton threadSafeSingleton = ThreadSafeSingleton.GetInstance();
            threadSafeSingleton.DisplayMessage();

            Console.WriteLine("\n------------------------\n");

            // Factory examples
            Console.WriteLine("Factory Pattern:");
            SimpleFactory simpleFactory = new SimpleFactory();
            IProduct productA = simpleFactory.CreateProduct("A");
            productA.DisplayInfo();

            Console.WriteLine("\nFactory Method Pattern:");
            Creator creatorA = new ConcreteCreatorA();
            IProduct productB = creatorA.FactoryMethod();
            productB.DisplayInfo();

            Console.WriteLine("\n------------------------\n");

            // Abstract Factory example
            Console.WriteLine("Creating Products using ConcreteFactory1:");
            IAbstractFactory factory1 = new ConcreteFactory1();
            IProductA productA1 = factory1.CreateProductA();
            IProductB productB1 = factory1.CreateProductB();
            
            productA1.DisplayInfo();
            productB1.DisplayInfo();

            Console.WriteLine("\n------------------------\n");

            Console.WriteLine("Creating Products using ConcreteFactory2:");
            IAbstractFactory factory2 = new ConcreteFactory2();
            IProductA productA2 = factory2.CreateProductA();
            IProductB productB2 = factory2.CreateProductB();
            
            productA2.DisplayInfo();
            productB2.DisplayInfo();

            // Builder example
            Console.WriteLine("Builder Pattern - Car Example:");
            CarDirector carDirector = new CarDirector();
            ICarBuilder carBuilder = new LuxuryCarBuilder();
            carDirector.ConstructLuxuryCar(carBuilder);
            CarProduct luxuryCar = carBuilder.GetCar();
            Console.WriteLine($"Luxury Car - Engine: {luxuryCar.Engine}, Wheels: {luxuryCar.Wheels}, Interior: {luxuryCar.Interior}");

            Console.WriteLine("\nBuilder Pattern - House Example:");
            HouseDirector houseDirector = new HouseDirector();
            IHouseBuilder houseBuilder = new FancyHouseBuilder();
            houseDirector.ConstructFancyHouse(houseBuilder);
            HouseProduct fancyHouse = houseBuilder.GetHouse();
            Console.WriteLine($"Fancy House - Foundation: {fancyHouse.Foundation}, Walls: {fancyHouse.Walls}, Roof: {fancyHouse.Roof}");

            Console.WriteLine("\n------------------------\n");

            // Prototype example
            Console.WriteLine("Prototype Pattern - User Example:");
            User originalUser = new User("JohnDoe", 30);
            User? clonedUser = originalUser.Clone() as User;

            if (clonedUser != null)
            {
                Console.WriteLine("Original User:");
                originalUser.DisplayInfo();

                Console.WriteLine("\nCloned User:");
                clonedUser.DisplayInfo();
            }

            Console.WriteLine("\nPrototype Pattern - Document Example:");
            Document originalDoc = new Document("Design Pattern Guide", "This is a guide for design patterns.");
            Document? clonedDoc = originalDoc.Clone() as Document;

            if (clonedDoc != null)
            {
                Console.WriteLine("Original Document:");
                originalDoc.DisplayContent();

                Console.WriteLine("\nCloned Document:");
                clonedDoc.DisplayContent();
            }
        }
        }
    }

