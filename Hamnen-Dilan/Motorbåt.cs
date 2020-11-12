using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen_Dilan
{

    class Motorbåt : Boat  //Klass motorbåt
    {
        public int Hästkrafter { get; set; }

        string IdPrefix = "M-";
        int minVikt = 200;
        int maxVikt = 3000;
        int minSpeed = 0;
        int maxiSpeed = 60;


        public Motorbåt()
        {
            BåtTyp = "Motorbåt";
            IdNummer = IdPrefix + GetNummerID();
            UnikEgenskap = AddUnikEgenskap();
            Vikt = AddVikt(minVikt, maxVikt);
            MaxSpeed = AddMaxSpeed(minSpeed, maxiSpeed);
            AntalDygnIHamnen = 3;
            PlatserSomTas = 1.0;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(10, 1000 + 1);
            string unik = $"Antal hästkrafter: {randomNummer}";
            return unik;
        }

    }
}
