using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Fruit
    {
        public string Name { get; set; }
        public bool IsSweet { get; set; }
        public decimal Price { get; set; }
        public decimal UsdPrice => Price / UsdCourse.Current;
        public static Fruit Create()
        {
            Random r = new Random();
            string[] names = new string[] { "Apple", "Banana", "Cherry", "Durian", "Edelberry", "Grape", "Jackfruit" };
            return new Fruit
            {
                Name = names[r.Next(names.Length)],
                IsSweet = r.NextDouble() > 0.5,
                Price = (decimal)r.NextDouble() * 10
            };
        }

        public override string ToString()
        {
            return $"Fruit: {Name}, IsSweet={IsSweet}, Price={Price.ToString("C2")}, UsdPrice={MyFormatter.FormatUsdPrice(UsdPrice)}";
        }
    }
}
