// See https://aka.ms/new-console-template for more information

using Lab2;

UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();

List<Fruit> fruits = new List<Fruit>();

for (int i = 0; i < 15; i++)
{
    fruits.Add(Fruit.Create());
}

foreach (var fruit in fruits)
{
    Console.WriteLine(fruit);
}

Console.WriteLine();

var f = fruits.Where(x => x.IsSweet == true).OrderByDescending(x => x.Price).ToList();

foreach (var fruit in f)
{
    Console.WriteLine(fruit);
}