// See https://aka.ms/new-console-template for more information
using Lab1;
using System.Text.Json;

DividedBy3();
GuessTheNumber();

static void DividedBy3()
{
    for (int i = 1; i <= 100; i++)
    {
        if (i % 3 == 0)
        {
            if (i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
                continue;
            }
            Console.WriteLine("Fizz");
            continue;
        }

        if (i % 5 == 0)
        {
            Console.WriteLine("Buzz");
            continue;
        }
        Console.WriteLine(i);
    }
}

static void GuessTheNumber()
{
    var rand = new Random();
    var value = rand.Next(1, 101);
    var trials = 0;
    Console.WriteLine("Zgadnij liczbę z przedziału 1-100");
    while (1 == 1)
    {
        Console.Write("Podaj liczbę: ");
        if (!int.TryParse(Console.ReadLine(), out int guess))
        {
            Console.WriteLine("Wpisz liczbę");
            continue;
        }
        trials++;
        if (guess < value)
        {
            Console.WriteLine("Liczba jest za mała");
        }
        else if (guess > value)
        {
            Console.WriteLine("Liczba jest za duża");
        }
        else break;
    }
    Console.WriteLine("Zgadłeś!");
    Console.WriteLine("Ilość prób: " + trials);
    string name = "";
    while (string.IsNullOrEmpty(name))
    {
        Console.Write("Podaj swoje imię: ");
        name = Console.ReadLine();
    }
    var hs = new HighScore { Name = name, Trials = trials };
    List<HighScore> highScores;
    const string FileName = "highscores.json";
    if (File.Exists(FileName))
        highScores = JsonSerializer.Deserialize<List<HighScore>>(File.ReadAllText(FileName));
    else
        highScores = new List<HighScore>();

    highScores.Add(hs);
    File.WriteAllText(FileName, JsonSerializer.Serialize(highScores));

    var highScoresSorted = highScores.OrderBy(x => x.Trials).ToList();
    foreach (var item in highScoresSorted)
    {
        Console.WriteLine($"{item.Name} -- {item.Trials} prób");
    }
}