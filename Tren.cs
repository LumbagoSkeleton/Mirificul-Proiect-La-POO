using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Poo
{
    // adauga o functie sa calculezi pretul in functie de distanta sau ceva idk
    internal abstract class Tren
    {
        private string id;
        private int numar_tren;
        private int capacitate_tren = 0;
        private float pret = 0;
        private List<Vagon> listaVagoane;
        internal string GetTrenId() => id;
        internal int Getnumar_tren() => numar_tren;
        internal List<Vagon> GetlistaVagoane() => listaVagoane;
        
        public Tren (string id, int numar_tren)
        {
            this.id = id;
            this.numar_tren= numar_tren;
            listaVagoane = new List<Vagon>();
        }

        public void addVagon(int capacitate_vagon, int numar_vagon, int clasa)
        {
            // adauga un singur vagon cu capacitatea ca primul parametru
            Vagon aux =new Vagon(capacitate_vagon, numar_vagon,clasa);
            listaVagoane.Add(aux);
            capacitate_tren=capacitate_tren+capacitate_vagon;
        }
        public void addVagons(List<int> capacitate_vagon, List<int> numere_vagon,List<int> clase)
        {
            // adauga mai multe vagoane, fiecare parametru e o lista
            
            for(int i=0;i<numere_vagon.Count;i++)
            {
                Vagon aux = new Vagon(capacitate_vagon[i], numere_vagon[i], clase[i]);
                listaVagoane.Add(aux);
                capacitate_tren = capacitate_tren + capacitate_vagon[i];
            }
        }
        public void removeVagons(List<int> numere_vagon)
        {
            //sterge vagoanele cu numarul specificat din tren (numerele vagoanelor sunt trimise printr o lista)
            foreach(int i in numere_vagon)
            {
               foreach(Vagon j in listaVagoane)
                    if (i==j.getNumarVagon())
                    {
                        listaVagoane.Remove(j);
                        break;
                    }
            }
        }
        public void removeVagon(int numar_vagon)
        {
            // sterge vagonul cu numarul specificat din tren
            foreach (Vagon j in listaVagoane)
                if (numar_vagon == j.getNumarVagon())
                {
                    listaVagoane.Remove(j);
                    break;
                }
        }

        public void AfisareTren()
        {
            Console.WriteLine($"    * Tren cu id-ul: {id}, numarul trenului: {numar_tren}, capacitatea trenului: {capacitate_tren}, si pretul: {pret}");
            foreach (Vagon j in listaVagoane)
            {
                j.AfisareVagon();
            }
        }
    }
}
