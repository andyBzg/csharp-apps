namespace Nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Null bedeutet "Nichts" also das kein Wert zugewiesen ist
            string? text = Console.ReadLine(); // Console.ReadLine() kännte bei Abbruch des Prozesses oder
                                               // bei einer Zeitüberschreitung null zurückgeben, was wenn wir
                                               // text nicht nullable markieren zu einem Absturtz führen würde

            // Nullable handling
            // 1
            string text2 = Console.ReadLine() ?? "das ist die Alternative"; // Wenn text2 = null ist, dann schreibe hier "das ist die Alternative"

            // 2
            try
            {
                // Probiere diesen Code aus
                string text3 = Console.ReadLine();
                int meinNeueZahl = Convert.ToInt32(text);
            }
            catch (Exception ex)
            {
                // Bei einer möglichen Exception mache das hier
                Console.WriteLine("Da ist etwas schiefgelaufen: " + ex);
            }

            // 3
            string ausgabe;
            if (text != null)
            {
                ausgabe = text;
            }
            else
            {
                ausgabe = "Daten Fehlerhaft";
            }
            Console.WriteLine(ausgabe);
        }
    }
}
