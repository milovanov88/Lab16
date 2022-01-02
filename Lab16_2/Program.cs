using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Lab16_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxPrice = products[0];
            foreach (Product e in products)
            {
                if  (e.priceProduct> maxPrice.priceProduct)
                {
                    maxPrice = e;
                }
            }
            Console.WriteLine("Самый догогой товар из списка:");
            Console.WriteLine($"{maxPrice.productCode} {maxPrice.productName} {maxPrice.priceProduct}");
            Console.ReadKey();
        }
    } 
}
