using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;



namespace Irodahaz
{
    internal class Program
    {
        static int Legtobb(List<Iroda> a)
        {
            var leg = new List<int>();
            for (int i = 0; i < a.Count; i++)
            {
                leg.Add(a[i].Letszamadatok.Sum());

            }
            return leg.IndexOf(leg.Max()) + 1;
        }
        static Iroda? kilenc(List<Iroda> b)
        {
            var kil = b.FirstOrDefault(x => x.Letszamadatok.Contains(9));
            return kil;
        }
        static int ot(List<Iroda> c)
        {
            var otos = 0;
            for (int i = 0; i < c.Count; i++)
            {

                for (int j = 0; j < c[i].Letszamadatok.Count; j++)
                {
                    if (c[i].Letszamadatok[j] > 5)
                    {
                        otos++;
                    }
                   
                }
                
            }
            return otos;
        }
        static int dolgoz(List<Iroda>d)
        {
            var ossz = 0;
            var dolg = new List<int>();
            for (int i = 0; i < d.Count; i++)
            {
                dolg.Add(d[i].Letszamadatok.Sum());

                for (int j = 0; j < d[i].Letszamadatok.Count; j++)
                {
                    ossz += d[i].Letszamadatok.Count();
                }
            }
            return ossz;
        }

        static void Main(string[] args)
        {
            List<Iroda> iroda = new List<Iroda>();
            using (var sr = new StreamReader(@"..\..\..\src\irodahaz.txt"))
            {
                while (!sr.EndOfStream)
                {
                    iroda.Add(new Iroda(sr.ReadLine()));
                }
            }
            string tabla = "Kód\t\t         Kezdet\t" +
               "\t   1.   2.   3.   4.   5.   6.   7.   8.   9.  10.  11.  12\n";
            for (int i = 0; i < iroda.Count; i++)
            {
                tabla += $"{i + 1}. {iroda[i]}\n";
            }
            Console.WriteLine(tabla);

            Console.WriteLine("8.feladat");
            Console.WriteLine($"{Legtobb(iroda)}.emelet");

            Console.WriteLine("9.feladat");

            if (kilenc(iroda) is null)
            {
                Console.WriteLine("Nincs ilyen Iroda");

            }
            else
            {
                Console.WriteLine($"{kilenc(iroda).Kod}, {kilenc(iroda).Letszamadatok.IndexOf(9) + 1}.");
            }

            Console.WriteLine("10.feladat");
            Console.WriteLine($"{ot(iroda)} db");
            Console.WriteLine("11.feladat");
            using (StreamWriter sw = new StreamWriter(@"..\..\..\src\nemdolgozo.txt"))
            {
                foreach (var item in iroda)
                {
                    if (item.Letszamadatok.Any(l => l == 0)) 
                    {
                        sw.WriteLine($"{item.Kod} {item.Kezdet}");
                    }
                }
            }
            Console.WriteLine("12.feladat");
            var logmeinIrodak = iroda.Where(i => i.Kod == "LOGMEIN").ToList();
            if (logmeinIrodak.Count > 0)
            {
                double atlagLetszam = logmeinIrodak.SelectMany(i => i.Letszamadatok).Average();
                Console.WriteLine($"A LOGMEIN kódú cég irodáiban átlagosan {Math.Round(atlagLetszam)} személy dolgozik.");
            }
            else
            {
                Console.WriteLine("Nincs LOGMEIN kódú cég .");
            }
            Console.WriteLine("13.feladat");

            Console.WriteLine("14.feladat");
            Console.WriteLine(dolgoz(iroda));

        }
    }
}