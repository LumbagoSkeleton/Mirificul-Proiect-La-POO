using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Bogus
{
    internal class Administrator : Calator
    {
        protected ListaDeRute listaRute;
        protected List<Tren> listaTrenuri;

        public Administrator(string nume, string prenume, string varsta, int clasa, string id_tren, int numar_vagon, Orar istoricOrarCalator, DateTime dataRezervare) : base(nume, prenume, varsta, clasa, id_tren, numar_vagon, istoricOrarCalator, dataRezervare) { }

        public void AdaugaRuta(string id, StatiiIntermediare statiiIntermediare, Orar orar, float durata, float cost)
        {
            Ruta ruta = new Ruta(id, statiiIntermediare, orar, durata, cost);
            listaRute.AdaugareRuta(ruta);
        }

        public void StergeRuta(Ruta ruta)
        {
            listaRute.StergereRuta(ruta);
        }

        public void SemnalareIntarziereRuta(Tren tren, Ruta ruta, TimeSpan durata)
        {
            //Console.WriteLine("Trenul " + tren.GetTrenId() + " pe ruta " + ruta.GetRutaId() + " va intarzia cu  durata.ToString + " minute!");
            ruta.AdaugareIntarziere(durata);
        }

        public void VizualizareIstoricUtilizator(Calator calator)
        {
            calator.AfisareIstoric();
        }

        public void AdaugaTren(Tren tren)
        {
            listaTrenuri.Add(tren);
        }

        public void StergeTren(Tren tren)
        {
            listaTrenuri.Remove(tren);
        }

        public void GolesteListaTrenuri()
        {
            listaTrenuri.Clear();
        }

        public void AdaugaVagon(Tren tren, int capacitate, int nr, int clasa)
        {
            tren.addVagon(capacitate, nr, clasa);
        }

        public void StergeVagon(Tren tren, int nrVagon)
        {
            tren.removeVagon(nrVagon);
        }
    }
}
