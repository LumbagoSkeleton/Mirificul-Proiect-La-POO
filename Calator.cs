using Proiect_Poo;

namespace Proiect_Poo;

internal class Calator
{
    internal int id;
    internal string nume{ get; private set; }
    internal string prenume;
    internal int numarLoc=0;
    private int varsta;
    internal int clasa { get; private set; }
    internal string idTren { get; set; }
    internal int numarVagon { get; set; }

    internal DateTime Datarezervare;
    internal Orar IstoricOrarCalator { get; set; }
    
    

    public Calator(string nume, string prenume, int varsta, int clasa, string idTren, int numarVagon, Orar istoricOrarCalator, DateTime datarezervare, int numarLoc)
    {
        Random random = new Random();
        
        id = random.Next(0, 1000000); // generare automata de id random pentru Calator ( de forma xxxxxx, 0 -> 999999 inclusiv)
        this.nume = nume;
        this.prenume = prenume;
        this.varsta = varsta;
        this.clasa = clasa;
        this.numarLoc = numarLoc;
        idTren = idTren;
        numarVagon = numarVagon;
        IstoricOrarCalator = istoricOrarCalator;
        Datarezervare = datarezervare;
    }
    
    public Calator(string nume, string prenume, int varsta, int clasa, DateTime datarezervare, int numarLoc)
    {
        this.nume = nume;
        this.prenume = prenume;
        this.varsta = varsta;
        this.clasa = clasa;
        this.numarLoc = numarLoc;
        Datarezervare = datarezervare;
    }
    
    public Calator(string nume, string prenume, int varsta, int clasa, DateTime datarezervare)
    {
        this.nume = nume;
        this.prenume = prenume;
        this.varsta = varsta;
        this.clasa = clasa;
        Datarezervare = datarezervare;
    }
    internal void AfisareCalator()
    {
        Console.WriteLine($"* Nume: {nume}; Prenume: {prenume}; Varsta: {varsta}; Clasa: {clasa}; IdTren: {idTren}; NumarVagon: {numarVagon}; NumarLoc: {numarLoc}\n  ");
        IstoricOrarCalator.AfisareOrar();
    }
}