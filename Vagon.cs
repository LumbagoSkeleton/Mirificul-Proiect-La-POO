using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Poo
{
    internal class Loc
    {
        private int Id;
        internal int numarLoc;
        internal bool OcupareLoc { get; set; }

        public Loc(int numarLoc)
        {
            this.numarLoc = numarLoc;
            Random random = new Random();
            Id = random.Next(0, 1000000); // generare automata de id random pentru Loc ( de forma xxxxxx, 0 -> 999999 inclusiv)
            OcupareLoc = false;
        }
        
        public Loc(bool ocupareLoc, int numarLoc)
        {
            this.numarLoc = numarLoc;
            Random random = new Random();
            Id = random.Next(0, 1000000); // generare automata de id random pentru Loc ( de forma xxxxxx, 0 -> 999999 inclusiv)
            OcupareLoc = ocupareLoc;
        }

        internal bool AfisareOcupareLoc()
        {
            Console.Write($" | OUTPUT | Nr. Loc: {numarLoc} si loc ");
            if(OcupareLoc == true)
                Console.WriteLine("ocupat.");
            else
                Console.WriteLine("neocupat.");
            return OcupareLoc;
        }
        
    }
    internal class Vagon
    {
        private int capacitateVagon=300;
        internal int numarCalatori = 0;
        private int numarVagon;
        internal int numarRanduri = 0;
        internal int numarLocuriPeRand = 0;
        internal List<Loc> locuri= new List<Loc>();
        private int clasa;

        /*
         
          clasa = 0 vagon compartiment 
          clasa = 1 clasa 1
          clasa = 2 clasa 2
          clasa = 3 vagon restaurant
          
        */

        public Vagon(int capacitateVagon, int numarVagon, int clasa, int numarRanduri, int numarLocuriPeRand)
        {
            this.capacitateVagon = capacitateVagon;
            this.numarVagon = numarVagon;
            this.clasa = clasa;
            this.numarRanduri = numarRanduri;
            this.numarLocuriPeRand = numarLocuriPeRand;

            if (capacitateVagon != numarRanduri * numarLocuriPeRand)
            {
                throw new ArgumentException($" | ERROR | capacitateVagon {capacitateVagon} != numarRanduri {numarRanduri} * numarLocuriPeRand {numarLocuriPeRand} la vagon nr. {numarVagon}");
            }

            for (int i = 0; i < capacitateVagon; i++)
            {
                var GenerareLoc = new Loc(false, i);
                locuri.Add(GenerareLoc);
            }
        }
        public int getnumarVagon()
        {
            return numarVagon;
        }
        
        public int getclasa()
        {
            return clasa;
        }

        public int getcapacitateVagon()
        {
            return capacitateVagon;
        }
        public void AfisareVagon()
        {
            Console.WriteLine($"* Vagon cu capacitatea: {capacitateVagon}, numarulul vagonului: {numarVagon}, clasa: {clasa}, numarRanduri: {numarRanduri}, numarLocuriPeRand: {numarLocuriPeRand}");
        }
    }
}
