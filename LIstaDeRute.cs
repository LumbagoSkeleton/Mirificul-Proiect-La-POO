using Proiect_Poo;

namespace Proiect_Poo
{
    internal class ListaDeRute
    {
        internal List<RutaIntreDouaStatii> Rute;

        public ListaDeRute()
        {
            Rute = new List<RutaIntreDouaStatii>();
        }

        public ListaDeRute(List<RutaIntreDouaStatii> rute)
        {
            Rute = rute;
        }

        public void AdaugareRuta(RutaIntreDouaStatii rutaIntreDouaStatii)
        {
            // adaugare ruta
            Rute.Add(rutaIntreDouaStatii);
        }

        public void StergereRuta(RutaIntreDouaStatii rutaIntreDouaStatii)
        {
            // sterge ruta
            Rute.Remove(rutaIntreDouaStatii);
        }

        public void AdaugareRute(List<RutaIntreDouaStatii> rute)
        {
            // adaugare rute
            Rute.AddRange(rute);
        }

        public void StergeRute(List<RutaIntreDouaStatii> rute)
        {
            // sterge rute
            Rute.Clear();
        }

        public int NumarDeRute()
        {
            return Rute.Count();
        }

        internal List<RutaIntreDouaStatii> GetRute()
        {
            return Rute;
        }

        public List<RutaIntreDouaStatii> CautareRuteDisponibile(Statie St1, Statie St2)
        {
            // Se cauta rute disponibile

            List<RutaIntreDouaStatii> lista = new List<RutaIntreDouaStatii>();
            Console.WriteLine(" * Afisare trenuri disponibile si detalii ruta:");

            foreach (RutaIntreDouaStatii ruta in Rute)
            {
                if ((ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                    ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St2.NumeStatie) == 0) ||
                    (ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                        ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St2.NumeStatie) == 0) && ruta.RutaActiva == true)
                {
                    // Daca ruta curenta este activa si este una intre 2 statii ( ruta simpla )
                    ruta.AfisareTrenuriDisponibile();
                    ruta.AfisareDetaliiRuta();
                    lista.Add(ruta);
                    return lista;
                }

