using Proiect_Poo;
using ProjPooPartea1;

namespace Proiect_Poo;

public abstract class Orar
{
    public DateTime DataPlecare { get; set; }
    public DateTime DataSosire { get; set; }

    public Orar(DateTime dataPlecare, DateTime dataSosire)
    {
        DataPlecare = dataPlecare;
        DataSosire = dataSosire;
    }

    internal void AfisareOrar()
    {
        Console.WriteLine($" DataPlecare: {DataPlecare.ToString("dd/MM/yyyy HH:mm:ss")} + DataSosire: {DataSosire.ToString("dd/MM/yyyy HH:mm:ss")}" );
    }
}

public abstract class StatiiIntermediare
{
    public Statie Statie1 {get; set;}
    public Statie Statie2 {get; set;}

    public StatiiIntermediare(Statie statie1, Statie statie2)
    {
        Statie1 = statie1;
        Statie2 = statie2;
    }

    internal void AfisareStatii()
    {
        Console.WriteLine($"Statii intermediare: {Statie1.NumeStatie} - {Statie2.NumeStatie}");
    }
}

internal class Ruta
{
    // statii intermediare, orar, durata, cost

    public StatiiIntermediare StatiiIntermediare { get; set; }
    private string Id;
    public Orar Orar;
    public float Durata;
    public float Cost;
    public bool RutaActiva { get; set; }
    private List<Tren> TrenuriDisponibile;
    private List<Calator> ListaCalatori;

    public List<Tren> GetTrenuriDisponibile()
    {
        return TrenuriDisponibile;
    }

    internal string GetRutaId() => Id;
    
    public Ruta(string id, StatiiIntermediare statiiIntermediare, Orar orar, float durata, float cost )
    {
        TrenuriDisponibile = new List<Tren>();
        StatiiIntermediare = statiiIntermediare;
        Orar = orar;
        Durata = durata;
        Cost = cost;
        Id = id;
        RutaActiva = true;
    }
    
    internal void AnulareRezervare(Calator? calator)
    {
        var diff = DateTime.Now - calator.Datarezervare;
        if(calator!=null){
            if (diff.Hours > 24) 
            {
            ListaCalatori.Remove(calator);
            }
            else
            {
                Console.WriteLine("Nu se mai poate anula rezervarea!");
            }
        }
    }
    
    internal void AdaugareCalatori(List<Calator> calatori)
    {
        ListaCalatori.AddRange(calatori);
    }
    
    internal void AdaugareCalator(Calator calator)
    {
        ListaCalatori.Add(calator);
    }
    public void AfisareTrenuriDisponibile()
    {
        Console.WriteLine(" * Trenuri disponibile: ");
        foreach (Tren tr in TrenuriDisponibile)
        {
            tr.AfisareTren();
            
        }
        Console.WriteLine("");
    }
    
    public void AfisareDetaliiRuta()
    {
        Console.WriteLine($" * Detalii ruta: Orar: {Orar} - Durata: {Durata} - Cost: {Cost}");
    }
    
    public Tren? GasesteTrenDupaId(string id)
    {
        foreach (Tren tr in TrenuriDisponibile)
        {
            if (tr.GetTrenId() == id)
            {
                return tr;
            }
        }
        return null;
    }
    
    public List<Tren> GasesteTrenuriDupaListaId(string[] listaId)
    {
        var ListaTrenuri = new List<Tren>();
        foreach (string id in listaId)
        {
            var ok = false;
            for(int i = 0; i < TrenuriDisponibile.Count && ok==false; i++)
            {
                if (TrenuriDisponibile[i].GetTrenId() == id)
                {
                    ok = true;
                    ListaTrenuri.Add(TrenuriDisponibile[i]);
                }
            }
        }

        return ListaTrenuri;
    }

    internal void AfisareIstoricCalatori()
    {
        foreach (var c in ListaCalatori)
        {
            c.IstoricOrarCalator.AfisareOrar();
        }
    }
    
    public void AdaugareTrenuriDisponibile(string[] id)
    {
        var listaTrenuri = GasesteTrenuriDupaListaId(id);
        if(listaTrenuri.Count > 0)
            TrenuriDisponibile.AddRange(listaTrenuri);
    }
    
    public void AdaugareTrenDisponibil(string id)
    {
        var tren = GasesteTrenDupaId(id);
        if(tren!=null)
            TrenuriDisponibile.Add(tren);
    }
    
    public void StergereTrenDisponibil(string id)
    {
        var tren = GasesteTrenDupaId(id);
        if(tren!=null)
            TrenuriDisponibile.Remove(tren);
    }
    
    public void AdaugareTrenuriDisponibile(List<Tren> trenuri)
    {
        TrenuriDisponibile.AddRange(trenuri);
    }
    
    public void AdaugareTrenDisponibil(Tren tren)
    {
        TrenuriDisponibile.Add(tren);
    }
    
    public void StergereTrenDisponibil(Tren tren)
    {
        TrenuriDisponibile.Remove(tren);
    }
    
    public void StergereToateTrenuriDisponibile()
    {
        TrenuriDisponibile.Clear();
    }
}