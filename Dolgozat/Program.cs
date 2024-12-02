using Dolgozat;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Book> konyvek = GenerateBooks(15);
        SimulateSales(konyvek, 100);
    }

    private static List<Book> GenerateBooks(int count)
    {
        List<Book> konyvek = new List<Book>();
        HashSet<long> isbnSet = new HashSet<long>();
        Random random = new Random();
        string[] mintanevek = { "Kiss János", "Nagy Anna", "Szabó Péter", "Farkas Eszter", "Molnár Balázs" };
        string[] mintacimek = { "Programozás C# nyelven", "Adatszerkezetek és algoritmusok", "Mesterséges intelligencia megértése", "A nagy kaland", "A .NET elsajátítása", "Kalandoréka", "Az idő múlása", "Érzések könyve", "Felfedezések", "Élővilág", "Programozói bűvészet", "JavaScript titkai", "Digitális kempingezés", "Frissítő levelek", "Az utolsó medve" };

        for (int i = 0; i < count; i++)
        {
            long isbn;
            do
            {
                isbn = GenerateUniqueISBN();
            } while (!isbnSet.Add(isbn));

            var szerzogyszam = random.Next(1, 4);
            var szerzok = new List<Author>();
            for (int j = 0; j < szerzogyszam; j++)
            {
                szerzok.Add(new Author(mintanevek[random.Next(mintanevek.Length)]));
            }

            string cim = mintacimek[random.Next(mintacimek.Length)];
            int kiadasEve = random.Next(2007, DateTime.Now.Year + 1);
            string nyelv = random.NextDouble() < 0.8 ? "magyar" : "angol";
            int keszlet = random.NextDouble() < 0.3 ? 0 : random.Next(5, 11);
            int ar = random.Next(1000, 10001);
            konyvek.Add(new Book(isbn, szerzok, cim, kiadasEve, nyelv, keszlet, ar));
        }

        return konyvek;
    }

    static long GenerateUniqueISBN()
    {
        Random random = new Random();
        long isbn = 0;
        for (int i = 0; i < 10; i++)
        {
            isbn = isbn * 10 + random.Next(0, 10);
        }
        return isbn;
    }

    private static void SimulateSales(List<Book> konyvek, int iterations)
    {
        Random random = new Random();
        decimal totalRevenue = 0;
        int kifogyottKonyvekSzama = 0;

        foreach (var _ in Enumerable.Range(0, iterations))
        {
            var valasztottKonyv = konyvek[random.Next(konyvek.Count)];
            if (valasztottKonyv.Keszlet > 0)
            {
                totalRevenue += valasztottKonyv.Ar;
                valasztottKonyv.Keszlet--;
            }
            else
            {
                if (random.NextDouble() < 0.5)
                {
                    int ujKeszlet = random.Next(1, 11);
                    valasztottKonyv.Keszlet += ujKeszlet;
                }
                else
                {
                    kifogyottKonyvekSzama++;
                    konyvek.Remove(valasztottKonyv);
                }
            }
        }

        Console.WriteLine($"Bruttó bevétel: {totalRevenue:C}");
        Console.WriteLine($"Kifogyott könyvek száma: {kifogyottKonyvekSzama}");
        Console.WriteLine($"Kezdeti készlet: {konyvek.Count + kifogyottKonyvekSzama}, Jelenlegi készlet: {konyvek.Count}, Különbség: {konyvek.Count - (konyvek.Count + kifogyottKonyvekSzama)}");
    }
}