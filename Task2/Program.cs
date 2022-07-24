using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //счивание json строки из файла
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../products.json"))
            {
                jsonString = sr.ReadToEnd();
            }

            //создание массива данных по json строке
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            //цикл поиска элемента массива с максимальной ценой
            Product maxPrice = products[0];
            foreach (Product p in products)
            {
                if (p.Price > maxPrice.Price) maxPrice = p;
            }

            //ввывод результата
            Console.WriteLine("Продукт с максимальной стоимостью: {0}, пор.номер {1}, стоимость - {2}", maxPrice.Name, maxPrice.Сode, maxPrice.Price);
            Console.ReadKey();
        }
    }
}
