using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Poo
{
    internal class Vagon
    {
        private int capacitate_vagon;
        private int numar_vagon;
        private int clasa;

        /*clasa = 0 vagon compartiment 
          clasa = 1 clasa 1
          clasa = 2 clasa 2
          clasa = 3 vagon restaurant*/

        public Vagon(int capacitate_vagon, int numar_vagon,int clasa)
        {
            this.capacitate_vagon = capacitate_vagon;
            this.numar_vagon = numar_vagon;
            this.clasa = clasa;
        }
        public int getNumarVagon()
        {
            return numar_vagon;
        }
        
        public int getclasa()
        {
            return clasa;
        }

        public int getcapacitate_vagon()
        {
            return capacitate_vagon;
        }
        public void AfisareVagon()
        {
            Console.WriteLine($"* Vagon cu capacitatea: {capacitate_vagon}, numarulul vagonului: {numar_vagon}, si clasa: {clasa};");

        }
    }
}
