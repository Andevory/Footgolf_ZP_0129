string[] input = File.ReadAllLines("fob2016.txt");
List<Verseny> data = new List<Verseny>();
for (int i = 0; i < input.Length; i++)
{
    data.Add(new Verseny(input[i]));
}

Console.WriteLine($"A versenyen {data.Count} résztvevő indult.");

double db = 0;
for (int i = 0;i < data.Count;i++)
{
    if (data[i].Kategoria == "Noi")
    {
        db++;
    }
}
Console.WriteLine($"A nők aránya a versenyen: {Math.Round((db / data.Count) * 100, 2)}%");

int maxn = 0;
for (int i = 0; i < data.Count; i++)
{
    if (data[i].Kategoria == "Noi" && data[maxn].Osszpont() < data[i].Osszpont())
    {
        maxn = i;
    }
}
Console.WriteLine($"A legjobb női résztvevő: {data[maxn].Nev}, pontszáma: {data[maxn].Osszpont()}");
struct Verseny
{
    public string Nev;
    public string Kategoria;
    public string EgyesuletNev;
    public List<int> Pontok;

    public Verseny(string line)
    {
        Pontok = new List<int>();
        string[] splitted = line.Split(';');
        this.Nev = splitted[0];
        this.Kategoria = splitted[1];
        this.EgyesuletNev = splitted[2];
        for (int i = 3; i < splitted.Length; i++)
        {
            Pontok.Add(int.Parse(splitted[i]));
        }
        Pontok.Sort();
    }

    public int Osszpont()
    {
        int sum = 0;
        for (int i = 2; i < Pontok.Count; i++)
        {
            sum += Pontok[i];
        }
        if (Pontok[0] > 0)
        {
            sum += 10;
        }
        if ((Pontok[1] > 0))
        {
            sum += 10;
        }
        return sum;
    }
}