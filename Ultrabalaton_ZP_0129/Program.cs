﻿string[] input = File.ReadAllLines("ub2017egyeni.txt");
List<Verseny> data = new List<Verseny>();
for (int i = 0; i < input.Length; i++)
{
    data.Add(new Verseny(input[i]));
}

Console.WriteLine($"A versenyen {data.Count} résztvevő indult");

int db = 0;
for (int i = 0; i < data.Count; i++)
{
    if (data[i].Kategoria == "Női" && data[i].Tavszaz == 100)
    {
        db++;
    }
}
Console.WriteLine($"A versenyt teljesítő női résztvevők száma: {db}");

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
}