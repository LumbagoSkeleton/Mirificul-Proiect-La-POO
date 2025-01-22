using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Poo
{
    internal class TrenInterRegio : Tren
    {
       private bool compartiment_privat;
        public TrenInterRegio(string id, int numar_tren,bool compartiment_privat,Ruta rutaTren) : base(id, numar_tren, rutaTren)
        {
            this.compartiment_privat = compartiment_privat;
        }
        public override float CalculeazaPret(Ruta ruta)
        {
            // pretul unui bilet e de 2 lei pe o unitate de distanta
            // compartimentul private costa 100 lei extra
            float dist = ruta.getDistantaTotala();
            return (dist * 2)+ Convert.ToInt32(compartiment_privat) *100;
        }
        public override List<Statie> SetListaOpriri(List<Statie> opriri)
        {
            if (opriri.Count > rutaTren.getNrStatii())
                throw new Exception($"Trenul InterRegio cu id-ul {id} are mai multe opriri decat exista statii");
            if (opriri.Count == 0 || opriri.Count == 1)
                throw new Exception($"Trenul InterRegio cu id-ul {id} nu are destule opriri (necesita minim 2)");

            listaOpriri.AddRange(opriri);
            return listaOpriri;
        }
    }
}
