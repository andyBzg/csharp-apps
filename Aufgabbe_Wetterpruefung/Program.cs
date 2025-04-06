namespace Aufgabbe_Wetterpruefung
{
    /*Der User soll dir mitteilen, ob das Wetter gerade "sonnig" oder "regnerisch" ist. 
    Auch die Temperatur soll der User angeben können. 
    Liegt die Temperatur bei oder über 20°C und es ist sonning, empfehle dem User ein T-Shirt zu tragen. 
    Liegt die Temperatur unter 20°C und es ist sonnig, empfehle eine Jacke anzuziehen. 
    Bei regnerischen Wetter werden ebenfalls die zur Temperatur passenden Kleidungsempfehlungen ausgesprochen und der User soll darauf hingewiesen werden, dass er einen Regenschirm mitnehmen soll. 
    Etwaige falsche Eingaben sollen über einen else-Block abgefangen werden. */
    internal class Program
    {
        static void Main(string[] args)
        {
            string? wetter;
            int temperatur;
            bool check = false;

            do
            {
                Console.Write("Bitte geben Sie das Wetter an (sonnig/regnerisch): ");
                wetter = Console.ReadLine()?.ToLower();

                if (wetter != null && wetter == "sonnig" || wetter == "regnerisch")
                {
                    Console.WriteLine($"Das Wetter ist {wetter}");
                    do
                    {
                        Console.Write("Bitte geben Sie die Temperatur an: ");
                        check = int.TryParse(Console.ReadLine(), out temperatur);

                        if (!check)
                        {
                            Console.WriteLine("Fehler: Bitte ein Zahl eingeben!");
                        }
                        else if (temperatur < -50 || temperatur > 50)
                        {

                            Console.WriteLine("Fehler: Bitte eine Temperatur zwischen -50 und 50 eingeben!");
                            check = false;
                        }
                        else
                        {
                            check = true;
                        }

                        if (wetter == "sonnig")
                        {
                            if (temperatur >= 20)
                            {
                                Console.WriteLine("Empfehlung: T-Shirt tragen.");
                            }
                            else
                            {
                                Console.WriteLine("Empfehlung: Jacke anziehen.");
                            }
                        }
                        else if (wetter == "regnerisch")
                        {
                            if (temperatur >= 20)
                            {
                                Console.WriteLine("Empfehlung: T-Shirt tragen und Regenschirm mitnehmen.");
                            }
                            else
                            {
                                Console.WriteLine("Empfehlung: Jacke anziehen und Regenschirm mitnehmen.");
                            }
                        }
                    }
                    while (!check);

                    check = true;
                }
                else if (string.IsNullOrEmpty(wetter))
                {
                    Console.WriteLine("Fehler: Bitte eine gültige Eingabe machen!");
                }
                else
                {
                    Console.WriteLine("Fehler: Bitte 'sonnig' oder 'regnerisch' eingeben!");
                }
            }
            while (!check);
        }
    }
}
