using System;
using System.Collections.Generic;
using System.Linq;

namespace Rainforest
{

    class Program
    {


        static void Main(string[] args)
        {

            ushort currentYear;
            bool exit = false;
            List<string> rainforests = new List<string>();
            List<float> OriginalRainforestSize = new List<float>();
            List<float> NewRainforestSize = new List<float>();
            bool canUse = true;
            Random rand = new Random();
            const string onlyOne = "egyet";
            const string doItAll = "mind";

            // Program célja
            Listings.PurposeOfProgram();

            // Évszám bekérése ahonnan a program kezdődni fog
            do
                Listings.StartingYear();
            while (!ushort.TryParse(Console.ReadLine(), out currentYear) || currentYear > 2013);


            //Main
            do
            {

                Listings.MenuPoints(currentYear);

                ConsoleKeyInfo keyinfo = Console.ReadKey(true);

                switch (keyinfo.Key)
                {
                    //Új esőerdő
                    case ConsoleKey.U:
                        Listings.U_KeyEvents(rainforests, OriginalRainforestSize, NewRainforestSize);
                        break;



                    //Szimuláció
                    case ConsoleKey.S:
                        if (canUse && rainforests.Count > 0)
                        {
                            canUse = false;
                            byte destructionPercentageIn = Listings.InputDestruction();
                            byte destructionPercentage = (byte)rand.Next(0, destructionPercentageIn + 1);

                            //A felhasználó kiválasztja, hogy csak egy vagy az összes esőerdő területét szeretné-e módosítani.
                            string selectMode = Listings.ModeSelection();
                            byte randomForestIndex = (byte)rand.Next(0, rainforests.Count);                            

                            if (selectMode == onlyOne)
                            {
                                NewRainforestSize[randomForestIndex] = Decrease(NewRainforestSize[randomForestIndex], destructionPercentage);
                                
                                Listings.ModeSelectionMessage(selectMode, rainforests[randomForestIndex], destructionPercentage);
                            }
                            else if (selectMode == doItAll)
                            {
                                for (byte i = 0; i < rainforests.Count; i++)
                                    NewRainforestSize[i] = Decrease(NewRainforestSize[i], destructionPercentage);
                                
                                Listings.ModeSelectionMessage(selectMode, destructionPercentage);
                            }
                        }
                        else if (rainforests.Count == 0)
                            Listings.ErrorMessage(1);
                        else
                            Listings.ErrorMessage(0);

                        Console.ReadKey();
                        break;


                    //Kiiratás
                    case ConsoleKey.K:
                        Console.WriteLine("\n\tFelvett esőerdők:");

                        for (byte i = 0; i < rainforests.Count; i++)
                        {
                            if (OriginalRainforestSize[i] == NewRainforestSize[i])
                            {
                                Console.WriteLine("\n\t- {0}: eredeti kiterjedése {1} km2", rainforests[i], OriginalRainforestSize[i]);
                            }
                            else
                            {
                                Console.WriteLine("\n\t- {0}: eredeti kiterjedése {1} km2. Jelenlegi kiterjedése: {2} km2", rainforests[i], OriginalRainforestSize[i], NewRainforestSize[i].ToString("0.00"));
                            }
                        }
                        Console.ReadKey();
                        break;


                    //Átlépés a következő évre
                    case ConsoleKey.L:
                        currentYear++;
                        canUse = true;
                        if (currentYear == 2014)
                        {
                            Console.WriteLine("\n\tElérte a 2014-es évet.");
                            exit = true;
                        }
                        break;

                    //Kilépés a ciklusból és programból
                    case ConsoleKey.Escape:
                        exit = true;
                        break;


                    default:
                        Listings.WrongKey();
                        break;
                }

            } while (!exit);
            
            Listings.GoodBye();
        }

         
        static float Decrease(float currentSize, byte destructionPercentage)
        {
            if (destructionPercentage > 0)
            {
                float destruction = (100 - destructionPercentage) / 100f;
                float newSize = currentSize * destruction;

                return newSize;
            }
            else
                return currentSize; 


        }
        

    }
}
