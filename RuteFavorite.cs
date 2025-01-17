namespace Proiect_Poo;

public class RuteFavorite
{
    private List<Ruta> RuteMariFavorite;
    private List<RutaIntreDouaStatii> RuteMiciFavorite;

    public RuteFavorite()
    {
        RuteMariFavorite = new List<Ruta>();
        RuteMiciFavorite = new List<RutaIntreDouaStatii>();
    }

    internal void AdaugareRutaMareFav(Ruta ruta)
    {
        RuteMariFavorite.Add(ruta);
    }
    
    internal void AdaugareRutaIntreDouaStatiiFav(RutaIntreDouaStatii ruta)
    {
        RuteMiciFavorite.Add(ruta);
    }
    
    internal void StergereRutaMareFav(Ruta ruta)
    {
        RuteMariFavorite.Remove(ruta);
    }
    
    internal void StergereRutaIntreDouaStatiiFav(RutaIntreDouaStatii ruta)
    {
        RuteMiciFavorite.Remove(ruta);
    }

    internal void AfisareRuteMariFav(int tipMoneda)
    {
        Console.WriteLine(" | OUTPUT | Afisare Rute Mari Favorite: ");
        foreach (Ruta ruta in RuteMariFavorite)
        {
            ruta.AfisareRutaMare(tipMoneda);
        }
        Console.WriteLine("");
    }
    
    internal void AfisareRuteMiciFav(int tipMoneda)
    {
        Console.WriteLine(" | OUTPUT | Afisare Rute Mici Favorite: ");
        foreach (var ruta in RuteMiciFavorite)
        {
            ruta.StatiiIntermediare.AfisareStatii();
            ruta.AfisareDetaliiRuta(tipMoneda);
        }
        Console.WriteLine("");
    }
}