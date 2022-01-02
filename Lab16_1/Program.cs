using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace Lab16_1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Задача 16");
            const int n = 5;
            Product[] products = new Product[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int productCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите имя товара");
                string productName = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double priceProduct = Convert.ToDouble(Console.ReadLine());

                products[i] = new Product() { productCode = productCode, productName = productName, priceProduct = priceProduct };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonstring = JsonSerializer.Serialize(products, options);

            using (StreamWriter sw = new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonstring);
            }
            Console.WriteLine("Нажмите любую клавишу для завершения");
            Console.ReadKey();
        }
    }

}