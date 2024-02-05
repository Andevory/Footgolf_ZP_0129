string[] input = File.ReadAllLines("fob2016.txt");
List<Verseny> data = new List<Verseny>();
for (int i = 0; i < input.Length; i++)
{
    data.Add(new Verseny(input[i]));
}

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