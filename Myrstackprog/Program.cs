using System;
using System.Collections.Generic;
#pragma warning disable IDE0044

namespace Myrstackprog
{

    class Myrstacken
    {
        /*
         * Robin:
         * Jag gillar inte att Ants är statisk. Det påverkar inget just nu, 
         * men det är en dålig vana att använda static när man inte behöver.
         */
        static
        public List<Ant> Ants = new List<Ant>();

        public static void Main()
        {
            {
                Console.WriteLine("Welcome to the anthill!");
                Console.WriteLine();
                Console.WriteLine("For a list of commands, type 'help'");
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Enter command:");
                string input = Console.ReadLine();
                if (input == "help")
                {
                    Console.WriteLine();
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("add ant - adds ant to anthill");
                    Console.WriteLine("remove ant - removes ant from anthill");
                    Console.WriteLine("search ant - searches an ant by name/legs and displays info about them");
                    Console.WriteLine("print total ants - total number of ants in anthill");
                    Console.WriteLine("print all ants -  all ants and their respective amount of legs");
                    Console.WriteLine("quit - closes the program");
                }
                else if (input == "add ant")
                {
                    Addant();
                }
                else if (input == "print all ants")
                {
                    Printants();
                }
                else if (input == "remove ant")
                {
                    Removeant();
                }
                else if (input == "print total ants")
                {
                    Printanttotal();
                }
                else if (input == "search ant")
                {
                    Searchant();
                }
                else if (input == "quit")
                {
                    Closeprogram();
                }
                else if (input != "help" + "add ant" + "print all ants" + "remove ant" + "print total ants" + "search ant" + "quit")
                {
                    Main();
                }

            }

            // Här nere så befinner sig alla metoder

            void Addant()
            {
                Console.WriteLine();
                Console.WriteLine("Enter name of ant:");
                string name = Console.ReadLine().ToLower();
                /*
                 * Robin:
                 * Skulle behöva en try-catch här för att undvika att programmet kraschar om man
                 * skriver in något som inte är en siffra. Gäller även för Searchant().
                 */
                Console.WriteLine();
                Console.WriteLine("Enter number of legs:");
                string legs = Console.ReadLine();
                int legs2 = int.Parse(legs);

                if (legs2 > 6)
                {
                    Console.WriteLine();
                    Console.WriteLine("Don't ants usually have 6 legs? Ah whatever, it's cool.");
                }

                Ant ant = new Ant(name, legs2);

                Ants.Add(ant);
            }

            void Printants()
            {
                Console.WriteLine();
                Console.WriteLine("Ants present in anthill:");
                foreach (Ant ant in Ants)
                {
                    Console.WriteLine(ant.Name + ", " + ant.Legs + " " + "legs");
                }

            }

            void Removeant()
            {
                Console.WriteLine();
                Console.WriteLine("Enter name of ant you want to remove:");
                string anttoremove = Console.ReadLine().ToLower();

                for (int i = 0; i < Ants.Count; i++)
                {
                    var ant = Ants[i];
                    if (ant.Name == anttoremove)
                    {
                        Ants.Remove(ant);
                        Console.WriteLine("");
                        Console.WriteLine(anttoremove + " " + "has been safely relocated from anthill.");
                    }

                }

            }

            void Printanttotal()
            {
                Console.WriteLine();
                Console.WriteLine("Total number of ants in anthill:");
                Console.WriteLine(Ants.Count);
            }

            void Searchant()
            {
                Console.WriteLine();
                Console.WriteLine("Do you want to search by name or legs?");
                string input = Console.ReadLine();

                if (input == "name")
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter name of ant you're searching for:");
                    string name = Console.ReadLine().ToLower();

                    for (int i = 0; i < Ants.Count; i++)
                    {
                        var ant = Ants[i];

                        if (ant.Name == name)
                        {

                            Console.WriteLine();
                            Console.WriteLine(String.Format("Ant found! Name: {0}, Legs: {1}", ant.Name, ant.Legs));
                        }

                    }

                }
                else if (input == "legs")
                {

                    Console.WriteLine();
                    Console.WriteLine("Enter the number of legs of the ant you're searching for:");
                    string legs = Console.ReadLine();
                    int legs2 = int.Parse(legs);

                    for (int i = 0; i < Ants.Count; i++)
                    {
                        var ant = Ants[i];

                        if (ant.Legs == legs2)
                        {
                            Console.WriteLine();
                            Console.WriteLine(String.Format("Ant found! Name: {0}, Legs: {1}", ant.Name, ant.Legs));
                        }

                    }

                }

            }

            void Closeprogram()
            {
                Console.WriteLine();
                Console.WriteLine("See you next time!");
                Environment.Exit(0);
            }

        }

    }

    class Ant
    {
        public string Name { get; private set; }
        public int Legs { get; private set; }

        public Ant(string name, int legs)
        {
            this.Name = name;
            this.Legs = legs;
        }

    }

}

/*
 * Robin:
 * Bra jobbat! Finns några problem som vi kan arbeta på tills nästa gång:
 * 
 * Jag är inte ett jättestort fan av namngivningen av två anledningar: dels
 * så börjar du metoder med inledande versal men låter sedan efterföljande 
 * ord börja med en gemen. Detta har jag inte sett förut, och gör koden svårare 
 * att läsa. Sen så kan man förkorta många av metodnamnen, då namnet på klassen
 * (d.v.s. Myrstacken) redan förklarar vad klassen handlar om, så att specificera
 * 'ant' i varje metod känns lite överflödigt. Detta är absolut saker som vi 
 * kommer att öva på mer under lektionerna, och du får gärna rådgöra med mig
 * om du känner dig osäker.
 * 
 * Programmet är robust i de flesta avseenden, dock så har du ingen 
 * undantagshantering för int.Parse(string), vilket lätt leder till krashar
 * om man råkar skicka in något som inte kan kastas om till en int.
 * Läs gärna på lite om try-catch, så ska vi se till att vi sätter det 
 * nästa gång!
 * 
 * Bra jobbat! Fortsätt kämpa så kommer du bli grym!
 */