                if ((ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St1.NumeStatie) != 0 &&
                     ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St2.NumeStatie) == 0) ||
                    (ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                     ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St2.NumeStatie) != 0) ||
                    (ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St1.NumeStatie) != 0 &&
                     ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St2.NumeStatie) == 0) ||
                    (ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                     ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St2.NumeStatie) != 0))
                {
                    // Daca ruta curenta este una intre mai mult de 2 statii ( ruta complexa )
                    lista = GasireRutaComplexa(St1, St2);
                    return lista;
                }
            }
            Console.WriteLine(" | INFO | Nu au fost gasite rute disponibile.");
            return lista; // lista vida
        }

        internal RutaIntreDouaStatii? DisponibilitateRutaFiz(Statie St1, Statie St2)
        {
            // Se cauta daca cele doua statii St1 si St2 sunt statiile intermediare ale une rute simple.

            foreach (RutaIntreDouaStatii ruta in Rute)
            {
                if ((ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                    ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St2.NumeStatie) == 0) ||
                    (ruta.StatiiIntermediare.Statie2.NumeStatie.CompareTo(St1.NumeStatie) == 0 &&
                     ruta.StatiiIntermediare.Statie1.NumeStatie.CompareTo(St2.NumeStatie) == 0))
                {
                    return ruta;
                }
            }
            return null;
        }

        List<RutaIntreDouaStatii> ListaComplexaDeRute = new List<RutaIntreDouaStatii>();
        List<RutaIntreDouaStatii> lr = new List<RutaIntreDouaStatii>();
        int Index = -1;
        internal bool AlgortmGasireRutaComplexa(Statie statiaDeStart, Statie statiaDeSosire)
        {
            // algoritm recursiv pentru gasire ruta complexa

            var ok1 = false;
            var ok2 = false;
            var stop = false;

            if (Index != -1) // daca am avut o ruta care a fost introdusa deja in lista pentru determinare ruta complexa
                lr.RemoveAt(Index);
            Index = -1; // daca nu am avut o ruta care a fost introdusa deja in lista pentru determinare ruta complexa

            for (int i = 0; i < lr.Count && (ok1 == false && ok2 == false && stop == false); i++)
            {
                // se ia fiecare ruta din lista de rute ramase pentru determinare ruta complexa

                if (lr[i].StatiiIntermediare.Statie1.NumeStatie.CompareTo(statiaDeStart.NumeStatie) == 0 && lr[i].StatiiIntermediare.Statie2.NumeStatie.CompareTo(statiaDeSosire.NumeStatie) != 0)
                {
                    // daca prima statie curenta este aceasi cu statia de start curenta dar a doua statie curenta nu este aceasi cu statia de sosire curenta
                    // inseamna ca suntem in parcurgerea rutelor si mergem prin ele

                    ok1 = true;
                    Index = i;
                    var statiaDeStartInit = statiaDeStart;
                    statiaDeStart = lr[i].StatiiIntermediare.Statie2;
                    var elem = lr[i];
                    ListaComplexaDeRute.Add(lr[i]);
                    stop = AlgortmGasireRutaComplexa(statiaDeStart, statiaDeSosire);
                    if (stop == false)
                    {
                        ListaComplexaDeRute.Remove(elem);
                        statiaDeStart = statiaDeStartInit;
                        ok1 = false;
                        i--;
                    }
                }
                else
                {
                    if (lr[i].StatiiIntermediare.Statie2.NumeStatie.CompareTo(statiaDeStart.NumeStatie) == 0 && lr[i].StatiiIntermediare.Statie1.NumeStatie.CompareTo(statiaDeSosire.NumeStatie) != 0)
                    {
                        // daca a doua statie curenta este aceasi cu statia de start curenta dar prima statie curenta nu este aceasi cu statia de sosire curenta
                        // inseamna ca suntem in parcurgerea rutelor si mergem prin ele

                        ok2 = true; Index = i;
                        var statiaDeStartInit = statiaDeStart;
                        statiaDeStart = lr[i].StatiiIntermediare.Statie1;
                        var elem = lr[i];
                        ListaComplexaDeRute.Add(lr[i]);
                        stop = AlgortmGasireRutaComplexa(statiaDeStart, statiaDeSosire);
                        if (stop == false)
                        {
                            ListaComplexaDeRute.Remove(elem);
                            statiaDeStart = statiaDeStartInit;
                            ok2 = false; i--;
                        }
                    }
                    else
                    {
                        if (lr[i].StatiiIntermediare.Statie1.NumeStatie.CompareTo(statiaDeStart.NumeStatie) == 0 &&
                            lr[i].StatiiIntermediare.Statie2.NumeStatie.CompareTo(statiaDeSosire.NumeStatie) == 0 && lr[i].RutaActiva == true)
                        {
                            // daca prima statie curenta este aceasi cu statia de start curenta iar a doua statie curenta este aceasi cu statia de sosire curenta
                            // inseamna ca suntem la finalul parcurgerii ( am ajuns la capat ) si at avem o lista de rute valida

                            stop = true;
                            Index = i;
                            ListaComplexaDeRute.Add(lr[i]);
                        }
                        else
                        {
                            if (lr[i].StatiiIntermediare.Statie2.NumeStatie.CompareTo(statiaDeStart.NumeStatie) == 0 && lr[i].StatiiIntermediare.Statie1.NumeStatie.CompareTo(statiaDeSosire.NumeStatie) == 0 && lr[i].RutaActiva == true)
                            {
                                // daca a doua statie curenta este aceasi cu statia de start curenta iar prima statie curenta este aceasi cu statia de sosire curenta
                                // inseamna ca suntem la finalul parcurgerii ( am ajuns la capat ) si at avem o lista de rute valida

                                stop = true; Index = i;
                                ListaComplexaDeRute.Add(lr[i]);
                            }
                        }
                    }
                }
            }
            return stop;
        }

        internal void AfisareListaStatiiIntermediare()
        {
            foreach (var ruta in Rute)
            {
                ruta.StatiiIntermediare.AfisareStatii();
                ruta.AfisareDetaliiRuta();
            }
        }

        internal List<float> AfisareListaStatiiIntermediare(List<RutaIntreDouaStatii> rute)
        {
            // Afisare lista statii intermediare ale unor rute date ca si paramentru si calcularea sumei totale si a duratei totale

            float sumaDurata = 0;
            float sumaCost = 0;

            foreach (var r in rute)
            {
                r.StatiiIntermediare.AfisareStatii();
                r.AfisareDetaliiRuta();
                sumaDurata += r.Durata;
            }
            Console.WriteLine($"Durata Totala: {sumaDurata} iar pretul total: {sumaCost}");

            return new List<float>() { sumaDurata, sumaCost };
        }

        internal List<float> AfisareListaStatiiIntermediare(List<StatiiIntermediare> lista)
        {
            // Afisare lista statii intermediare date ca si paramentru si calcularea sumei totale si a duratei totale

            float sumaDurata = 0;
            float sumaCost = 0;
            foreach (var st in lista)
            {
                st.AfisareStatii();
                var ruta = DisponibilitateRutaFiz(st.Statie1, st.Statie2);
                if (ruta != null)
                {
                    ruta.AfisareDetaliiRuta();
                    sumaDurata += ruta.Durata;
                }
                else
                {
                    Console.WriteLine(" Eroare de gasire ruta. ");
                }
            }
            Console.WriteLine($"Durata Totala: {sumaDurata} iar pretul total: {sumaCost}");
            return new List<float>() { sumaDurata, sumaCost };
        }
        internal List<RutaIntreDouaStatii> GasireRutaComplexa(Statie St1, Statie St2)
        {

            // algoritm gasire ruta complexa ( formata din mai mult de 2 statii intermediare ) pe harta

            var statiaDeStart = St1;
            var statiaDeSosire = St2;
            ListaComplexaDeRute = new List<RutaIntreDouaStatii>();

            lr.Clear();
            foreach (var ruta in Rute) // salvam rutele intr-o alta lista, asigurandu-ne ca modificările ulterioare ale copiei nu afecteaza lista originala.
            {
                lr.Add(ruta.DeepCopy());
            }

            //Console.WriteLine("----------------------");
            //foreach (var ruta in lr)
            //{
            //ruta.StatiiIntermediare.AfisareStatii();
            //ruta.AfisareDetaliiRuta();
            //}
            //Console.WriteLine("----------------------");

            Index = -1;
            var bl = AlgortmGasireRutaComplexa(statiaDeStart, statiaDeSosire); // se apeleaza algoritmul gasirii rutei complexe, returneaza: true - daca gaseste ruta; false - daca nu gaseste ruta 
            if (bl == true) // daca bl == true, atunci ruta complexa gasita
            {
                Console.WriteLine("Conexiune gasita! Afisare lista statii intermediare");
                AfisareListaStatiiIntermediare(ListaComplexaDeRute);
            }
            else // daca bl == false, atunci ruta complexa negasita
            {
                Console.WriteLine("Conexiune negasita!");
            }
            return ListaComplexaDeRute;
        }

        internal void RezervareRutaCalatori(Statie St1, Statie St2, List<Calator> Calator)
        {
            foreach (var calat in Calator) // rezervare pentru mai multi calatori pentru o ruta data prin statiile intermediare ale sale
            {
                RezervareRutaCalator(St1, St2, calat);
            }
        }

        internal void RezervareRutaCalator(Statie St1, Statie St2, Calator Calator)
        {
            var d = DisponibilitateRutaFiz(St1, St2); // prinma data verificam daca gaseste ruta directa ( simpla ) intre cele doua statii date ca si parametrii
            if (d != null && d.RutaActiva == true) // daca nu avem ruta sau nu este activa
            {
                Console.WriteLine($"* Creare rezervare pentru calator cu numele {Calator.nume}!");
                var ok = false;
                foreach (var tren in d.GetTrenuriDisponibile())
                {
                    if (ok == true || tren.numarCalatori == tren.capacitateTren) // daca am gasit loc pentru calator sau nu mai avem locuri disp. in tren
                        break;
                    foreach (var vag in tren.GetlistaVagoane())
                    {
                        if (ok == true) // daca am gasit loc pentru calator
                            break;
                        if ((vag.numarCalatori < vag.getcapacitateVagon()) && vag.getclasa() == Calator.clasa) // daca avem locuri disp. in vagon si clasa vagonului dorita
                        {
                            ok = true;
                            Calator.idTren = tren.GetTrenId();
                            tren.numarCalatori++;
                            vag.numarCalatori++;
                            Calator.numarVagon = vag.getnumarVagon();
                            d.AdaugareCalator(Calator);
                            Console.WriteLine(
                                $"* Rezervare creata pentru calatorul cu numele: {Calator.nume} pe ruta {St1.NumeStatie} - {St2.NumeStatie} in trenul cu numarul: {tren.GetNumar_tren()} si vagonul cu numarul {vag.getnumarVagon()} ( locuri ocupate {vag.numarCalatori} / {vag.getcapacitateVagon()} )!\n");
                        }
                    }
                }


                if (ok == false) // daca nu s-a putut rezerva calatorul
                {
                    Console.WriteLine(
                        $"* Rezervare necreata! ( nu mai sunt locuri disponibile pentru vagoane cu clasa specificata pe ruta {St1.NumeStatie} - {St2.NumeStatie} pentru calatorul cu numele {Calator.nume} ).");
                }
            }
            else
            {
                Console.WriteLine("Nu exista ruta sau nu este activa!");
            }
        }
        internal void RezervareRutaCalator(Statie St1, Statie St2, Calator Calator, int numarVagon, int numarLoc)
        {
            var d = DisponibilitateRutaFiz(St1, St2); // prinma data verificam daca gaseste ruta directa ( simpla ) intre cele doua statii date ca si parametrii
            if (d != null && d.RutaActiva == true) // daca nu avem ruta sau nu este activa
            {
                Console.WriteLine($"* Creare rezervare pentru calator cu numele {Calator.nume}!");
                var ok = false;
                foreach (var tren in d.GetTrenuriDisponibile())
                {
                    if (ok == true || tren.numarCalatori == tren.capacitateTren) // daca am gasit loc pentru calator sau nu mai avem locuri disp. in tren
                        break;
                    foreach (var vag in tren.GetlistaVagoane())
                    {
                        if (ok == true) // daca am gasit loc pentru calator
                            break;
                        if ((vag.numarCalatori < vag.getcapacitateVagon()) && (vag.getclasa() == Calator.clasa) && (vag.getnumarVagon() == numarVagon))  // daca avem locuri disp. in vagon si clasa vagonului dorita
                        {
                            foreach (var loc in vag.locuri)
                                if ((numarLoc == loc.numarLoc) && (loc.OcupareLoc == false))
                                {
                                    ok = true;
                                    loc.OcupareLoc = true;
                                    Calator.idTren = tren.GetTrenId();
                                    tren.numarCalatori++;
                                    vag.numarCalatori++;
                                    Calator.numarVagon = vag.getnumarVagon();
                                    d.AdaugareCalator(Calator, tren, numarVagon, numarLoc);
                                    Console.WriteLine(
                                        $"* Rezervare creata pentru calatorul cu numele: {Calator.nume} pe ruta {St1.NumeStatie} - {St2.NumeStatie} in trenul cu numarul: {tren.GetNumar_tren()} si vagonul cu numarul {vag.getnumarVagon()}, la locul {loc.numarLoc} ( locuri ocupate {vag.numarCalatori} / {vag.getcapacitateVagon()} )!\n");
                                }
                        }
                    }
                }


                if (ok == false) // daca nu s-a putut rezerva calatorul
                {
                    Console.WriteLine(
                        $"* Rezervare necreata! ( nu mai sunt locuri disponibile pentru vagoane cu clasa specificata pe ruta {St1.NumeStatie} - {St2.NumeStatie} pentru calatorul cu numele {Calator.nume} ).");
                }
            }
            else
            {
                Console.WriteLine("Nu exista ruta sau nu este activa!");
            }
        }
        internal Calator? GasireSiAnulareRezervarePtCalator(Calator? calator)
        {
            Calator? calatorGasit = null;
            if (calator != null) // cat timp calator nenul ca parametru de intrare
            {
                foreach (var r in Rute)
                {
                    calatorGasit = r.ListaCalatori.Find(x => x.id == calator.id); // cautam calatorul in baza de date dupa id-ul sau
                    if (calatorGasit != null)
                    {
                        Console.WriteLine(" | SUCCES | Calator gasit!");
                        r.AnulareRezervare(calator);
                        return calatorGasit;
                    }
                }
                Console.WriteLine(" | FAILED | Calator negasit!");
            }
            else
            {
                Console.WriteLine(" | ERROR | Calator = null!");
            }
            return calatorGasit;
        }
    }
}
