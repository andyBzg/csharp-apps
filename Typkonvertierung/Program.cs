namespace Typkonvertierung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variablen 
            int alter;
            bool check;

            // Eingabe
            do
            {
                Console.WriteLine("Bitte geben Sie Ihr Alter ein: ");
                check = int.TryParse(Console.ReadLine(), out alter);

                if (check == false)
                {
                    Console.WriteLine("Aldaaaaa, nur Zahlen!");
                }
            }
            while (check == false);

            // Ausgebe
            Console.WriteLine($"Sie sind {alter} Jahre alt.");
        }
    }
}
