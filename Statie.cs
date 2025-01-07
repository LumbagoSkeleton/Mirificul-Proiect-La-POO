namespace Proiect_Poo;

public class Statie
{
    public string NumeStatie { get; set; }
    public string Locatie { get; set; }

    public Statie(string numeStatie, string locatie)
    {
        NumeStatie = numeStatie;
        Locatie = locatie;
    }
}