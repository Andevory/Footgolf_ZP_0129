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
    }
}