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
