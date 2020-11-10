using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hamnen_Dilan
{
    class Program
    {
        static void Main(string[] args)
        {
            int dag = 1;
            double TotalaPlatser = 64;
            double BokadeHamnPlatser = 0;


            //SKapar hamn och båtplatser

            Hamn hamn = new Hamn();
            hamn.Båtplatser = new List<Slot>();

            //Lista för båtskapande, båtar som ska inkomma, båtar som inte har någon plats och för bokade platser
            List<Båt> båtarSkapade = new List<Båt>();
            List<Båt> båtarPåväg = new List<Båt>();
            List<Båt> BåtarUtanHamnPlats = new List<Båt>();
            List<Hamn> bokade = new List<Hamn>();

            //Random båtar som inkommer varje dag
            Random rnd = new Random();
            int båtarSomKommerVarjeDag = 5;




            while (true)
            {
                string fileName = @"C:\Users\Dilan\source\repos\Hamnen-Dilan\Hamnen-Dilan\bin\Debug\netcoreapp3.1\hamnen.txt"; 
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    Console.WriteLine($"Dagens dag {dag}\n");
                    sw.WriteLine($"Dagens dag {dag}\n");

                    for (int i = 0; i < båtarSomKommerVarjeDag; i++)
                    {
                        int randomNum = rnd.Next(1, 5);
                        if (randomNum == 1)
                        {
                            Roddbåt roddbåtar = new Roddbåt();
                            båtarSkapade.Add(roddbåtar);
                        }
                        else if (randomNum == 2)
                        {
                            Motorbåt motorbåtar = new Motorbåt();
                            båtarSkapade.Add(motorbåtar);
                        }
                        else if (randomNum == 3)
                        {
                            Segelbåt segelbåtar = new Segelbåt();
                            båtarSkapade.Add(segelbåtar);
                        }
                        else if (randomNum == 4)
                        {
                            Lastfartyg lastfartyg = new Lastfartyg();
                            båtarSkapade.Add(lastfartyg);
                        }
                    }

                    foreach (var item in båtarSkapade)
                    {
                        //   Console.WriteLine($"Boat {item.IdentityNumber} of type {item.BoatType} has arrived");



                        if ((BokadeHamnPlatser + item.PlatserSomTas) <= TotalaPlatser)
                        {
                            BokadeHamnPlatser += item.PlatserSomTas;

                            string slotID = Guid.NewGuid().ToString();

                            item.NuvarandePlatsID = slotID;

                            båtarPåväg.Add(item);

                            hamn.Båtplatser.Add(new Slot { ID = slotID, PlatsStorlek = item.PlatserSomTas, Bokad = true });
                        }

                        else
                        {
                            BåtarUtanHamnPlats.Add(item);
                        }
                    }


                    // Visa vilka båtar som har skapats
                    Console.WriteLine("Båtar som anländer idag:\n");
                    sw.WriteLine("Båtar som anländer idag:\n");
                    foreach (var item in båtarSkapade)
                    {

                        Console.WriteLine($"{item.BåtTyp} med nummer Id: {item.IdNummer}");
                        sw.WriteLine($"{item.BåtTyp} med nummer Id: {item.IdNummer}");

                    }
                    Console.WriteLine();




                    foreach (var item in hamn.Båtplatser)
                    {
                        foreach (var i in båtarPåväg)
                        {
                            if (i.PlatserSomTas == i.PlatserSomTas) ;
                        }
                    }

                    double platsnummer = 1;
                    int antalRoddbåtar = 0;
                    int antalMotorbåtar = 0;
                    int antalSegelbåtar = 0;
                    int antalLastfartyg = 0;
                    double maxhastighet = 0;
                    int TotalHastighet = 0;
                    int vikt = 0;

                    Console.WriteLine("Plats\tBåttyp\t\tNummer\tVikt\tMaxhastighet\t\tUnik\n");
                    sw.WriteLine("Plats\tBåttyp\t\tNummer\tVikt\tMaxhastighet\t\tUnik\n");


                    foreach (Båt item in båtarPåväg.ToList())
                    {


                        {

                        }
                        if (item != null)
                        {
                            if (item.PlatserSomTas > 1)
                            {

                                Console.WriteLine($"{platsnummer}-{platsnummer + item.PlatserSomTas - 1}.\t{item.BåtTyp}\t{item.IdNummer}\t{item.Vikt}\t{item.MaxSpeed} km/h\t\t{item.UnikEgenskap} ");
                                sw.WriteLine($"{platsnummer}-{platsnummer + item.PlatserSomTas - 1}.\t{item.BåtTyp}\t{item.IdNummer}\t{item.Vikt}\t{item.MaxSpeed} km/h\t\t{item.UnikEgenskap} ");
                                platsnummer++;
                            }
                            else
                            {
                                Console.WriteLine($"{platsnummer}.\t{item.BåtTyp}\t{item.IdNummer}\t{item.Vikt}\t{item.MaxSpeed} km/h\t\t{item.UnikEgenskap} ");
                                sw.WriteLine($"{platsnummer}.\t{item.BåtTyp}\t{item.IdNummer}\t{item.Vikt}\t{item.MaxSpeed} km/h\t\t{item.UnikEgenskap} ");
                            }

                            if (item is Roddbåt)
                            {

                                antalRoddbåtar++;
                                platsnummer += item.PlatserSomTas;



                            }
                            else if (item is Motorbåt)
                            {

                                antalMotorbåtar++;
                                platsnummer += item.PlatserSomTas;


                            }
                            else if (item is Segelbåt)
                            {

                                antalSegelbåtar++;
                                platsnummer += item.PlatserSomTas - 1;


                            }
                            else if (item is Lastfartyg)
                            {

                                antalLastfartyg++;
                                platsnummer += item.PlatserSomTas - 1;


                            }


                        }


                        else
                        {
                            Console.WriteLine(platsnummer + ". Tom Plats");
                            sw.WriteLine(platsnummer + ". Tom Plats");
                            platsnummer++;

                        }

                    }

                    if (platsnummer < 65)
                    {
                        double tommaPlatser = 65 - platsnummer;

                        for (int i = 0; i < tommaPlatser; i++)
                        {
                            Console.WriteLine(platsnummer + ". Tom Plats");
                            sw.WriteLine(platsnummer + ". Tom Plats");
                            platsnummer++;
                        }

                    }

                    foreach (var item in båtarPåväg.ToList())
                    {
                        if (item != null)
                        {
                            if (item.AntalDygnIHamnen != 0)
                            {
                                vikt += item.Vikt;
                                maxhastighet += item.MaxSpeed;
                                item.AntalDygnIHamnen--;
                                TotalHastighet++;

                            }

                            else
                            {
                                Console.WriteLine($"Båten som lämnar hamnen: {item.IdNummer}");
                                sw.WriteLine($"Båten som lämnar hamnen: {item.IdNummer}");

                                //   ledigaPlatser += item.Tarplatser;
                                vikt -= item.Vikt;
                                maxhastighet -= item.MaxSpeed;
                                TotalHastighet--;
                                if (item is Roddbåt)
                                    antalRoddbåtar--;
                                else if (item is Motorbåt)
                                    antalMotorbåtar--;
                                else if (item is Segelbåt)
                                    antalSegelbåtar--;
                                else if (item is Lastfartyg)
                                    antalLastfartyg--;
                                BokadeHamnPlatser -= item.PlatserSomTas;
                                båtarPåväg.Remove(item);








                            }
                        }
                    }







                    Console.WriteLine();
                    Console.WriteLine($"Antalet av roddbåtar: {antalRoddbåtar}\nAntalet av motorbåtar: {antalMotorbåtar}\nAntalet av segelbåtar: {antalSegelbåtar}\nAntalet av lastfartyg: {antalLastfartyg}");
                    sw.WriteLine($"Antalet av roddbåtar: {antalRoddbåtar}\nAntalet av motorbåtar: {antalMotorbåtar}\nAntalet av segelbåtar: {antalSegelbåtar}\nAntalet av lastfartyg: {antalLastfartyg}");

                    double maxMedeltal = maxhastighet / TotalHastighet;
                    Console.WriteLine("Medelhastigheten är: " + Math.Round(maxMedeltal, 1) + " km/h");
                    sw.WriteLine("Medelhastigheten är: " + Math.Round(maxMedeltal, 1) + " km / h");
                    Console.WriteLine("Total vikt är: " + vikt + " kg\n");
                    sw.WriteLine("Total vikt är: " + vikt + " kg\n");

                    // Visa vilka båtar fick inte plats
                    Console.WriteLine("Båtar som inte får någon plats:");
                    sw.WriteLine("Båtar som inte får någon plats:");
                    foreach (var item in BåtarUtanHamnPlats)
                    {
                        Console.WriteLine($"{item.BåtTyp} med ID nummer: {item.IdNummer}");
                        sw.WriteLine($"{item.BåtTyp} med ID nummer: {item.IdNummer}");
                    }



                    båtarSkapade.Clear();
                    BåtarUtanHamnPlats.Clear();

                    dag++;

                    Console.WriteLine();
                    Console.WriteLine("Nästa dag, klicka enter");
                    sw.Close();
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        Console.Clear();
                    File.WriteAllText(fileName, "");


                }
            }

        }
    }

}
