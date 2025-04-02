namespace Zufallszahlen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int zufall = rnd.Next(1, 51); // Unterer Wert ist inklusive, der obere exkusive
            Console.WriteLine(zufall);
        }
    }
}
