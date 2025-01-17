using Proiect_Poo;

namespace Proiect_Poo;

public class Orar
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

public class StatiiIntermediare
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
        Console.WriteLine($" * Statii intermediare: {Statie1.NumeStatie} - {Statie2.NumeStatie}");
    }
}

internal class RutaIntreDouaStatii
{
    // statii intermediare, orar, durata, cost

    public StatiiIntermediare StatiiIntermediare { get; set; }
    private string Id;
    internal float Cost { get; set; }
    public Orar Orar;
    public TimeSpan Durata;
    internal string NumeRuta { get; set; }
    internal bool RutaActiva { get; set; }
    private List<Tren> TrenuriDisponibile;
    internal List<Calator> ListaCalatori;
    internal float distanta;

    public List<Tren> GetTrenuriDisponibile()
    {
        return TrenuriDisponibile;
    }

    internal string GetRutaId() => Id;
    public RutaIntreDouaStatii()
    {

    }
    public RutaIntreDouaStatii(string id, StatiiIntermediare statiiIntermediare, Orar orar, float distanta, bool rutaActiva, List<Tren> trenuriDisponibile, List<Calator> listaCalatori)
    {
        TrenuriDisponibile = trenuriDisponibile;
        StatiiIntermediare = statiiIntermediare;
        Orar = orar;
        
        TimeSpan diff= Orar.DataSosire - Orar.DataPlecare;
        Durata = diff;
        
        Id = id;
        RutaActiva = true;
        ListaCalatori = listaCalatori;
        this.distanta = distanta;
    }
    
    public RutaIntreDouaStatii(string id, StatiiIntermediare statiiIntermediare, Orar orar, float cost)
    {
        TrenuriDisponibile = new List<Tren>();
        StatiiIntermediare = statiiIntermediare;
        Orar = orar;
        TimeSpan diff= Orar.DataSosire - Orar.DataPlecare;;
        Durata = diff; 
        Id = id;
        Cost = cost;
        RutaActiva = true;
        ListaCalatori = new List<Calator>();
        this.distanta= 0;
    }
    public RutaIntreDouaStatii(string id, StatiiIntermediare statiiIntermediare, Orar orar, float cost, float distanta)
    {
        TrenuriDisponibile = new List<Tren>();
        StatiiIntermediare = statiiIntermediare;
        Orar = orar;
        TimeSpan diff= Orar.DataSosire - Orar.DataPlecare;
        Durata = diff; 
        Id = id;
        Cost = cost;
        RutaActiva = true;
        ListaCalatori = new List<Calator>();
        this.distanta= distanta;
    }
    
    internal TimeSpan AnulareRezervare(Calator? calator)
    {
        // Anulare rezervare calator
        // Anularea trebuie să fie confirmată înainte să înceapă perioada de 24 de ore până la plecare.
        var diff = calator.IstoricOrarCalator.DataPlecare  - DateTime.Now ;
        if(calator!=null){
            if (diff.TotalHours >= 24f)  // daca calatorul face anularea pana începe perioada de 24 de ore până la plecare.
            {
                Console.WriteLine(" | SUCCESS | Anulare rezervare!");
                ListaCalatori.Remove(calator);
            }
            else // daca calatorul face anularea dupa ce incepe perioada de 24 de ore până la plecare.
            {
                Console.WriteLine($" | FAILED | Nu se mai poate anula rezervarea! tip depasit = {diff.ToString()}"); 
            }
            Console.WriteLine();
        }

        return diff;
    }
    
    internal void AdaugareCalatori(List<Calator> calatori)
    {
        // Adauga o lista de calatori
        ListaCalatori.AddRange(calatori);
    }
    
    internal void AdaugareCalator(Calator calator, Tren tren, int numarVagon,int numarLoc)
    {
        // Adauga un calator si ii atribuie un loc
        ListaCalatori.Add(calator);
        tren.rezervareLoc(numarVagon, numarLoc);
    }
    internal void AdaugareCalator(Calator calator)
    {
        ListaCalatori.Add(calator);
    }
    public void AfisareTrenuriDisponibile(int tipMoneda)
    {
        Console.WriteLine(" * Trenuri disponibile: ");
        foreach (Tren tr in TrenuriDisponibile)
        {
            tr.AfisareTren(tipMoneda);
        }
        Console.WriteLine("");
    }
    
