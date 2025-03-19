namespace Console_Brauerei
{
    internal class Program
    /*Eine Brauerei gewährt Kunden
    bei Abnahme von mindestens 10 Kästen 5 % Rabatt
    bei Abnahme von mindestens 50 Kästen 7 % Rabatt
    bei Abnahme von mindestens 100 Kästen 10 % Rabatt.

    Erstellen Sie ein Programm, welches die Eingabe
    der Menge (in Anzahl Kästen) erlaubt und dann den Prozentsatz
    richtig ermittelt und anschließend ausgibt.*/
    {
        static void Main(string[] args)
        {
            string eingabeNachricht = "Herzlich Willkommen bei der Brauerei! \nBitte geben Sie die Anzahl der Bierkisten ein: ";
            string falscheEingabe = "Ungültige Eingabe! Bitte geben Sie ein Zahl ein!";

            Console.Write(eingabeNachricht);

            string eingabe = Console.ReadLine();

            if (int.TryParse(eingabe, out int kistenzahl) && kistenzahl >= 0)
            {
                int rabatt = BerechneRabatt(kistenzahl);
                Console.WriteLine($"Sie haben {kistenzahl} Kisten bestellt. Sie bekommen {rabatt}% Rabatt!");
            }
            else
            {
                Console.WriteLine(falscheEingabe);
            }
        }

        private static int BerechneRabatt(int kistenzahl)
        {
            if (kistenzahl >= 100)
            {
                return 10;
            }
            else if (kistenzahl >= 50)
            {
                return 7;
            }
            else if (kistenzahl >= 10)
            {
                return 5;
            }
            return 0;
        }
    }
}
