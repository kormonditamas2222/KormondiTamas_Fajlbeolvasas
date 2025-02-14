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
