namespace Schaltjahr_Lösung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jahr;
            bool schaltjahr;

            Console.Write("Bitte geben Sie Ihre Jahreszahl ein: ");
            jahr = int.Parse(Console.ReadLine());

            // Variante 1
            if (jahr % 400 == 0)
            {
                Console.WriteLine("Ist ein Schaltjahr");
            }
            else if (jahr % 100 == 0)
            {
                Console.WriteLine("Ist kein Schaltjahr");
            }
            else if (jahr % 4 == 0)
            {
                Console.WriteLine("Ist ein Schaltjahr");
            }
            else
            {
                Console.WriteLine("Ist kein Schaltjahr");
            }

            // Variante 2   && => AND,  || => OR

            // if (Bedingung1 AND Bedingung2)
            // Bedingung1 | Bedingung2 | Aussage
            //      0     |     0      |    0
            //      1     |     0      |    0
            //      0     |     1      |    0
            //      1     |     1      |    1

            // if (Bedingung1 OR Bedingung2)
            // Bedingung1 | Bedingung2 | Aussage
            //      0     |     0      |    0
            //      1     |     0      |    1
            //      0     |     1      |    1
            //      1     |     1      |    1

            if (jahr % 4 == 0 && jahr % 100 != 0 || jahr % 400 == 0)
            {
                Console.WriteLine("Ist ein Schaltjahr");
            }
            else
            {
                Console.WriteLine("Ist kein Schaltjahr");
            }

            schaltjahr = (jahr % 4 == 0 && jahr % 100 != 0 || jahr % 400 == 0) ? true : false;
            if (schaltjahr)
            {
                Console.WriteLine("Ist ein Schaltjahr");
            }
            else
            {
                Console.WriteLine("Ist kein Schaltjahr");
            }

            Console.WriteLine((jahr % 4 == 0 && jahr % 100 != 0 || jahr % 400 == 0 ? true : false) ? "Schaljahr" : "Kein Schaltjahr");

            if (int.TryParse(Console.ReadLine(), out int jahr2))
            {
                Console.WriteLine();
            }
            
        }
    }
}
