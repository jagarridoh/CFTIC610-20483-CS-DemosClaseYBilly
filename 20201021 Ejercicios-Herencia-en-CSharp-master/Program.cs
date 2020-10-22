using System;
using static System.Console;
namespace Heritage05
{
    class Program
    {
        static void Main(string[] args)
        {
            // new Program().UsingBeverageHeritage();
            //new Program().usingShapesHeritage();
            new Program().usingPublicationHeritage();
            //new Program().usingAutomobileHeritage();
            // new Program().usingNewAndOverride();
        }
        public void UsingBeverageHeritage()
        {
            Beverage coffee = new Beverage();
            Coffee coffee1 = new Coffee();
            // Use base class members.
            coffee1.Name = "Fourth Espresso";
            coffee1.IsFairTrade = true;
            int servingTemp = coffee1.GetServingTemperature();
            // Use derived class members.
            coffee1.Bean = "Arabica";
            coffee1.Roast = "Dark";
            coffee1.CountryOfOrigin = "Colombia";

            servingTemp = coffee.GetServingTemperature();
            WriteLine($"Temperatura desde la clase base:{servingTemp}");
            servingTemp = coffee1.OtherServingTemperatura();
            WriteLine($"Temperatura desde la clase deivada:{servingTemp}");

            Juice orange = new Juice();
            orange.Name = "Valencia";

        }

        public class Juice : Beverage 
        {
            private string RecoletarSemillas() {
                servingTemperature = 23;
                return "";
            }
        }

        public class IceJuice : Juice {
            private string SirviendoHelados() {
                servingTemperature = 0;
                return "";
            }
        }


        public void usingShapesHeritage()
        {
            Shape[] shapes = { new Rectangle(10, 12), new Square(5),
                        new Circle(3) };
            foreach (var shape in shapes)
            {
                Console.WriteLine($"{shape}: area, {Shape.GetArea(shape)}; " +
                                  $"perimeter, {Shape.GetPerimeter(shape)}");
                var rect = shape as Rectangle;
                if (rect != null)
                {
                    Console.WriteLine($"   Is Square: {rect.IsSquare()}, Diagonal: {rect.Diagonal}");
                    continue;
                }
                var sq = shape as Square;
                if (sq != null)
                {
                    Console.WriteLine($"   Diagonal: {sq.Diagonal}");
                    continue;
                }
            }
        }

        public void usingPublicationHeritage()
        {
            var book = new Book("The Tempest", "0971655819", "Shakespeare, William",
                                "Public Domain Press");
            ShowPublicationInfo(book);
            book.Publish(new DateTime(2016, 8, 18));
            ShowPublicationInfo(book);

            var book2 = new Book("The Tempest", "Classic Works Press", "Shakespeare, William");
            Write($"{book.Title} and {book2.Title} are the same publication: " +
                  $"{((Publication)book).Equals(book2)}");
        }
        public static void ShowPublicationInfo(Publication pub)
        {
            string pubDate = pub.GetPublicationDate();
            WriteLine($"{pub.Title}, " +
                      $"{(pubDate == "NYP" ? "Not Yet Published" : "published on " + pubDate):d} by {pub.Publisher}");
        }

        public void usingAutomobileHeritage()
        {
            var packard = new Automobile("Packard", "Custom Eight", 1948);
            Console.WriteLine(packard);
        }

        public void usingNewAndOverride()
        {
            BaseClass bc = new BaseClass();
            DerivedClass dc = new DerivedClass();
            BaseClass bcdc = new DerivedClass();

            bc.Method1();
            bc.Method2();
            dc.Method1();
            dc.Method2();
            bcdc.Method1();
            bcdc.Method2();
        }
    }
}