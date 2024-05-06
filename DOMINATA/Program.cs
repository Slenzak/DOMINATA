class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj rozmiar listy:");
        int rozmiarListy;
        while (!int.TryParse(Console.ReadLine(), out rozmiarListy) || rozmiarListy < 1)
        {
            Console.WriteLine("Nieprawidłowa wartość. Podaj dodatnią liczbę całkowitą:");
        }

        List<int> lista = GenerujListe(rozmiarListy);

        Console.WriteLine("Wygenerowana lista liczb:");
        lista.ForEach(i => Console.Write(i + " "));
        Console.WriteLine();

        var dominanta = ZnajdzDominante(lista);
        Console.WriteLine("Dominanta zbioru to: " + dominanta.Key + " (występuje " + dominanta.Value + " razy)");
    }

    static List<int> GenerujListe(int rozmiar)
    {
        Random rnd = new Random();
        List<int> wynik = new List<int>();
        for (int i = 0; i < rozmiar; i++)
        {
            wynik.Add(rnd.Next(1, 101)); // Zakres wartości od 1 do 100
        }
        return wynik;
    }

    static KeyValuePair<int, int> ZnajdzDominante(List<int> lista)
    {
        Dictionary<int, int> liczbaWystapien = new Dictionary<int, int>();

        foreach (int i in lista)
        {
            if (liczbaWystapien.ContainsKey(i))
            {
                liczbaWystapien[i]++;
            }
            else
            {
                liczbaWystapien.Add(i, 1);
            }
        }

        int dominanta = -1;
        int maksymalnaLiczbaWystapien = 0;
        foreach (var para in liczbaWystapien)
        {
            if (para.Value > maksymalnaLiczbaWystapien)
            {
                maksymalnaLiczbaWystapien = para.Value;
                dominanta = para.Key;
            }
        }

        return new KeyValuePair<int, int>(dominanta, maksymalnaLiczbaWystapien);
    }
}