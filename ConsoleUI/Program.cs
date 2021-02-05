using Business.Abstract;
using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Araba yılı giriniz");
            string modelYear = Console.ReadLine();
            Console.WriteLine("araba ücreti giriniz");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Araba açıklaması giriniz");
            string aciklama = Console.ReadLine();

       


            CarManager carManager = new CarManager(new EfCarDal());

            Car car = new Car();
            car.ModelYear = modelYear;
            car.DailyPrice = price;
            car.Description = aciklama;
            car.BrandId = 1;  // default olarak. şimdilik
            car.ColorId = 1; // default olarak. şimdilik
            carManager.Add(car);



            foreach (Car item in carManager.GetAll())
            {
                Console.WriteLine($"Araba Açıklaması : {item.Description} - Fiyatı : {item.DailyPrice} - Yılı : {item.ModelYear}");
            }
        }
    }
}
