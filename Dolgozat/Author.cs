using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    internal class Author
    {
        string keresztnev;
        string vezeteknev;
        Guid guid;

        public Author(string nev)
        {
            string[] nevek = nev.Split(" ");
            Keresztnev = nevek[0];
            Vezeteknev = nevek[1];
            Guid = Guid.NewGuid();
        }

        public string Keresztnev {
            get => keresztnev;
            set {
                if (value.Length < 3 || value.Length > 32) throw new Exception("A keresztnév 3 és 32 betű között kell hogy legyen.");
                keresztnev = value;
            }
        }

        public string Vezeteknev
        {
            get => vezeteknev;
            set
            {
                if (value.Length < 3 || value.Length > 32) throw new Exception("A vezetéknév 3 és 32 betű között kell hogy legyen.");
                vezeteknev = value;
            }
        }
        public Guid Guid { get => guid; set => guid = value; }
    }
}
