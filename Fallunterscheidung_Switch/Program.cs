namespace Fallunterscheidung_Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // if-else
            int zahl1 = 15;

            if (zahl1 > 10)
            {
                Console.WriteLine("Die Zahl ist größer 10.");
            }

            // Mehrfache Fallunterscheidung: switch
            // Unterschied zu if-else: Hier wird der Inhalt der Variable überprüft
            // und kein true/false-Argument

            int zahl2 = 1;

            switch (zahl1)
            {
                case 1:
                    Console.WriteLine("Die Zahl ist 1!");
                    break;
                case 2:
                    Console.WriteLine("Die Zahl ist 2!");
                    break;
                case 3:
                    Console.WriteLine("Die Zahl ist 3!");
                    break;
                case -5678:
                    Console.WriteLine("Die Zahl ist -5678!");
                    break;
                default:
                    Console.WriteLine("Nix stimmt");
                    break;
            }

            string name = "Karl";

            switch (name)
            {
                case "Karl":
                    Console.WriteLine("Hey Karl!");
                    break;
                case "Karlchen":
                    Console.WriteLine("Na, alles klar?");
                    break;
                case "Hanz":
                    Console.WriteLine("Na, alles auf Dampf?");
                    break;
                default:
                    Console.WriteLine("Sorry, Dich kenne ich nicht");
                    break;
            }
        }
    }
}
