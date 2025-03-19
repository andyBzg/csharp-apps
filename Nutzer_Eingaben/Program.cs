namespace Nutzer_Eingaben
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int alter;

            Console.Write("Bitte geben Sie Ihren Namen ein: ");
            string name = Console.ReadLine();

            Console.Write("Bitte geben Sie Ihr Alter ein: ");
            string alter_str = Console.ReadLine();
            alter = int.Parse(alter_str);


            if (alter >= 18)
            {
                Console.WriteLine("Hallo, " + name + "! Du darfst eintreten.");
            }
            else
            {
                Console.WriteLine("Hallo, " + name + "! Du darfst nicht eintreten, leider zu jung.");
            }
        }
    }
}
