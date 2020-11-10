using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnen_Dilan
{
    class Segelbåt : Båt  //Klass segelbåt
    {
        public int BåtLength { get; set; }

        string IdPrefix = "S-";
        int minVikt = 800;
        int maxVikt = 6000;
        int minSpeed = 0;
        int maxiSpeed = 12;


        public Segelbåt()
        {
            BåtTyp = "SegelBåt";
            IdNummer = IdPrefix + GetNummerID();
            UnikEgenskap = AddUnikEgenskap();
            Vikt = AddVikt(minVikt, maxVikt);
            MaxSpeed = AddMaxSpeed(minSpeed, maxiSpeed);
            AntalDygnIHamnen = 4;
            PlatserSomTas = 2.0;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(10, 60 + 1);
            string unik = $"Båtens längd: {randomNummer} ";
            return unik;
        }
    }
}