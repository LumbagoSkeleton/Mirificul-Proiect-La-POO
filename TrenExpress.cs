using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proiect_Poo
{
    internal class TrenExpress : Tren
    {
        private bool serviciuMasa;
        private int meseDorite;
        public TrenExpress(string id, int numar_tren, Ruta rutaTren) : base(id, numar_tren, rutaTren)
        {
        }
        public TrenExpress(string id, int numar_tren, bool serviciuMasa, int meseDorite, Ruta rutaTren) : base(id, numar_tren, rutaTren)
        {
            this.serviciuMasa=serviciuMasa;
            this.meseDorite=meseDorite;
        }
        public override float CalculeazaPret(Ruta ruta)
        {
            // pretul unui bilet e de 2 lei pe o unitate de distanta
            // o masa costa 75 de lei
            float dist = ruta.getDistantaTotala();
            return (dist * 2) + Convert.ToInt32(serviciuMasa) * meseDorite * 75;
        }
        public override List<Statie> SetListaOpriri(List<Statie> opriri)
        {
            if (opriri.Count > 4)
                throw new Exception($"Trenul Express cu id-ul {id} a fost configurat sa opreasca in mai mult de 4 statii");
            if (opriri.Count > rutaTren.getNrStatii())
                throw new Exception($"Trenul Express cu id-ul {id} are mai multe opriri decat exista statii");
            if (opriri.Count == 0 || opriri.Count == 1)
                throw new Exception($"Trenul Express cu id-ul {id} nu are destule opriri (necesita minim 2)");
            listaOpriri.AddRange(opriri);
            return listaOpriri;
        }
    }
}