namespace Aufgabe_Fibonacci
{
    /*Der User soll angeben können wie viele Zahlen der Fibonacci-Folge er berechnet haben möchte. 

    Gib in der Konsole dann die entsprechenden Zahlen aus. 

    Die Fibonacci-Folge beginnt immer mit den zahlen 0 und 1. Jede weitere Zahl ergibt sich, indem man die beiden vorherigen Zahlen zusammenzählt. 
    Als Beispiel die ersten zehn Zahlen: 

    0 1 1 2 3 5 8 13 21 34 
    a+b=c
      a+b=c
        a b c
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            uint anzahl;

            Console.WriteLine("Wie viele Zahlen der Fibonacci-Folge möchten Sie berechnen?");
            Console.Write("Anzahl: ");
            bool check = uint.TryParse(Console.ReadLine(), out anzahl);

            if (check && anzahl > 0)
            {
                int a = 0;
                int b = 1;
                int c;

                for (int i = 0; i < anzahl; i++)
                {
                    Console.Write(a + " ");
                    c = a + b;
                    a = b;
                    b = c;
                }
            }
            else
            {
                Console.WriteLine("Fehler: Bitte geben Sie eine gültige positive Zahl ein.");
            }

        }
    }
}

