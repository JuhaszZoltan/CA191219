using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191219
{
    struct Cica
    {
        public string Nev;
        public DateTime Szulinap;
        public ConsoleColor Szin;
        public bool Nem;
        public float Suly;
    }
    struct Diak
    {
        public string VNev;
        public string KNev;
        public int Magassag;
        public float Suly;
        public bool Nem;
    }

    class Program
    {
        static Diak[] diakok = new Diak[100];
        static void Main()
        {
            //EgyCica();
            //SokCica();
            //FileIras();
            //FileOlvasas();

            DiakokBeolvas();
            DbLany();

            LegmagasabbFiu();
            AtlagTestsuly();
            VanE165cmLany();

            Console.ReadKey();
        }

        private static void VanE165cmLany()
        {
            int i = 0;
            while (i < diakok.Length && !(!diakok[i].Nem && diakok[i].Magassag == 165))
            {
                i++;
            }
            Console.WriteLine($"{(i < diakok.Length ? "VAN" : "NINCS")} 165 cm magas lány");
        }

        private static void AtlagTestsuly()
        {
            float sum = 0;

            for (int i = 0; i < diakok.Length; i++)
            {
                sum += diakok[i].Suly;
            }

            Console.WriteLine($"Átlagtos testsúly: {sum / diakok.Length}");
        }

        private static void LegmagasabbFiu()
        {
            int maxi = 0;

            for (int i = 0; i < diakok.Length; i++)
            {
                if(diakok[i].Nem && diakok[i].Magassag > diakok[maxi].Magassag)
                {
                    maxi = i;
                }
            }

            Console.WriteLine($"Legmagasabb fiú: {diakok[maxi].VNev} {diakok[maxi].KNev}");
        }

        private static void DbLany()
        {
            int db = 0;

            for (int i = 0; i < diakok.Length; i++)
            {
                if (!diakok[i].Nem) db++;
            }

            Console.WriteLine($"Össesen {db} db lány van.");
        }

        private static void DiakokBeolvas()
        {
            var sr = new StreamReader(@"..\..\diakok.txt", Encoding.UTF8);
            for (int i = 0; i < diakok.Length; i++)
            {
                var sor = sr.ReadLine().Split(' ');
                diakok[i] = new Diak()
                {
                    VNev = sor[0],
                    KNev = sor[1],
                    Magassag = int.Parse(sor[2]),
                    Suly = float.Parse(sor[3]),
                    Nem = sor[4] == "fiú",
                };
            }
            sr.Close();
        }

        private static void FileOlvasas()
        {
            var sr = new StreamReader(
                //@"C:\\users\juhaszz.admin\desktop\proba.txt",
                @"..\..\proba.txt",
                Encoding.UTF8);

            //Console.WriteLine(sr.ReadLine());

            Console.WriteLine("Egy 12 cm átmérőjű kör területe: ");
            string[] sor = sr.ReadLine().Split('=');
            double pi = double.Parse(sor[1]);

            Console.WriteLine(6 * 6 * pi + " cm^2");

            sr.Close();

            Console.WriteLine("kész!");
        }
        private static void FileIras()
        {
            var sw = new StreamWriter(
                //@"C:\\users\juhaszz.admin\desktop\proba.txt",
                @"..\..\proba.txt",
                false,
                Encoding.UTF8);

            //for (int i = 0; i < 5; i++)  sw.Write("nagyon, ");
            //sw.WriteLine("szeretem a cicákat!!");
            sw.WriteLine($"Pi={Math.PI}");
            //sw.WriteLine(20 + 30);
            //if (DateTime.Now.Hour < 12) sw.WriteLine("délelőtt van");
            //else sw.WriteLine("délután van");
            //sw.WriteLine($"\nkészület: {DateTime.Now}");
            
            sw.Close();

            Console.WriteLine("kész!");
        }
        private static void SokCica()
        {
            Console.Write("mennyi cicád van? ");
            int db = int.Parse(Console.ReadLine());

            Console.WriteLine($"júúúúúj {db} cica az nagyon sok!!");

            Console.WriteLine("Mesélj róluk!");

            Cica[] ct = new Cica[db];

            for (int i = 0; i < ct.Length; i++)
            {
                ct[i] = new Cica();

                Console.WriteLine($"Mi az {i + 1}. cicád neve? ");
                ct[i].Nev = Console.ReadLine();

                Console.WriteLine($"Mikor született {ct[i].Nev}? (yyyy-MM-dd)");
                ct[i].Szulinap = DateTime.Parse(Console.ReadLine());

                Console.WriteLine($"És milyen nemű {ct[i].Nev}? (f/l)");
                ct[i].Nem = Console.ReadLine() == "f";
            }

            int sum = 0;
            for (int i = 0; i < ct.Length; i++)
            {
                sum += (DateTime.Now.Year - ct[i].Szulinap.Year);
            }
            Console.WriteLine("----------");
            Console.WriteLine($"Tudtad, hogy cicáid összéletkora {sum} év! :O");
        }
        private static void EgyCica()
        {
            var c1 = new Cica()
            {
                Nev = "Cirmi",
                Szulinap = new DateTime(2018, 02, 11),
                Szin = ConsoleColor.Red,
                Nem = true,
                Suly = 3.75F,
            };

            Console.ForegroundColor = c1.Szin;

            Console.WriteLine(
                $"{c1.Nev} " +
                $"{(c1.Nem ? "fiú" : "lány")}" +
                $"cica aki {DateTime.Now.Year - c1.Szulinap.Year} éves");

        }
    }
}