    public void AfisareDetaliiRuta(int tipMoneda)
    {
        MonedaDollar d = new MonedaDollar();
        MonedaEuro eu = new MonedaEuro();
        MonedaLei l = new MonedaLei();
        
        Console.Write($"  * Detalii ruta:\n  - Orar: ");
        Orar.AfisareOrar();
        Console.WriteLine($"  - Durata: {Durata.Days} zile, {Durata.Hours} ore, {Durata.Minutes} minute.");
        Console.WriteLine($"  - Distanta: {distanta} km");
        if (tipMoneda == 0)
        {
            Console.WriteLine($"  - Cost: {eu.MonedaStr(Cost)}");
        }
        else
        {
            if (tipMoneda == 1)
            {
                Console.WriteLine($"  - Cost: {l.MonedaStr(Cost)}");
            }
            else
            {
                if (tipMoneda == 2)
                {
                    Console.WriteLine($"  - Cost: {d.MonedaStr(Cost)}");
                }
            }
        }
    }
    
    public Tren? GasesteTrenDupaId(string id)
    {
        // Gasire tren dupa id.
        foreach (Tren tr in TrenuriDisponibile)
        {
            if (tr.GetTrenId() == id)
            {
                return tr;
            }
        }
        return null;
    }

    public RutaIntreDouaStatii DeepCopy() 
    {
        // Se creeaza un nou obiect RutaIntreDouaStatii cu aceleasi valori pentru toate proprietatile sale, asigurandu-se ca modificarile ulterioare ale copiei nu afecteaza lista originala.
        return new RutaIntreDouaStatii(Id, StatiiIntermediare , Orar, distanta, RutaActiva, TrenuriDisponibile, ListaCalatori);
    }
    public List<Tren> GasesteTrenuriDupaListaId(string[] listaId)
    {
        // Se face gasirea trenurilor dupa o lista data de id-uri.
        var listaTrenuri = new List<Tren>();
        foreach (string id in listaId)
        {
            var ok = false;
            for(int i = 0; i < TrenuriDisponibile.Count && ok==false; i++)
            {
                if (TrenuriDisponibile[i].GetTrenId() == id)
                {
                    ok = true;
                    listaTrenuri.Add(TrenuriDisponibile[i]);
                }
            }
        }

        return listaTrenuri;
    }

    internal void AfisareIstoricCalatori()
    {
        // Se face afisarea istoricului de calatori doar daca lista de calatori este nevida, altfel mesaj corespunzator.
        if(ListaCalatori.Count>0)
        {
            foreach (var c in ListaCalatori)
            {
                c.AfisareCalator();
            }
        }
        else
        {
            Console.WriteLine($" | FAILED | Nu exista calatori pentru ruta data de statiile {StatiiIntermediare.Statie1.NumeStatie} - {StatiiIntermediare.Statie2.NumeStatie}.");
        }
    }
    
    public void AdaugareTrenuriDisponibile(string[] id)
    {
        // adauga trenuri disponibile dupa id.
        var listaTrenuri = GasesteTrenuriDupaListaId(id);
        if(listaTrenuri.Count > 0)
            TrenuriDisponibile.AddRange(listaTrenuri);
    }
    
    public void AdaugareTrenDisponibil(string id)
    {
        // adauga tren disponibil dupa id.
        var tren = GasesteTrenDupaId(id);
        if(tren!=null)
            TrenuriDisponibile.Add(tren);
    }
    
    public void StergereTrenDisponibil(string id)
    {
        // sterge tren disponibil dupa id.
        var tren = GasesteTrenDupaId(id);
        if(tren!=null)
            TrenuriDisponibile.Remove(tren);
    }
    
    public void AdaugareTrenuriDisponibile(List<Tren> trenuri)
    {
        // adauga trenuri disponibile.
        TrenuriDisponibile.AddRange(trenuri);
    }
    
    public void AdaugareTrenDisponibil(Tren tren)
    {
        // adauga tren disponibil.
        TrenuriDisponibile.Add(tren);
    }
    
    public void StergereTrenDisponibil(Tren tren)
    {
        // sterge tren disponibil.
        TrenuriDisponibile.Remove(tren);
    }
    
    public void StergereTrenuriDisponibile(List<Tren> trenuri)
    {
        // sterge trenuri disponibilile.
        foreach (var tren in trenuri)
        {
            TrenuriDisponibile.Remove(tren);
        }
    }
    
    public void StergereToateTrenuriDisponibile()
    {
        // sterge toate trenurile disponibile.
        TrenuriDisponibile.Clear();
    }
}