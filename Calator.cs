using Proiect_Poo;

namespace ProjPooPartea1;

internal abstract class Calator
{
    internal string nume{ get; private set; }
    private string prenume;
    private string varsta;
    internal int clasa { get; private set; }
    internal string idTren { get; set; }
    internal int numarVagon { get; set; }

    internal DateTime Datarezervare;
    internal Orar IstoricOrarCalator { get; private set; }
    
    

    public Calator(string nume, string prenume, string varsta, int clasa, string id_tren, int numar_vagon, Orar istoricOrarCalator, DateTime datarezervare)
    {
        this.nume = nume;
        this.prenume = prenume;
        this.varsta = varsta;
        this.clasa = clasa;
        this.idTren = id_tren;
        this.numarVagon = numar_vagon;
        this.IstoricOrarCalator = istoricOrarCalator;
        this.Datarezervare = datarezervare;
    }

    internal void AfisareCalator()
    {
        Console.WriteLine($"nume: {nume} prenume:{prenume} varsta:{varsta} clasa:{clasa} idTren:{idTren} numarVagon:{numarVagon}");
        IstoricOrarCalator.AfisareOrar();
    }
}