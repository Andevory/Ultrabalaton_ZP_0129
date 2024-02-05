string[] input = File.ReadAllLines("ub2017egyeni.txt");
List<Verseny> data = new List<Verseny>();
for (int i = 1; i < input.Length; i++)
{
    data.Add(new Verseny(input[i]));
}

Console.WriteLine($"A versenyen {data.Count} résztvevő indult");

int db = 0;
for (int i = 0; i < data.Count; i++)
{
    if (data[i].Kategoria == "Noi" && data[i].Tavszaz == 100)
    {
        db++;
    }
}
Console.WriteLine($"A versenyt teljesítő női résztvevők száma: {db}");

double osszido = 0;
db = 0;
for (int i = 0; i < data.Count; i++)
{
    if (data[i].Kategoria == "Ferfi" && data[i].Tavszaz == 100)
    {
        osszido += data[i].IdoOraban();
        db++;
    }
}
Console.WriteLine($"A teljes távot teljesítő férfi résztvevők átlag ideje: {osszido/db}");

struct Verseny
{
    public string Nev;
    public string Rajtszam;
    public string Kategoria;
    public string Vido;
    public int Tavszaz;

    public Verseny(string line)
    {
        string[] splitted = line.Split(';');
        this.Nev = splitted[0];
        this.Rajtszam = splitted[1];
        this.Kategoria = splitted[2];
        this.Vido = splitted[3];
        this.Tavszaz = int.Parse(splitted[4]);
    }

    public double IdoOraban()
    {
        string[] splitted = this.Vido.Split(":");
        int vora = int.Parse(splitted[0]);
        int vperc = int.Parse((splitted[1]));
        int vmperc = int.Parse((splitted[2]));
        return vora + (vperc/60) + (vmperc/3600);
    }
}