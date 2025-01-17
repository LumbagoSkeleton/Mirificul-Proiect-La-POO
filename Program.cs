using System.Diagnostics;

namespace Proiect_Poo;

class Program
{
    public class MonedaWrapper // wrapper = "inveleste" pentru a oferi functionalitati suplimentare, cum ar fi validare, abstractizare.
    {
        private int tipMoneda;

        public int TipMoneda
        {
            get { return tipMoneda; }
            set
            {
                if (value >= 0 && value <= 2) // validare moneda
                    tipMoneda = value;
                else
                {
                    throw new ArgumentException(" | ERROR | Moneda invalida! ");
                }
            }
        }

        public MonedaWrapper(int initialValue)
        {
            tipMoneda = initialValue;
            if (tipMoneda < 0 || tipMoneda > 2)
            {
                throw new ArgumentException(" | ERROR | Moneda invalida! ");
            }
        }
    }
    
    static void Main(string[] args)
    {
        /*
         *
         * 
         * Cerințe generale
            1. Funcționalități pentru pasageri
            • Cautarea rutelor de tren disponibile intre doua statii, cu optiuni pentru trenuri directe
                sau conexiuni si vizualizarea detaliilor rutei: statii intermediare, orar, durata, cost.
            • Rezervarea calatoriilor pentru o ruta specifica si selectarea tipului de loc (ex. clasa 1,
                clasa 2, compartiment, vagon restaurant). Rezervarea poate fi facuta pe mai multe
                locuri.
            • Anularea rezervarilor in limita timpului disponibil (cu cel putin 24 de ore inainte de
                plecare).
            • Vizualizarea istoricului calatoriilor. 
         *
         * 
         */
        
        // lista de rute
        // Clasa ruta: statii intermediare, orar, durata, cost
        // Rezervari: rezervare pt o ruta si select tip loc ( ex. clasa 1, clasa 2, compartiment, vagon restaurant ) 
        // Se pot anula rezerv cu cel putin 24 de ore inainte de plecare
        //      Anularea trebuie să fie confirmată înainte să înceapă perioada de 24 de ore până la plecare.
        // Vizualizarea istoricului calatoriilor. 
        
        
        // Creare baza de date pentru testare algoritm pe consola
        
        // Adaugare statii
        
        Console.WriteLine("\n | MENIU BAZA DE DATE |  ");
        
        Statie statie1= new Statie("Statie1", "Huneodara , Str. I.L.Caragiale , nr 45");
        Statie statie2= new Statie("Statie2", "Deva ,  Str. I.Creanga , nr 23");
        Statie statie3= new Statie("Statie3", "Craiova, Str. Bacovia , nr 1");
        Statie statie4= new Statie("Statie4", "Bucuresti, Str. Alexandru , nr 20");

        List<Statie> statii = new List<Statie>() ;
        statii.Add(statie1); statii.Add(statie2); statii.Add(statie3); statii.Add(statie4);
        
        // Adaugare statii intermediare, orare, rute, trenuri, vagoane
        
        StatiiIntermediare statiiIntermediare_HD_Deva = new StatiiIntermediare(statie1, statie2);
        Orar orar_Ruta_HD_DV= new Orar(new DateTime(2025, 01, 20), new DateTime(2025, 01, 24));
        RutaIntreDouaStatii rutaIntreDouaStatiiHdDv = new RutaIntreDouaStatii("R001", statiiIntermediare_HD_Deva, orar_Ruta_HD_DV, 18, 10);
        
        var tren1 = new Tren("HD2342", 1);
        tren1.addVagons(new List<int>() {35, 40, 30}, new List<int>() {1, 2, 3}, new List<int>(){0, 1, 2}, new List<int>(){5, 5, 5}, new List<int>(){7, 8, 6});
        var tren2 = new Tren("HD2345", 2);
        tren2.addVagons(new List<int>() {35, 40, 50, 20}, new List<int>() {1, 2, 3, 4}, new List<int>(){0, 1, 2, 3}, new List<int>(){5, 5, 5, 4}, new List<int>(){7, 8, 10, 5});
        rutaIntreDouaStatiiHdDv.AdaugareTrenuriDisponibile(new List<Tren> { tren1, tren2 });
        
        StatiiIntermediare statiiIntermediare_Dv_Craiova = new StatiiIntermediare(statie2, statie3);
        Orar orar_Ruta_Dv_Craiova= new Orar(new DateTime(2025, 10, 12), new DateTime(2025, 10, 13));
        RutaIntreDouaStatii rutaIntreDouaStatiiDvCraiova = new RutaIntreDouaStatii("R023", statiiIntermediare_Dv_Craiova, orar_Ruta_Dv_Craiova, 43, 240);
        
        tren1 = new Tren("HDDV1342", 1);
        tren1.addVagons(new List<int>() {50, 40, 30}, new List<int>() {1, 2, 3}, new List<int>(){0, 1, 2}, new List<int>(){5, 5, 5}, new List<int>(){10, 8, 6});
        tren2 = new Tren("DV1345", 2);
        tren2.addVagons(new List<int>() {35, 40, 50, 30}, new List<int>() {1, 2, 3, 4}, new List<int>(){0, 1, 2, 3}, new List<int>(){5, 5, 5, 3 }, new List<int>(){7, 8, 10, 10 });
        var tren3 = new Tren("DV1343", 3);
        rutaIntreDouaStatiiDvCraiova.AdaugareTrenuriDisponibile(new List<Tren> { tren1, tren2, tren3 });
        
        
        StatiiIntermediare statiiIntermediare_Craiova_Bucuresti = new StatiiIntermediare(statie3, statie4);
        Orar orar_Ruta_Craiova_Bucuresti= new Orar(new DateTime(2025, 10, 27), new DateTime(2025, 10, 29));
        RutaIntreDouaStatii rutaIntreDouaStatiiCraiovaBucuresti = new RutaIntreDouaStatii("R024", statiiIntermediare_Craiova_Bucuresti, orar_Ruta_Craiova_Bucuresti, 60, 200);
        
        tren1 = new Tren("CR3342", 1);
        tren1.addVagons(new List<int>() {60, 40, 30}, new List<int>() {1, 2, 3}, new List<int>(){0, 1, 2}, new List<int>(){6, 4, 3} , new List<int>(){10, 10, 10});

        tren2 = new Tren("CR3345", 2);
        tren2.addVagons(new List<int>() {60, 40, 30}, new List<int>() {1, 2, 3}, new List<int>(){0, 1, 2}, new List<int>(){6, 4, 3} , new List<int>(){10, 10, 10});

        tren3 = new Tren("CR3321", 2);
        tren3.addVagons(new List<int>() {60, 40, 30}, new List<int>() {1, 2, 3}, new List<int>(){0, 1, 2}, new List<int>(){6, 4, 3} , new List<int>(){10, 10, 10});

        var tren4 = new Tren("CR4123", 2);
        tren1.addVagons(new List<int>() {60, 40, 30}, new List<int>() {1, 2, 3}, new List<int>(){0, 1, 2}, new List<int>(){6, 4, 3} , new List<int>(){10, 10, 10});

        rutaIntreDouaStatiiCraiovaBucuresti.AdaugareTrenuriDisponibile(new List<Tren> { tren1, tren2, tren3, tren4 });

        ListaDeRuteMici listaRuteMici = new ListaDeRuteMici();

        listaRuteMici.AdaugareRutaMica(rutaIntreDouaStatiiDvCraiova);
        listaRuteMici.AdaugareRuteMici(new List<RutaIntreDouaStatii> { rutaIntreDouaStatiiHdDv,rutaIntreDouaStatiiCraiovaBucuresti });

        // Declarare variabile pentru citire date personale si variablie pentru statii
        
        string nume, prenume;
        int varsta, clasa;
        string sst1, sst2;
        Statie st1, st2;
        
        // Declarare calatori
        
        var Calator_nou1= new Calator("Voinea", "Stefan", 21, 2 , DateTime.Now);
        Calator_nou1.IstoricOrarCalator = rutaIntreDouaStatiiHdDv.Orar;
        var Calator_nou2= new Calator("Mihalache", "Adriana", 24, 1 , DateTime.Now);
        Calator_nou2.IstoricOrarCalator = rutaIntreDouaStatiiHdDv.Orar;
        var Calator_nou3= new Calator("Chiriac", "Nicolae", 50, 2 , DateTime.Now);
        Calator_nou3.IstoricOrarCalator = rutaIntreDouaStatiiHdDv.Orar;
        var Calator_nou4= new Calator("Marcu", "Emanuel", 18, 2 , DateTime.Now);
        Calator_nou4.IstoricOrarCalator = rutaIntreDouaStatiiCraiovaBucuresti.Orar;
        var Calator_nou5= new Calator("Costea", "Larisa", 19, 2 , DateTime.Now);
        Calator_nou5.IstoricOrarCalator = rutaIntreDouaStatiiDvCraiova.Orar;
        var Calator_nou6= new Calator("Popescu", "Alexandru", 29, 2 , DateTime.Now);
        Calator_nou6.IstoricOrarCalator = rutaIntreDouaStatiiDvCraiova.Orar;
        var Calator_nou7= new Calator("Ionescu", "Alexandru", 34, 1 , DateTime.Now);
        Calator_nou7.IstoricOrarCalator = rutaIntreDouaStatiiCraiovaBucuresti.Orar;
        
        // Rezervare calatorilor pe rute
        
        listaRuteMici.RezervareRutaCalator(statie1, statie2, Calator_nou1);
        listaRuteMici.RezervareRutaCalator(statie1, statie2, Calator_nou2);
        listaRuteMici.RezervareRutaCalator(statie1, statie2, Calator_nou3);
        listaRuteMici.RezervareRutaCalator(statie3, statie4, Calator_nou4);
        listaRuteMici.RezervareRutaCalator(statie3, statie4, Calator_nou5);
        listaRuteMici.RezervareRutaCalator(statie2, statie3, Calator_nou6);
        listaRuteMici.RezervareRutaCalator(statie2, statie3, Calator_nou7);

        RuteMari ruteMari = new RuteMari();
        
        Ruta ruta1= new Ruta(new List<RutaIntreDouaStatii>(){rutaIntreDouaStatiiHdDv, rutaIntreDouaStatiiDvCraiova}, tren1);
        Ruta ruta2= new Ruta(new List<RutaIntreDouaStatii>(){rutaIntreDouaStatiiDvCraiova, rutaIntreDouaStatiiCraiovaBucuresti}, tren1);

        //Orar Durata = new Orar(ruta1.getRuteMici()[0].Orar.DataPlecare, ruta1.getRuteMici()[ruta1.getRuteMici().Count - 1].Orar.DataSosire);
        //ruta1.durata = Durata;
        
        
        //ruta2.durata.DataPlecare = ruta2.getRuteMici()[0].Orar.DataPlecare;
        //ruta2.durata.DataSosire = ruta2.getRuteMici()[ruta2.getRuteMici().Count - 1].Orar.DataSosire;
        
        ruteMari.AdaugaRuteMari(new List<Ruta>(){ruta1, ruta2});
        
        Console.WriteLine("");
        
        while (true) // meniu consola pentru debugging
        {
            Console.WriteLine("  | MENIU DEBUGGING | \n" +
                              "1) Creati o rezervare automata ( o persoana sau mai multe )\n" +
                              "2) Renuntati la o rezervare!\n" +
                              "3) Cautare rute tren disponibile intre doua statii... \n" +
                              "4) Vizualizare istoric calatori\n" +
                              "5) Rezervare pe un loc dorit ( o persoana sau mai multe )");
            

            // tipMoneda == 0 euro
            // tipMoneda == 1 lei
            // tipMoneda == 2 dolari

            MonedaWrapper monedaWrapper = new MonedaWrapper(1);
            
            Console.WriteLine();
            Console.Write(" | INPUT | Introduceti moneda (0 euro, 1 lei, 2 dolari): ");
            
            bool intrareValida = false;
            int opt= 0;
            while (!intrareValida)
            {
                if (int.TryParse(Console.ReadLine(), out int value5))
                {
                    intrareValida = true;
                    opt = value5;
                    if (value5 < 0 || value5 > 2)
                    {
                        intrareValida = false;
                        Console.Write(" | ERROR | Optiune invalida! Reintroduceti moneda (0 euro, 1 lei, 2 dolari): ");
                    }
                }
                else
                {
                    Console.Write(" | ERROR | Optiune invalida! Reintroduceti moneda (0 euro, 1 lei, 2 dolari): ");
                }
            }

            if (opt == 0)
            {
                monedaWrapper.TipMoneda = 0;
            }
            else
            {
                if (opt == 1)
                {
                    monedaWrapper.TipMoneda = 1;
                }
                else
                {
                    if (opt == 2)
                    {
                        monedaWrapper.TipMoneda = 2;
                    }
                }
            }
            
            Console.WriteLine();
            Console.Write(" | INPUT | Introduceti optiunea dvs.: ");
            if(!int.TryParse(Console.ReadLine(), out int menuValue))
            {
                Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti optiunea dvs.");
                Console.WriteLine();
                continue;
            }
            
            switch (menuValue)
            {
                case 1:
                    
                    Console.Write(" | INPUT | Doriti sa faceti rezervarea pentru un calator sau pentru mai multi? ( 0 - pentru unu / 1 - pentru mai multi): ");
                    
                    intrareValida = false;
                    opt= 0;
                    while (!intrareValida)
                    {
                        if (int.TryParse(Console.ReadLine(), out int value5))
                        {
                            intrareValida = true;
                            opt = value5;
                        }
                        else
                        {
                            Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti optiunea dvs ( 0 - pentru unu / 1 - pentru mai multi): ");
                        }
                    }
                    
                    if (opt == 0)
                    {
                        
                        Console.WriteLine(" | INPUT | Va rugam frumos sa va introduceti datele dvs.:");
                        Console.WriteLine("");
                        Console.Write(" | INPUT | Nume: ");
                        nume = Console.ReadLine();
                        Console.Write(" | INPUT | Prenume: ");
                        prenume = Console.ReadLine();
                        Console.Write(" | INPUT | Varsta: ");
                        varsta = 18;
                        
                        intrareValida = false;
                        while (!intrareValida)
                        {
                             if (int.TryParse(Console.ReadLine(), out int value4))
                            {
                                intrareValida = true;
                                varsta = value4;
                            }
                            else
                            {
                                Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti varsta dvs: ");
                            }
                        }
                        Console.Write(" | INPUT | Clasa vagonului: ");
                        clasa = 0; 
                        intrareValida = false;
                        while (!intrareValida)
                        {
                            if (int.TryParse(Console.ReadLine(), out int value2))
                            {
                                intrareValida = true;
                                clasa = value2;
                            }
                            else
                            {
                                Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti clasa vagonului dvs.");
                            }
                            Console.WriteLine();
                        }
                        
                        Console.WriteLine("");
                        listaRuteMici.AfisareListaStatiiIntermediare();
                        Console.WriteLine("");
                        
                        Console.WriteLine("");
                        ruteMari.AfisareRuteMari(monedaWrapper.TipMoneda);
                        Console.WriteLine("");
                        
                        Console.WriteLine(" | INPUT | Alegeti ruta dorita pe care doriti sa faceti rezervarea prin introducerea statiilor: ");

                        Console.Write(" | INPUT | Statia 1: ");
                        sst1= Console.ReadLine();
                        Console.Write(" | INPUT | Statia 2: ");
                        sst2= Console.ReadLine();

                        st1= statii.Find(s => s.NumeStatie == sst1);
                        st2= statii.Find(s => s.NumeStatie == sst2);
                        Console.WriteLine("");
                        
                        if (st1 != null && st2 != null)
                        {
                            var Calator_nou= new Calator(nume, prenume, varsta, clasa , DateTime.Now);
                            listaRuteMici.RezervareRutaCalator(st1, st2, Calator_nou);
                        }
                        else
                        {
                            Console.WriteLine("Reintroduceti optiunea 1 pt. a reintroduce statiile corect. O statie invalida sau amandoua!");
                        }
                    }
                    else
                    {
                        if (opt == 1)
                        {
                            Console.Write(" | INPUT | Va rugam frumos sa spuneti cati calatori pe langa dvs. sunt: ");

                            int nrCalarori = 0;
                            
                            intrareValida = false;
                            while (!intrareValida)
                            {
                                if (int.TryParse(Console.ReadLine(), out int value6))
                                {
                                    if(value6 <= 0)
                                    {
                                        Console.WriteLine(" | ERROR |  Reintroduceti nr de calatori ( nrCalarori > 0 ! ): ");
                                        intrareValida = false;
                                        while (!intrareValida)
                                        {
                                            if (int.TryParse(Console.ReadLine(), out int value7))
                                            {
                                                intrareValida = true;
                                                nrCalarori = value7;
                                            }
                                            else
                                            {
                                                Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti varsta dvs: ");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        intrareValida = true;
                                        nrCalarori = value6;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti nr de calatori ( nrCalarori > 0 ! ): ");
                                }
                                Console.WriteLine("");
                            }

                            for (int i = 0; i < nrCalarori; i++)
                            {
                                Console.WriteLine($" | CALATOR {i+1} | ");
                                Console.WriteLine("");
                                Console.Write(" | INPUT | Nume: ");
                                nume = Console.ReadLine();
                                Console.Write(" | INPUT | Prenume: ");
                                prenume = Console.ReadLine();
                                Console.Write(" | INPUT | Varsta: ");
                                varsta = 18;
                                
                                intrareValida = false;
                                while (!intrareValida)
                                {
                                     if (int.TryParse(Console.ReadLine(), out int value4))
                                    {
                                        intrareValida = true;
                                        varsta = value4;
                                    }
                                    else
                                    {
                                        Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti varsta dvs: ");
                                    }
                                }
                                Console.Write(" | INPUT | Clasa vagonului: ");
                                clasa = 0; 
                                intrareValida = false;
                                while (!intrareValida)
                                {
                                    if (int.TryParse(Console.ReadLine(), out int value2))
                                    {
                                        intrareValida = true;
                                        clasa = value2;
                                    }
                                    else
                                    {
                                        Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti clasa vagonului dvs.");
                                    }
                                    Console.WriteLine();
                                }
                                
                                Console.WriteLine("");
                                listaRuteMici.AfisareListaStatiiIntermediare();
                                Console.WriteLine("");
                                Console.WriteLine(" | INPUT | Alegeti ruta dorita pe care doriti sa faceti rezervarea prin introducerea statiilor: ");

                                Console.Write(" | INPUT | Statia 1: ");
                                sst1= Console.ReadLine();
                                Console.Write(" | INPUT | Statia 2: ");
                                sst2= Console.ReadLine();

                                st1= statii.Find(s => s.NumeStatie == sst1);
                                st2= statii.Find(s => s.NumeStatie == sst2);
                                Console.WriteLine("");
                                
                                if (st1 != null && st2 != null)
                                {
                                    var Calator_nou= new Calator(nume, prenume, varsta, clasa , DateTime.Now);
                                    listaRuteMici.RezervareRutaCalator(st1, st2, Calator_nou);
                                }
                                else
                                {
                                    Console.WriteLine("Reintroduceti optiunea 1 pt. a reintroduce statiile corect. O statie invalida sau amandoua!");
                                }
                            }
                        }
                    }
                    
                    
                    
                    break;
                
                case 2:
                    
                    Console.WriteLine(" | INPUT | Va rugam frumos sa va introduceti datele dvs. pt. anulare rezervare:");
                    Console.WriteLine("");

                    Console.Write(" | INPUT | Nume: ");
                    nume = Console.ReadLine();
                    Console.Write(" | INPUT | Prenume: ");
                    prenume = Console.ReadLine();

                    Calator? cal= null;
                    foreach (var r in listaRuteMici.GetRuteMici())
                    { 
                        cal = r.ListaCalatori.Find(c => c.nume == nume && c.prenume == prenume);
                        if (cal != null) break;
                    }

                    if (cal != null)
                    {
                        cal.AfisareCalator();
                        
                        var opt2 = 0;
                        intrareValida = false;
                        while (!intrareValida)
                        {
                            Console.WriteLine(" | INPUT | Sunteti sigur ca doriti stergerea rezervarii? ( Yes - 1 / N - 0 ): ");
                            if (int.TryParse(Console.ReadLine(), out int value3))
                            {
                                intrareValida = true;
                                opt2 = value3;
                            }
                            else
                            {
                                Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti optiunea dvs.");
                            }
                            Console.WriteLine();
                        }
                        
                        if (opt2 == 1)
                            listaRuteMici.GasireSiAnulareRezervarePtCalator(cal);
                        else
                        {
                            Console.WriteLine(" | FAILED | S-a renuntat la actiunea de stergere rezervare! ");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine(" | FAILED | Nu s-a gasit calatorul respectiv! ");
                        Console.WriteLine();
                    }
                    break;
                
                case 3:
                    listaRuteMici.AfisareListaStatiiIntermediare();
                    Console.WriteLine(" | OUTPUT | Afisare rute mari: ");
                        
                    ruteMari.AfisareRuteMari(monedaWrapper.TipMoneda);
                    
                    Console.WriteLine("\n | INPUT | Introduceti cele doua statii pentru gasirea rutei dorite: ");

                    Console.Write(" | INPUT | Statia 1: ");
                    sst1= Console.ReadLine();
                    Console.Write(" | INPUT | Statia 2: ");
                    sst2= Console.ReadLine();

                    st1= statii.Find(s => s.NumeStatie == sst1);
                    st2= statii.Find(s => s.NumeStatie == sst2);

                    if (st1 != null && st2 != null)
                    {
                        Console.WriteLine();
                        var ListaGasitaRuteMici = listaRuteMici.CautareRuteMiciDisponibile(st1, st2, monedaWrapper.TipMoneda);

                        if (ListaGasitaRuteMici.Count >= 1)
                        {
                            // daca a gasic conexiuni de rute mici

                            //Console.WriteLine("Conexiune gasita! Afisare lista statii intermediare!");
                            listaRuteMici.AfisareListaStatiiIntermediare(ListaGasitaRuteMici);
                        }
                        
                        // Cautare ruta mare 

                        var rez = ruteMari.CautareRutaMare(st1, st2);

                        if (rez != null)
                        {
                            rez.AfisareRutaMare(monedaWrapper.TipMoneda);
                        }
                        else
                        {
                            Console.WriteLine(" | FAILED | Nu s-a gasit ruta mare respectiva! Cel mai prob. exista conexiuni");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine(" | INFO | Reintroduceti optiunea 1 pt. a reintroduce statiile corect. O statie invalida sau amandoua!\n");
                    }
                    break;
                
                case 4:
                    
                    opt = 0;
                    intrareValida = false;
                    while (!intrareValida)
                    {
                        Console.Write(" | INPUT | Doriti vizualizarea calatoriilor pentru o ruta sau pentru toate? ( o ruta - 0, toate - 1 ) : ");
                        if (int.TryParse(Console.ReadLine(), out int value3))
                        {
                            intrareValida = true;
                            opt = value3;
                        }
                        else
                        {
                            Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti optiunea dvs.");
                        }
                        Console.WriteLine();
                    }
                    if (opt == 0)
                    {
                        foreach (var ruta in listaRuteMici.GetRuteMici())
                        {
                            ruta.StatiiIntermediare.AfisareStatii();
                        }
                        Console.WriteLine("\n| IN | Introduceti cele doua statii ale rutei dorite: ");
                    
                        Console.Write(" | INPUT | Statia 1: ");
                        sst1= Console.ReadLine();
                        Console.Write(" | INPUT | Statia 2: ");
                        sst2= Console.ReadLine();

                        st1= statii.Find(s => s.NumeStatie == sst1);
                        st2= statii.Find(s => s.NumeStatie == sst2);

                        if (st1 != null || st2 != null)
                        {
                            var ruta= listaRuteMici.DisponibilitateRutaFiz(st1, st2);
                            if (ruta != null)
                            {
                                Console.WriteLine(" | OUTPUT | Ruta gasita! Afisare Istoric Calatori pentru ruta aleasa:");
                                ruta.AfisareIstoricCalatori();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Reintroduceti optiunea 1 pt. a reintroduce statiile corect. O statie invalida sau amandoua!");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        if (opt == 1)
                        {
                            foreach (var ruta in listaRuteMici.GetRuteMici())
                            {
                                ruta.AfisareIstoricCalatori();
                            }
                        }
                        Console.WriteLine();
                    }

                    break;
                
                 case 5:

                        Console.Write(" | INPUT | Doriti sa faceti rezervarea pentru un calator sau pentru mai multi? ( 0 - pentru unu / 1 - pentru mai multi): ");

                        bool intrareValida1 = false;
                        int opt1 = 0;
                        while (!intrareValida1)
                        {
                            if (int.TryParse(Console.ReadLine(), out int value5))
                            {
                                intrareValida1 = true;
                                opt1 = value5;
                            }
                            else
                            {
                                Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti optiunea dvs ( 0 - pentru unu / 1 - pentru mai multi): ");
                            }
                        }

                        if (opt1 == 0)
                        {

                            Console.WriteLine(" | INPUT | Va rugam frumos sa va introduceti datele dvs.:");
                            Console.WriteLine("");
                            Console.Write(" | INPUT | Nume: ");
                            nume = Console.ReadLine();
                            Console.Write(" | INPUT | Prenume: ");
                            prenume = Console.ReadLine();
                            Console.Write(" | INPUT | Varsta: ");
                            varsta = 18;

                            intrareValida = false;
                            while (!intrareValida)
                            {
                                if (int.TryParse(Console.ReadLine(), out int value4))
                                {
                                    intrareValida = true;
                                    varsta = value4;
                                }
                                else
                                {
                                    Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti varsta dvs: ");
                                }
                            }
                            Console.Write(" | INPUT | Clasa vagonului: ");
                            clasa = 0;
                            intrareValida = false;
                            while (!intrareValida)
                            {
                                if (int.TryParse(Console.ReadLine(), out int value2))
                                {
                                    intrareValida = true;
                                    clasa = value2;
                                }
                                else
                                {
                                    Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti clasa vagonului dvs.");
                                }
                            }

                            Console.Write(" | INPUT | Vagonul Dorit ");
                            int numarVagon = 0;
                            intrareValida = false;
                            while (!intrareValida)
                            {
                                if (int.TryParse(Console.ReadLine(), out int value4))
                                {
                                    intrareValida = true;
                                    numarVagon = value4;
                                }
                                else
                                {
                                    Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti Vagonul : ");
                                }
                            }

                            Console.Write(" | INPUT | Locul Dorit ");
                            int numarLoc = 0;
                            intrareValida = false;
                            while (!intrareValida)
                            {
                                if (int.TryParse(Console.ReadLine(), out int value4))
                                {
                                    intrareValida = true;
                                    numarLoc = value4;
                                }
                                else
                                {
                                    Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti Locul : ");
                                }
                            }



                            Console.WriteLine("");
                            listaRuteMici.AfisareListaStatiiIntermediare();
                            Console.WriteLine("");
                            Console.WriteLine(" | INPUT | Alegeti ruta dorita pe care doriti sa faceti rezervarea prin introducerea statiilor: ");

                            Console.Write(" | INPUT | Statia 1: ");
                            sst1 = Console.ReadLine();
                            Console.Write(" | INPUT | Statia 2: ");
                            sst2 = Console.ReadLine();


                         

                            st1 = statii.Find(s => s.NumeStatie == sst1);
                            st2 = statii.Find(s => s.NumeStatie == sst2);
                            Console.WriteLine("");

                            if (st1 != null && st2 != null)
                            {
                                var Calator_nou = new Calator(nume, prenume, varsta, clasa, DateTime.Now);
                                listaRuteMici.RezervareRutaCalator(st1, st2, Calator_nou,numarVagon,numarLoc);
                            }
                            else
                            {
                                Console.WriteLine("Reintroduceti optiunea 1 pt. a reintroduce statiile corect. O statie invalida sau amandoua!");
                            }
                            
                        }
                        else
                        {
                            if (opt1 == 1)
                            {
                                Console.Write(" | INPUT | Va rugam frumos sa spuneti cati calatori pe langa dvs. sunt: ");

                                int nrCalarori = 0;

                                intrareValida = false;
                                while (!intrareValida)
                                {
                                    if (int.TryParse(Console.ReadLine(), out int value6))
                                    {
                                        if (value6 <= 0)
                                        {
                                            Console.WriteLine(" | ERROR |  Reintroduceti nr de calatori ( nrCalarori > 0 ! ): ");
                                            intrareValida = false;
                                            while (!intrareValida)
                                            {
                                                if (int.TryParse(Console.ReadLine(), out int value7))
                                                {
                                                    intrareValida = true;
                                                    nrCalarori = value7;
                                                }
                                                else
                                                {
                                                    Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti varsta dvs: ");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            intrareValida = true;
                                            nrCalarori = value6;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti nr de calatori ( nrCalarori > 0 ! ): ");
                                    }
                                    Console.WriteLine("");
                                }

                                for (int i = 0; i < nrCalarori; i++)
                                {
                                    Console.WriteLine($" | CALATOR {i + 1} | ");
                                    Console.WriteLine("");
                                    Console.Write(" | INPUT | Nume: ");
                                    nume = Console.ReadLine();
                                    Console.Write(" | INPUT | Prenume: ");
                                    prenume = Console.ReadLine();
                                    Console.Write(" | INPUT | Varsta: ");
                                    varsta = 18;

                                    intrareValida = false;
                                    while (!intrareValida)
                                    {
                                        if (int.TryParse(Console.ReadLine(), out int value4))
                                        {
                                            intrareValida = true;
                                            varsta = value4;
                                        }
                                        else
                                        {
                                            Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti varsta dvs: ");
                                        }
                                    }
                                    Console.Write(" | INPUT | Clasa vagonului: ");
                                    clasa = 0;
                                    intrareValida = false;
                                    while (!intrareValida)
                                    {
                                        if (int.TryParse(Console.ReadLine(), out int value2))
                                        {
                                            intrareValida = true;
                                            clasa = value2;
                                        }
                                        else
                                        {
                                            Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti clasa vagonului dvs.");
                                        }
                                    }
                                    Console.Write(" | INPUT | Vagonul Dorit ");
                                    int numarVagon = 0;
                                    intrareValida = false;
                                    while (!intrareValida)
                                    {
                                        if (int.TryParse(Console.ReadLine(), out int value4))
                                        {
                                            intrareValida = true;
                                            numarVagon = value4;
                                        }
                                        else
                                        {
                                            Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti Vagonul : ");
                                        }
                                    }
                                    Console.Write(" | INPUT | Locul Dorit ");
                                    int numarLoc = 0;
                                    intrareValida = false;
                                    while (!intrareValida)
                                    {
                                        if (int.TryParse(Console.ReadLine(), out int value4))
                                        {
                                            intrareValida = true;
                                            numarLoc = value4;
                                        }
                                        else
                                        {
                                            Console.WriteLine(" | ERROR | Optiune invalida! Reintroduceti Locul : ");
                                        }
                                    }
                                    Console.WriteLine("");
                                    listaRuteMici.AfisareListaStatiiIntermediare();
                                    Console.WriteLine("");
                                    Console.WriteLine(" | INPUT | Alegeti ruta dorita pe care doriti sa faceti rezervarea prin introducerea statiilor: ");

                                    Console.Write(" | INPUT | Statia 1: ");
                                    sst1 = Console.ReadLine();
                                    Console.Write(" | INPUT | Statia 2: ");
                                    sst2 = Console.ReadLine();

                                    st1 = statii.Find(s => s.NumeStatie == sst1);
                                    st2 = statii.Find(s => s.NumeStatie == sst2);
                                    Console.WriteLine("");

                                    if (st1 != null && st2 != null)
                                    {
                                        var Calator_nou = new Calator(nume, prenume, varsta, clasa, DateTime.Now);
                                        listaRuteMici.RezervareRutaCalator(st1, st2, Calator_nou,numarVagon,numarLoc);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Reintroduceti optiunea 1 pt. a reintroduce statiile corect. O statie invalida sau amandoua!");
                                    }
                                }
                            }
                        }
                        break;
                default:
                        Console.WriteLine("Optiune invalida!");
                        break;
            }
        }
    }
}