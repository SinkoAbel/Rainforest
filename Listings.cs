using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainforest
{
    class Listings
    {

        /// <summary>
        /// A program célját írja le.
        /// </summary>
        public static void PurposeOfProgram()
        {
            Console.WriteLine("Ez a program az esőerdők pusztulását hivatott szimulálni!\nA program a 2014. évig fut.\n");
        }

        public static void StartingYear()
        {
            Console.Write("Adjon meg egy kezdeti évszámot: ");
        }


        /// <summary>
        /// Menü pontok és a jelenlegi év listázása.
        /// </summary>
        /// <param name="currentYear"></param>
        public static void MenuPoints (ushort currentYear)
        {
            Console.Clear();
            Console.WriteLine("\t{0}. évi adatok szerkesztése\n", currentYear);

            Console.WriteLine("U: Új esőerdő felvitele az adatbázisba");
            Console.WriteLine("S: Erdőirtások szimulálása az aktuális évben");
            Console.WriteLine("K: Adatok kiiratása");
            Console.WriteLine("L: Lépés a következő évre");
            Console.WriteLine("Esc: Új esőerdő felvitele az adatbázisba");
        }
        

        public static void U_KeyEvents (List<string> rainforests, List<float> OriginalRainforestSize, List<float> NewRainforestSize)
        {
            string inputNewRainforest; 
            do
            {
                Console.Write("\n\tEsőerdő neve: ");
                inputNewRainforest = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(inputNewRainforest));
             
            
            rainforests.Add(inputNewRainforest);


            int inputNewSize;
            do
                Console.Write("\tKiterjedése(km2): ");
            while (!int.TryParse(Console.ReadLine(), out inputNewSize));
            
            OriginalRainforestSize.Add(inputNewSize);
            NewRainforestSize.Add(inputNewSize);
        }


        public static byte InputDestruction ()
        {
            byte destructionPercentageIn;

            do
                Console.Write("\n\tAdjon meg egy százalék értéket (Maximum 5% -> ugyanebben a formátumban): ");
            while (!byte.TryParse(Console.ReadLine(), out destructionPercentageIn) || destructionPercentageIn > 5 || destructionPercentageIn < 0);

            return destructionPercentageIn;
        }


        /// <summary>
        /// Bekér a felhasználótól egy üzemmódot, és vissza adja az üzemmód értékét (string) 
        /// </summary>
        /// <returns></returns>
        public static string ModeSelection ()
        {
            string selectMode;
            const string onlyOne = "egyet";
            const string doItAll = "mind";

            do
            {
                Console.Write("\tMinden eső erdő területét kívánja csökkenteni vagy csak egy randomét? ({0}/{1}): ", onlyOne, doItAll);
                selectMode = Console.ReadLine().ToLower();

                if (selectMode == doItAll || selectMode == onlyOne)
                    break;

            } while (string.IsNullOrWhiteSpace(selectMode));

            return selectMode;
        }

        /// <summary>
        /// A program kiírja, hogy melyik módot választotta felhasználó.
        /// </summary>
        /// <param name="selectedMode"></param>
        /// <returns></returns>
        public static void ModeSelectionMessage (string selectedMode, byte destructionPercentage)
        {

            Console.WriteLine("\n\tMindegyik esőerdő területe {0}%-al csökkentve lett!\n", destructionPercentage);

        }
        /// <summary>
        /// A program kiírja, hogy a kiválasztott módnál melyik esőerdő területe lett csökkentve.
        /// </summary>
        /// <param name="selectedMode"></param>
        /// <param name="rainforest"></param>
        /// <returns></returns>
        public static void ModeSelectionMessage(string selectedMode, string rainforest, byte destructionPercentage)
        {
            Console.WriteLine("\n\tA(z) {0} esőerdő mérete {1}%-al csökkentve lett.\n", rainforest, destructionPercentage);
        }


        /// <summary>
        /// Paraméter: 0->ha az évben futott már szimuláció, 1->ha üres az adatbázis
        /// </summary>
        /// <param name="zero_or_one"></param>
        public static void ErrorMessage (byte zero_or_one)
        {
            if (zero_or_one == 0)
                Console.WriteLine("\n\tEbben az évben nem lehet több szimulációt futtatni.");
            else if (zero_or_one == 1)
                Console.WriteLine("\n\tA szimuláció futtatása sikertelen mivel az adatábzis üres.\n\tVigyen fel adatot az adatbázisba!");
        }

        public static void WrongKey()
        {
            Console.WriteLine("\n\tHelytelen billentyű!");
            Console.ReadKey();
        }

        public static void GoodBye ()
        {
            Console.WriteLine("\n\tViszont látásra!");
        }

    }
}
