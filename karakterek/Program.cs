﻿using System.Net.Sockets;

namespace karakterek
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Karakter> karakterek = [];
			Beolvasas("karakterek.txt", karakterek);

            foreach (var item in karakterek)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Legtöbb Hp-s karakter: " + Legmagasabb_Eletero(karakterek));
            Console.WriteLine("Átlagszint: " + AtlagSzint(karakterek));
            Console.WriteLine("Karakterek erő szerint sorrendbe állítva:");
            ErossegSzerintRendezes(karakterek);
			ErosE(karakterek);
			KarakterSzintSzures(karakterek);
			CSVLetrehozas(karakterek);
			CSVBeolvasasVisszaadas("karakterek.csv");
			Top3(karakterek);
        }
		static (string, int, int) Legmagasabb_Eletero(List<Karakter> karakterek)
		{
			int index = 0;
			int temp = karakterek[0].Eletero;
            foreach (var item in karakterek)
            {
                if (item.Eletero > temp)
				{
					temp = item.Eletero;
					index = karakterek.IndexOf(item);
				}
            }
			return (karakterek[index].Nev, karakterek[index].Szint, karakterek[index].Ero);
        }
		static int AtlagSzint(List<Karakter> karakterek)
		{
			int sum = 0;
			foreach (var item in karakterek)
			{
				sum += item.Szint;
			}
			return sum/karakterek.Count;
		}
		static void ErossegSzerintRendezes(List<Karakter> karakterek)
		{
			List<Karakter> rendezett = karakterek.OrderBy(o => o.Ero).ToList();
            foreach (var item in rendezett)
            {
                Console.WriteLine(item);
            }
        }
		static void ErosE(List<Karakter> karakterek)
		{
            foreach (var item in karakterek)
            {
                if (item.Ero > 50)
				{
                    Console.WriteLine(item.Nev + " karakter ereje meghaladja az 50-et");
                }
				else
				{
                    Console.WriteLine(item.Nev + " karakter ereje nem haladja meg az 50-et");
                }
            }
        }
		static void KarakterSzintSzures(List<Karakter> karakterek)
		{
			List<Karakter> szurt = [];
			Console.Write("Mennyi szintnél magasabbak legyenek a karakterek: ");
			int hasonlito = Convert.ToInt16(Console.ReadLine());
            foreach (var item in karakterek)
            {
                if (item.Szint > hasonlito)
				{
					szurt.Add(item);
				}
            }
            foreach (var item in szurt)
            {
                Console.WriteLine(item);
            }
        }
		static void CSVLetrehozas(List<Karakter> karakterek)
		{
			string ut = "karakterek.csv";
			using (StreamWriter writer = new(ut))
			{
                foreach (var item in karakterek)
                {
					var line = string.Format("{0};{1};{2};{3}", item.Nev, item.Szint, item.Eletero, item.Ero);
					writer.WriteLine(line);
					writer.Flush();
                }
            }
            Console.WriteLine("CSV fájl létrehozva");
        }
		static void CSVBeolvasasVisszaadas(string fajlnev)
		{
			string[] sorok = File.ReadAllLines(fajlnev);
			List<Karakter> karakterek = [];
			foreach (var sor in sorok)
			{
				string[] szavak = sor.Split(";");
				Karakter karakter = new(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}
			foreach (var item in karakterek)
			{
                Console.WriteLine(item);
            }
		}
		static void Top3(List<Karakter> karakterek)
		{
            List<Karakter> rendezett = karakterek.OrderBy(o => o.Ero + o.Szint).ToList();
            rendezett.Reverse();
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine(rendezett[i].Nev + " " + rendezett[i].Szint + " " + rendezett[i].Ero);
			}
        }
		static void Beolvasas(string fajlnev, List<Karakter> karakterek)
		{
			StreamReader sr = new(fajlnev);

            sr.ReadLine();

			while (!sr.EndOfStream) 
			{ 
				string[] szavak = sr.ReadLine().Split(";");
				Karakter karakter = new(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);
			}
        }
	}
}
