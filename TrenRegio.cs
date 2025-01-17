using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Poo
{
    //to add lista cu statiile de oprire dupa ce o termina alex(tren regio opreste in toate statiile)
    internal class TrenRegio : Tren
    {

        public TrenRegio(string id, int numar_tren,Ruta rutaTren) : base(id, numar_tren, rutaTren)
        {

        }

        public override float CalculeazaPret(Ruta ruta)
        {
            // pretul unui bilet e de 2 lei pe o unitate de distanta
            float dist = ruta.getDistantaTotala();
            return (80 / 100) * (dist * 2);
        }
        public override List<Statie> SetListaOpriri(List<Statie> opriri)
        {

            if (opriri.Count != rutaTren.getNrStatii())
                throw new Exception($"Trenul Regio cu id-ul {id} nu a fost configurat sa opreasca in toate statiile");
            if (opriri.Count > rutaTren.getNrStatii())
                throw new Exception($"Trenul Regio cu id-ul {id} are mai multe opriri decat exista statii");
            if (opriri.Count == 0 || opriri.Count == 1)
                throw new Exception($"Trenul Regio cu id-ul {id} nu are destule opriri (necesita minim 2)");

            listaOpriri.AddRange(opriri);
            return listaOpriri;
        }

    }
}
