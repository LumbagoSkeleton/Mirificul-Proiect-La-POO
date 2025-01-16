using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Poo
{
    // adauga o functie sa calculezi pretul in functie de distanta sau ceva
    internal class Tren
    {
        internal string id;
        private int numarTren;
        internal int capacitateTren = 0;
        internal int numarCalatori = 0;
        internal List<Statie> listaOpriri = new List<Statie>();
        internal float pret { get; set; }
        private List<Vagon> listaVagoane;
        internal string GetTrenId() => id;
        internal int GetNumar_tren() => numarTren;
        internal List<Vagon> GetlistaVagoane() => listaVagoane;
        internal Ruta rutaTren;
        public Tren (string id, int numarTren, Ruta rutaTren)
        {
            this.id = id;
            this.numarTren = numarTren;
            listaVagoane = new List<Vagon>();
            this.rutaTren = rutaTren;
        }

        public void addVagon(int capacitateVagon, int numarVagon, int clasa, int numarRanduri, int numarLocuriPeRand)
        {
            // adauga un singur vagon cu capacitatea ca primul parametru
            Vagon aux =new Vagon(capacitateVagon, numarVagon, clasa, numarRanduri, numarLocuriPeRand );
            listaVagoane.Add(aux);
            capacitateTren=capacitateTren+capacitateVagon;
        }
        public void addVagons(List<int> capacitateVagon, List<int> numereVagon,List<int> clase, List<int> numereRanduri, List<int> numereLocuriPeRand)
        {
            // adauga mai multe vagoane, fiecare parametru e o lista
            
            for(int i=0;i<numereVagon.Count;i++)
            {
                Vagon aux = new Vagon(capacitateVagon[i], numereVagon[i], clase[i], numereRanduri[i], numereLocuriPeRand[i]);
                listaVagoane.Add(aux);
                capacitateTren = capacitateTren + capacitateVagon[i];
            }
        }
        public void removeVagons(List<int> numereVagon)
        {
            //sterge vagoanele cu numarul specificat din tren (numerele vagoanelor sunt trimise printr-o lista)
            foreach(int i in numereVagon)
            {
               foreach(Vagon j in listaVagoane)
                    if (i==j.getnumarVagon())
                    {
                        listaVagoane.Remove(j);
                        break;
                    }
            }
        }
        public void removeVagon(int numarVagon)
        {
            // sterge vagonul cu numarul specificat din tren
            foreach (Vagon j in listaVagoane)
                if (numarVagon == j.getnumarVagon())
                {
                    listaVagoane.Remove(j);
                    break;
                }
        }

        public void AfisareTren()
        {
            Console.WriteLine($"    * Tren cu id-ul: {id}, numarul trenului: {numarTren}, capacitatea trenului: {capacitateTren}, si pretul: {pret}");
            foreach (Vagon j in listaVagoane)
            {
                j.AfisareVagon();
            }
        }
        public virtual float CalculeazaPret(Ruta ruta)
        {
            return 0;
        }
        public virtual List<Statie> SetListaOpriri(List<Statie>opriri)
        {
            return new List<Statie>();
        }
    }
}
