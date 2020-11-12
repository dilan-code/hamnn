using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen_Dilan
{

    class Roddbåt : Boat //Klass Roddbåt
    {
        public int MaxPassenger { get; set; }

        string IdPrefix = "R-";
        int minVikt = 100;
        int maxVikt = 300;
        int minSpeed = 0;
        int maxiSpeed = 3;


        public Roddbåt()
        {
            BåtTyp = "RoddBåt ";
            IdNummer = IdPrefix + GetNummerID();
            UnikEgenskap = AddUnikEgenskap();
            Vikt = AddVikt(minVikt, maxVikt);
            MaxSpeed = AddMaxSpeed(minSpeed, maxiSpeed);
            AntalDygnIHamnen = 1;
            PlatserSomTas = 0.5;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(1, 6 + 1);
            string unik = $"Maximal antal passangerare: {randomNummer}";
            return unik;
        }
    }
}
