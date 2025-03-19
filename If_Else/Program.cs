namespace If_Else
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int zahl = 3;

            if (zahl >= 5)      // Bedingung => Wahrheitswert
            {
                Console.WriteLine("Die Zahl ist größer oder gleich 5.");
            }
            else        // optional
            {
                Console.WriteLine("Die Zahl ist kleiner 5.");
            }

            Console.WriteLine("Ende.");
            Console.WriteLine();

            int wert = 5;

            if (wert >= 20)
            {
                Console.WriteLine("Der Wert ist größer 20.");
            }
            else if (wert >= 10)
            {
                Console.WriteLine("Der Wert ist größer 10.");
            }
            else
            {
                Console.WriteLine("Der Wert ist kleiner 10.");
            }

            string s1 = "Hi";

            if (s1 == "Hallo")
            {
                Console.WriteLine("Ja, da steht Hallo.");
            }
            else
            {
                Console.WriteLine("Nein, da steht nicht Hallo.");
            }
        }
    }
}
