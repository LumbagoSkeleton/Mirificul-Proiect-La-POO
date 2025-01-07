using ProjPooPartea1;

namespace Proiect_Poo;

internal class ListaDeRute
{
    public List<Ruta> Rute;

    public ListaDeRute()
    {
        Rute= new List<Ruta>();
    }

    protected void AdaugareRuta(Ruta ruta)
    {
        Rute.Add(ruta);
    }
    
    protected void StergereRuta(Ruta ruta)
    {
        Rute.Remove(ruta);
    }

    protected void AdaugareRute(List<Ruta> rute)
    {
        Rute.AddRange(rute);
    }

    protected void StergeToateRutele(List<Ruta> rute)
    {
        Rute.Clear(); 
    }
    
    protected int NumarDeRute()
    {
        return Rute.Count();
    }

    public int CautareRuteDisponibile(Statie St1, Statie St2)
    {
        int contor = 0;
        Console.WriteLine(" * Afisare trenuri disponibile si detalii ruta:");
        foreach (Ruta ruta in Rute)
        {
            if (ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St2.NumeStatie) == 0 && ruta.RutaActiva == true)
            {
                Console.WriteLine($"{++contor})");
                ruta.AfisareTrenuriDisponibile();
                ruta.AfisareDetaliiRuta();
            }
            else
            {
                if (ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                    ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St2.NumeStatie) == 0 && ruta.RutaActiva != true)
                {
                    Console.WriteLine($"{++contor})");
                    ruta.AfisareTrenuriDisponibile();
                    ruta.AfisareDetaliiRuta();
                }
                else
                {
                    if ((ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St1.NumeStatie) != 0 &&
                        ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St2.NumeStatie) == 0) ||
                        (ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                        ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St2.NumeStatie) != 0 ))
                    {
                        Console.WriteLine($"{++contor})");
                        GasireRutaComplexa(St1, St2);
                    }
                }
            }
        }

        return contor;
    }

    internal Ruta? DisponibilitateRutaFiz(Statie St1, Statie St2)
    {
        foreach (Ruta ruta in Rute)
        {
            if (ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St2.NumeStatie) == 0)
            {
                return ruta;
            }
        }
        return null;
    }

    List<StatiiIntermediare> ListaComplexaDeRute=  new List<StatiiIntermediare>();
    internal bool AlgortmGasireRutaComplexa(Statie statiaDeStart, Statie statiaDeSosire) // recursiv
    {
        var ok1 = false;
        var ok2 = false;
        var stop = false;
        for (int i = 0; i < Rute.Count && (ok1==false && ok2==false) ; i++)
        {

                if (Rute[i].StatiiIntermediare.Statie1.NumeStatie.CompareTo(statiaDeStart) == 0 && Rute[i].StatiiIntermediare.Statie2.NumeStatie.CompareTo(statiaDeSosire)!=0 )
                {
                    ok1 = true;
                    statiaDeStart = Rute[i].StatiiIntermediare.Statie2;
                    var StatiiIntermediare= Rute[i].StatiiIntermediare;
                    ListaComplexaDeRute.Add(StatiiIntermediare);
                }
                else
                {
                    if (Rute[i].StatiiIntermediare.Statie2.NumeStatie.CompareTo(statiaDeStart) ==0  && Rute[i].StatiiIntermediare.Statie1.NumeStatie.CompareTo(statiaDeSosire)!=0) 
                    {
                        ok2 = true;
                        statiaDeStart = Rute[i].StatiiIntermediare.Statie1;
                        var StatiiIntermediare= Rute[i].StatiiIntermediare;
                        ListaComplexaDeRute.Add(StatiiIntermediare);
                    }
                    else
                    {
                        if (Rute[i].StatiiIntermediare.Statie1.NumeStatie.CompareTo(statiaDeStart) == 0 &&
                            Rute[i].StatiiIntermediare.Statie2.NumeStatie.CompareTo(statiaDeSosire) == 0)
                        {
                            stop = true;
                            var StatiiIntermediare = Rute[i].StatiiIntermediare;
                            ListaComplexaDeRute.Add(StatiiIntermediare);
                        }
                        else
                        {
                            if (Rute[i].StatiiIntermediare.Statie2.NumeStatie.CompareTo(statiaDeStart) == 0 &&
                                Rute[i].StatiiIntermediare.Statie1.NumeStatie.CompareTo(statiaDeSosire) == 0)
                            {
                                stop = true;
                                var StatiiIntermediare = Rute[i].StatiiIntermediare;
                                ListaComplexaDeRute.Add(StatiiIntermediare);
                            }
                        }
                    }
                }
        }
        if((ok1 == true || ok2 == true) && stop == false)
            return AlgortmGasireRutaComplexa(statiaDeStart, statiaDeSosire);
        else
        {
            if ((ok1 != true && ok2 != true) || stop == true)
            {
                return stop;
            }
            else
            {
                if ((ok1 != true && ok2 != true) || stop == false)
                {
                    return stop;
                }
            }
        }
        return stop;
    }

    internal void AfisareListaStatii(List<StatiiIntermediare> lista)
    {
        float suma_durata = 0;
        float suma_cost = 0;
        foreach (var st in lista)
        {
            st.AfisareStatii();
            var ruta = DisponibilitateRutaFiz(st.Statie1, st.Statie2);
            if (ruta != null)
            {
                ruta.AfisareDetaliiRuta();
                suma_cost += ruta.Cost;
                suma_durata += ruta.Durata;
            }
        }
        Console.WriteLine($"Durata Totala: {suma_durata} iar pretul total: {suma_cost}");
    }
    internal void GasireRutaComplexa(Statie St1, Statie St2)
    {
        var RutaDirecta= DisponibilitateRutaFiz(St1, St2);
        if (RutaDirecta == null || RutaDirecta.RutaActiva == false)
        {
            // algoritm gasire ruta pe harta
            var statiaDeStart = St1;
            var statiaDeSosire = St2;
            ListaComplexaDeRute = new List<StatiiIntermediare>();
            var bl= AlgortmGasireRutaComplexa(statiaDeStart, statiaDeSosire);
            if (bl == true)
            {
                Console.WriteLine("Conexiune gasita!");
                AfisareListaStatii(ListaComplexaDeRute);
            }
            else
            {
                Console.WriteLine("Conexiune negasita!");
            }
        }
        else
        {
            RutaDirecta.AfisareTrenuriDisponibile();
            RutaDirecta.AfisareDetaliiRuta();
        }
    }

    internal void RezervareRutaCalatori(Statie St1, Statie St2, List<Calator> Calator)
    {
        foreach (var calat in Calator)
        {
            RezervareRutaCalator(St1, St2, calat);
        }
    }
    internal void RezervareRutaCalator(Statie St1, Statie St2, Calator Calator)
    {
        var d= DisponibilitateRutaFiz(St1, St2);
        if (d != null && d.RutaActiva == true)
        {
            Console.WriteLine("* Creare rezervare!");
            var ok = true;
            foreach (var tren in d.GetTrenuriDisponibile())
            {
                foreach (var vag in tren.GetlistaVagoane())
                {
                    if (vag.getcapacitate_vagon() > 0 && vag.getclasa() == Calator.clasa)
                    {
                        ok = true;
                        Calator.idTren = tren.GetTrenId();
                        Calator.numarVagon = vag.getNumarVagon();
                        d.AdaugareCalator(Calator);
                        Console.WriteLine($"* Rezervare creata pentru calatorul cu numele: {Calator.nume} in trenul cu numarul: {tren.Getnumar_tren()} !");
                    }
                }
            }
            if (ok == false)
            {
                Console.WriteLine("* Rezervare necreata! ( nu mai sunt locuri disponibile in vagonul specificat pentru calator )");
            }
        }
        else
        {
            Console.WriteLine("Nu exista ruta sau nu este activa!");
        }
    }
}