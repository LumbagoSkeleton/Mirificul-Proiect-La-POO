namespace Proiect_Poo;

internal class RuteMari
{
    internal List<Ruta> ruteMari = new List<Ruta>();

    public RuteMari()
    {
    }

    public RuteMari(List<Ruta> ruteMari)
    {
        this.ruteMari = ruteMari;
    }

    internal void StergeRutaMare(Ruta ruta)
    {
        ruteMari.Remove(ruta);
    }

    internal void StergeRuteMari(List<Ruta> ruteMari)
    {
        foreach (Ruta ruta in ruteMari)
        {
            ruteMari.Remove(ruta);
        }
    }

    internal void AdaugaRutaMare(Ruta ruta)
    {
        ruteMari.Add(ruta);
    }

    internal void AdaugaRuteMari(List<Ruta> rutemari)
    {
        ruteMari.AddRange(rutemari);
    }

    internal Ruta? CautareRutaMare(Statie st1, Statie st2)
    {
        foreach (var rutaMare in ruteMari)
        {
            if (rutaMare.statieStart == st1 && rutaMare.statieStop == st2)
            {
                Console.WriteLine(" | SUCCEEDED | Ruta mare gasita! ");
                return rutaMare;
            }
        }
        
        return null;
    }
    internal void AfisareRuteMari(int tipMoneda)
    {
        var contor = 0;
        foreach (var rute in ruteMari)
        {
            var statieDeStart = rute.statieStart;
            var statieDeSosire = rute.statieStop;
            var NumeRuta = statieDeStart.NumeStatie + " -> " + statieDeSosire.NumeStatie;
            Console.WriteLine($" | OUTPUT | * Ruta {contor++} cu numele {NumeRuta}:");
            Console.WriteLine($"                * Ruta are statia de start: {statieDeStart.NumeStatie} si statia de sosire: {statieDeSosire.NumeStatie}");
            Console.WriteLine($"                * Ruta are {rute.getDistantaTotala()} kilometri");
            var Diff = rute.Durata.DataSosire - rute.Durata.DataPlecare;
            Console.WriteLine($"                * Data Plecare: {rute.Durata.DataPlecare} - Data Sosire: {rute.Durata.DataSosire} si dureaza {Diff.Days} zile, {Diff.Hours} ore si {Diff.Minutes} minute");
            Console.WriteLine("     Afisare tren: ");
            rute.TrenRuta.AfisareTren(tipMoneda);
                            
            Console.Write($"                  * Ruta are urmatoarele statii intermediare: \n");
            var listaDeStatiiInterm = rute.ListaDeStatiiIntermediare(statieDeStart.NumeStatie, statieDeSosire.NumeStatie);
                            
            foreach (var rutaMica in rute.getRuteMici())
            {
                rutaMica.StatiiIntermediare.AfisareStatii();
                rutaMica.AfisareDetaliiRuta();
            }
        }
        Console.WriteLine();
    }
    
}