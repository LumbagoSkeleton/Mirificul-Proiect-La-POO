using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Poo
{
    internal class Ruta
    {
        private List<RutaIntreDouaStatii> ruta;
        private int nrStatii;
        private Orar durata;
        private float distantaTotala;
        public Ruta(List<RutaIntreDouaStatii> ruta)
        {
            this.ruta = ruta;
            nrStatii = getNrStatii();
            durata.DataPlecare = ruta[0].Orar.DataPlecare;
            durata.DataSosire = ruta[ruta.Count-1].Orar.DataSosire;
            distantaTotala = getDistantaTotala();
            
        }

        public int getNrStatii()
        {
            int statii = 2;
            foreach (RutaIntreDouaStatii aux in ruta)
                if (ruta.Count == 1)
                    break;
                else
                    statii++;

            return statii;
        }
        public float getDistantaTotala()
        {
            float distanta_aux=0;
            foreach (RutaIntreDouaStatii aux in ruta)
                distanta_aux = distanta_aux+aux.distanta;
            return distanta_aux;
        }
    }
}
