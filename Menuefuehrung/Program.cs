namespace Menuefuehrung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Begrüßung
            Console.WriteLine("Wullkommen bei unserer Hunde-Auswahl!");
            Console.WriteLine();

            // Menü
            Console.WriteLine("(1) Dackel");
            Console.WriteLine("(2) Bernhadiner");
            Console.WriteLine("(3) Terrier");
            Console.WriteLine("(4) Dalmatiner");
            Console.WriteLine("(5) Chihuahua");
            Console.WriteLine();

            // User-Auswahl
            Console.Write("Bitte treffen Sie Ihre Auswahl: ");
            string eingabe = Console.ReadLine();

            // Verarbeitung der Auswahl
            switch (eingabe)
            {
                case "1":
                    Console.WriteLine("Alles für den Dackel, alles für den Club!");
                    break;
                case "2":
                    Console.WriteLine("Ja, der heißt Beethoven");
                    break;
                case "3":
                    Console.WriteLine("Vorsicht, könnte evtl. bissig sein");
                    break;
                case "4":
                    Console.WriteLine("Nein, kein Alkohol am Halsband");
                    break;
                case "5":
                    Console.WriteLine("Ziemlich laut, bellt viel");
                    break;
                default:
                    Console.WriteLine("Falsche Auswahl: Bitte nur Zahlen von 1 bis 5 auswählen");
                    break;
            }
        }
    }
}
