using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //Объявление массива данных
            const int NUMBEROFPRODUCTE = 5;
            Product[] products = new Product[NUMBEROFPRODUCTE];

            //Задание значений массива данных
            for (int i = 0; i < NUMBEROFPRODUCTE; i++)
            {
                Console.WriteLine("Введите номер продукта");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите наименование продукта");
                string name = Console.ReadLine();
                Console.WriteLine("Введите стоимость продукта");
                double price = Convert.ToDouble(Console.ReadLine());

                products[i] = new Product() { Сode = code, Name = name, Price = price };
            }

            //создание json строки
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(products, options);

            //запись json строки в файл
            using (StreamWriter sw = new StreamWriter("../../../products.json"))
            {
                sw.WriteLine(jsonString);
            }

        }
    }
}
