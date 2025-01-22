using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Poo
{
    internal class Ruta
    {
        internal List<RutaIntreDouaStatii> ruta;

        //internal List<Statie> StatiiIntermediare = new List<Statie>();
        internal int nrStatii { get; }

        internal Statie statieStart { get; }
        internal Statie statieStop { get; }
        internal Orar Durata { get; set; }
        
        internal Tren TrenRuta { get; set; }
        
        private float distantaTotala;
        
        public Ruta()
        {
            ruta = new List<RutaIntreDouaStatii>();
        }

        internal List<RutaIntreDouaStatii> getRuteMici()
        {
            return ruta;
        }

        public void AdaugareRutaMica(RutaIntreDouaStatii rutaIntreDouaStatii)
        {
            // adaugare ruta mica
            ruta.Add(rutaIntreDouaStatii);
        }
    
        public void StergereRutaMica(RutaIntreDouaStatii rutaIntreDouaStatii)
        {
            // sterge ruta mica
            ruta.Remove(rutaIntreDouaStatii);
        }

        public void AdaugareRuteMici(List<RutaIntreDouaStatii> rute)
        {
            // adaugare rute mici
            ruta.AddRange(rute);
        }

        public void StergeRuteMici(List<RutaIntreDouaStatii> rute)
        {
            // sterge rute mici
            ruta.Clear(); 
        }
    
        public int NumarDeRuteMici()
        {
            return ruta.Count();
        }

        internal List<RutaIntreDouaStatii> GetRuteMici()
        {
            return ruta;
        }

        internal List<Statie> ListaDeStatiiIntermediare(string statieDeStart, string statieDeSosire)
        {
            var listaDeStatiiInterm = new List<Statie>();
            
            for (int i=0;i<ruta.Count;i++)
            {
                
                if (ruta[i].StatiiIntermediare.Statie1.NumeStatie == statieDeStart &&
                    ruta[i].StatiiIntermediare.Statie2.NumeStatie != statieDeSosire)
                {
                    var ok = false;
                    foreach (var st in listaDeStatiiInterm)
                    {
                        if (ruta[i].StatiiIntermediare.Statie2 == st)
                        {
                            ok = true;
                        }
                    }
                    if(ok == false)
                        listaDeStatiiInterm.Add(ruta[i].StatiiIntermediare.Statie2);
                }
                else
                {
                    if (ruta[i].StatiiIntermediare.Statie1.NumeStatie != statieDeStart &&
                        ruta[i].StatiiIntermediare.Statie2.NumeStatie == statieDeSosire)
                    {
                        var ok = false;
                        foreach (var st in listaDeStatiiInterm)
                        {
                            if (ruta[i].StatiiIntermediare.Statie1 == st)
                            {
                                ok = true;
                            }
                        }
                        if(ok == false)
                            listaDeStatiiInterm.Add(ruta[i].StatiiIntermediare.Statie1);
                    }
                    else
                    {
                        if (ruta[i].StatiiIntermediare.Statie1.NumeStatie != statieDeStart &&
                            ruta[i].StatiiIntermediare.Statie2.NumeStatie != statieDeSosire)
                        {
                            var ok = false;
                            foreach (var st in listaDeStatiiInterm)
                            {
                                if (ruta[i].StatiiIntermediare.Statie2 == st)
                                {
                                    ok = true;
                                }
                            }
                            if(ok == false)
                                listaDeStatiiInterm.Add(ruta[i].StatiiIntermediare.Statie2);
                        }
                    }
                }
            }

            foreach (var st in listaDeStatiiInterm)
            {
                Console.WriteLine($"                   NumeStatie: {st.NumeStatie} Locatie: {st.Locatie}");
            }

            return listaDeStatiiInterm;
        }
        public Ruta(List<RutaIntreDouaStatii> rut, Tren trenRuta)
        {
            this.ruta = rut;
            nrStatii = getNrStatii();
            
            TrenRuta = trenRuta;
            
            var statieDeStart = getRuteMici()[0].StatiiIntermediare.Statie1;
            var statieDeSosire = getRuteMici()[getRuteMici().Count - 1].StatiiIntermediare.Statie2;

            statieStart = statieDeStart;
            statieStop = statieDeSosire;
            
            Orar durata = new Orar(ruta[0].Orar.DataPlecare, ruta[ruta.Count - 1].Orar.DataSosire);
            Durata = durata;

            if (ruta[0].Orar.DataPlecare > ruta[ruta.Count - 1].Orar.DataSosire)
            {
                throw new ArgumentException($" | ERROR | Data plecare de la ruta mare {statieStart.NumeStatie} -> {statieStop.NumeStatie} > Data sosire, ceea ce nu se poate!");
            }
            
            distantaTotala = getDistantaTotala();
        }

        public int getNrStatii()
        {
            int statii = 0;
            foreach (RutaIntreDouaStatii aux in ruta)
                if (ruta.Count == 1)
                    break;
                else
                    statii++;

            return statii;
        }
        public float getDistantaTotala()
        {
            float distantaAux=0;
            foreach (RutaIntreDouaStatii aux in ruta)
            {
                distantaAux += aux.distanta;
            }
            return distantaAux;
        }

        internal void AfisareRutaMare(int tipMoneda)
        {
            Console.WriteLine(" | OUTPUT | Afisare Ruta Mare: ");

            var statieDeStart = statieStart;
            var statieDeSosire = statieStop;
            var NumeRuta = statieDeStart.NumeStatie + " -> " + statieDeSosire.NumeStatie;
            Console.WriteLine($" | OUTPUT | * Ruta cu numele {NumeRuta}:");
            Console.WriteLine(
                $"                * Ruta are statia de start: {statieDeStart.NumeStatie} si statia de sosire: {statieDeSosire.NumeStatie}");
            Console.WriteLine($"                * Ruta are {getDistantaTotala()} kilometri");
            var Diff = Durata.DataSosire - Durata.DataPlecare;
            Console.WriteLine(
                $"                * Data Plecare: {Durata.DataPlecare} - Data Sosire: {Durata.DataSosire} si dureaza {Diff.Days} zile, {Diff.Hours} ore si {Diff.Minutes} minute");
            Console.WriteLine("     Afisare tren: ");
            TrenRuta.AfisareTren(tipMoneda);

            Console.Write($"                  * Ruta are urmatoarele statii intermediare: \n");
            var listaDeStatiiInterm = ListaDeStatiiIntermediare(statieDeStart.NumeStatie, statieDeSosire.NumeStatie);

            foreach (var rutaMica in getRuteMici())
            {
                rutaMica.StatiiIntermediare.AfisareStatii();
                rutaMica.AfisareDetaliiRuta(tipMoneda);
            }
        }
    }
}
