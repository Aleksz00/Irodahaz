using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irodahaz
{
    public class Iroda
    {
        public string Kod { get; set; }
        public int Kezdet { get; set; }
        public List<int> Letszamadatok { get; set; }

        public Iroda(string s)
        {
            string[] v = s.Split(' ');
            Kod = v[0];
            Kezdet = int.Parse(v[1]);
           Letszamadatok = new List<int>();
            for (int i = 2; i < v.Length; i++)
            {
                Letszamadatok.Add(int.Parse(v[i]));
            }
        }
        public override string ToString()
        {
            string kiir = $"{Kod,-15}  \t {Kezdet,-12}\t   ";
                for (int i = 0; i < Letszamadatok.Count; i++)
                {
                kiir += $"{Letszamadatok[i]}    ";
                }

            return kiir;
            }
            
        
    }
        
}
