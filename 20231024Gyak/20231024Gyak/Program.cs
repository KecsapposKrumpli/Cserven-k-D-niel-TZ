using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace CservenakDaniel
{
    class Bolygo
    {
        public string nev { get; set; }
        public int szam { get; set; }
        public double arany { get; set; }

        public Bolygo(string sor)
        {
            string[] atmeneti = sor.Split(";");
            nev = atmeneti[0];
            szam = Convert.ToInt32(atmeneti[1]);
            arany = Convert.ToDouble(atmeneti[2]);
        }

        public override string ToString()
        {
            return $"{nev}, {szam}, {arany}";
        }  

    }

    class Program
    {
        static void Main()
        {

            List<Bolygo> bolygok = new List<Bolygo>();

            foreach (var item in File.ReadLines(@"..\..\..\src\solsys.txt"))
            {
                bolygok.Add(new Bolygo(item));
            }

            foreach (var item in bolygok)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("3. feladat:");

            Console.WriteLine($"3.1: {Szam(bolygok)} van a naprendszerben");
            Console.WriteLine($"3.2: {Atlag(bolygok)} van a naprendszerben");

            double max = bolygok[0].arany;
            string lnev = bolygok[0].nev;

            for (int i = 0; i < bolygok.Count; i++)
            {
                if (bolygok[i].arany > max)
                {
                    max = bolygok[i].arany;
                    lnev = bolygok[i].nev;
                }
            }

            Console.WriteLine($"3.3: a legnagyobb térfogatú bolygú a {lnev} ");

            Console.Write($"3.4: Írd be a keresett bolygó nevét: ");
            string bekert = Console.ReadLine();

            bool van = false;
            int b = 0;

            while (b < bolygok.Count &&!van)
            {
                if (bekert == bolygok[b].nev)
                {
                    van = true;
                }
                b++;
            }

            if (van)
            {
                Console.WriteLine($"Van ilyen bolygó");
            }

            else
            {
                Console.WriteLine($"Sajnos nincs ilyen nevű bolygó a naprendszerben");
            }

            Console.Write($"Írj be egy egész számot: ");
            int bekertsz = Convert.ToInt32(Console.ReadLine());

            List<string> blynev = new List<string>();

            for (int i = 0; i < bolygok.Count; i++)
            {
                if (bekertsz > bolygok[i].szam)
                {
                    blynev.Add(bolygok[i].nev);
                }
            }
            Console.WriteLine($"\t A következő bolygóknak van 10-nál/nél több holdja {blynev}");
        }

        static int Szam (List<Bolygo> a)
        {

            int db = 0;

            for (int i = 0; i < a.Count; i++)
            {
                db++;
            }

            return db;

        }

        static double Atlag (List<Bolygo> a)
        {
            double atlag = 0;

            for (int i = 0; i < a.Count; i++)
            {
                atlag = atlag + a[i].szam;
            }

            atlag = atlag / a.Count;

            return atlag;

        }

    }
}

