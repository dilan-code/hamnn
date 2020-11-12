using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen_Dilan
{
    class Lastfartyg : Boat //Klass Lastfartyg
    {
        public int Containers { get; set; }

        string IdPrefix = "L-";
        int minVikt = 3000;
        int maxVikt = 20000;
        int minSpeed = 0;
        int maxiSpeed = 20;

        public Lastfartyg()
        {
            BåtTyp = "Lastfartyg";
            IdNummer = IdPrefix + GetNummerID();
            UnikEgenskap = AddUnikEgenskap();
            Vikt = AddVikt(minVikt, maxVikt);
            MaxSpeed = AddMaxSpeed(minSpeed, maxiSpeed);
            AntalDygnIHamnen = 6;
            PlatserSomTas = 4.0;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(500 + 1);
            string unik = $"Containers totalt på fartyget: {randomNummer}";
            return unik;
        }
    }
}
