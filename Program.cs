using ConsoleApp1;
using System.Reflection.PortableExecutable;

internal class Program
{
    private static void Main(string[] args)
    {
        List<orginization> orginizationList = new < orginization > ();
        StreamReader sr = new StreamReader("organization100.csv");
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            orginizationList.Add(new orginization(sr.ReadLine().Split(",")));
        }
        Console.WriteLine("Első feladat:"+ orginizationList.Count(x => x.Founded == 2012));
        Console.WriteLine("2. feladat:");
        int sec = orginizationList.Where(x => x.Industry == "Secondary Education").Sum(x => x.EmployeesNumber);
        int mil = orginizationList.Where(x => x.Industry == "Military Industry").Sum(x => x.EmployeesNumber);
        if (sec > mil)
        {
            Console.WriteLine("a secondory-ban többen vannak");
        }
        else if (sec == mil) 
        {
            Console.WriteLine("Ugyanannyian vannak");
        }
        else
        {
            Console.WriteLine("A military-ban vannak többen");
        }
        Console.WriteLine("3. feladat:");
        orginizationList.OrderBy(x => x.Founded).GroupBy(x => x.Founded).ToList().ForEach(x => Console.WriteLine($"Alapítás éve: {x.Key} Alapított cégek: {x.Count()}"));
        Console.WriteLine("4. feladat");
        orginizationList.GroupBy(x => x.Country).OrderByDescending(x => x.Count()).Take(5).ToList().ForEach(x => Console.WriteLine($"{x.Key} {x.Count()}"));


        Console.WriteLine("szeretetcsomag 1. feladat");
        foreach (var item in orginizationList.GroupBy(x => x.Country).OrderBy(x => x.Key).ToList())
        {
            Console.WriteLine($"{item.Key}");
        }
        Console.WriteLine("szeretetcsomag 2. feladat");    orginizationList.GroupBy(x => x.Country).OrderBy(x => x.Key).ToList().ForEach(x => Console.WriteLine(x));
        Console.WriteLine("szeretetcsomag 3. feladat");    orginizationList.Where(x => x.Industry == "Plastic").Average(x => x.EmployeesNumber);
        Console.WriteLine("szeretetcsomag 4. feladat");    orginizationList.GroupBy(x => x.Country).OrderBy(x => x.Key).ToList()//.ForEach(x => Console.WriteLine(x.Key + "A leghosszabb nevű"));

    }
}