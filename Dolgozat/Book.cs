using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    internal class Book
    {
        long isbn;
        List<Author> authors;
        string cim;
        int release_date;
        string nyelv;
        int keszlet;
        int ar;

        public Book(long isbn, List<Author> authors, string cim, int release_date, string nyelv, int keszlet, int ar)
        {
            this.isbn = isbn;
            this.authors = authors;
            this.cim = cim;
            this.release_date = release_date;
            this.nyelv = nyelv;
            this.keszlet = keszlet;
            this.ar = ar;
        }

        public Book(string cim, string author)
        {
            this.isbn = new Random().Next(1000000000, unchecked((int)9999999999));
            this.authors = new List<Author> { new Author(author) };
            this.cim = cim;
            this.release_date = 2024;
            this.nyelv = "magyar";
            this.keszlet = 0;
            this.ar = 4500;
        }

        public override string ToString()
        {
            return $"Cím: {Cim}, ISBN: {ISBN}, Kiadási dátum: {Release_date}, Nyelv: {Nyelv}, Ár: {Ar}," + (Authors.Count == 1 ? "Szerző: " : "Szerzők: ") + Authors.ToString() + " Készlet: " + (Keszlet.ToString().Length == 0 ? "beszerzés alatt" : keszlet + "db");
        }

        public long ISBN {
            get => isbn;
            private set {
                if (value.ToString().Length != 10) throw new Exception("Az ISBN számsornak 10 számjegyűnek kell lennie.");
                isbn = value;
            }
        }
        internal List<Author> Authors {
            get => authors;
            private set {
                if (value.Count > 3) throw new Exception("Maximum 3 készítője lehet a könyvnek");
                authors = value;
            }
        }

        public string Cim
        {
            get => cim;
            private set
            {
                if (value.Length < 3 || value.Length > 64) throw new Exception("A cím minimum 3, maximum 64 karakter hosszú.");
                cim = value;
            }
        }

        public int Release_date {
            get => release_date;
            private set
            {
                if (value < 2007 || value > DateTime.Now.Year) throw new Exception("A kiadás éve 2007 és a jelen év között kell hogy legyen.");
                release_date = value;
            }
        }

        public string Nyelv
        {
            get => nyelv;
            private set
            {
                if (value != "magyar" || value != "német" || value != "angol") throw new Exception("Csak az angol, német és a magyar az elfogadott nyelv.");
                nyelv = value;
            }
        }

        public int Keszlet {
            get => keszlet;
            set
            {
                if (value.ToString().Length < 0) throw new Exception("A készletnek minimum 0-nak kell lennie.");
                keszlet = value;
            }
        }

        public int Ar {
            get => ar;
            private set
            {
                if (value.ToString().Length < 1000 || value.ToString().Length > 10000) throw new Exception("Az árnak 1000 és 10000 Ft között kell lennie."); 
                ar = value;
            }
        }
    }
}
