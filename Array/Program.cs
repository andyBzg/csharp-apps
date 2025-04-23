namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Array: Collection => Möglichkeit, mehrere Werte unter einem Bezeichner zu speichern
            // Einzelne Einträge eines Arrays werden auch als Felder oder Wertfelder bezeichnet

            int[] intArr = new int[5]; // Index: 0 bis 4

            intArr[0] = 25;
            intArr[1] = 187;

            Console.WriteLine(intArr[1]);
            Console.WriteLine(intArr.Length); // Gibt die Länge des Arrays aus (new int[5]: Länge = 5)

            string[] stringArr = new string[5];
            Console.WriteLine(stringArr[0]);

            // Array erstellen, der direkt mit Werten befüllt wird
            int[] intArr2 = { 247, 685, 1, 13, 42, 6 }; // Größe des Arrays: 6
            intArr2[0] = 25;

            string[] autos = { "BMW", "Audi", "Opel", "Skoda" };
            Console.WriteLine(autos[0]);
            Console.WriteLine(autos[autos.Length - 1]);

            for (int i = 0; i < autos.Length; i++)
            {
                Console.WriteLine(autos[i]);
            }

            foreach (var item in autos)
            {
                Console.WriteLine(item);
            }

            // Wir suchen in unserem Array Autos nach dem Opel
            for (int i = 0; i < autos.Length; i++)
            {
                if (autos[i] == "Opel")
                {
                    Console.WriteLine($"Das Auto befindet sich auf dem {i + 1}en Feld");
                }
            }

            //Aufgabe:
            //Erstellt ein neues int-Array der Größe 7 und initialisiert !!DANACH!! die Felder mit beliebigen, von euch ausgesuchten
            //Werten.
            //Die Werte müssen nicht zufällig bestimmt werden.
            //Lasst dann zählen, wie oft die Zahl 1 vorkommt. Gib die Anzahl dann in der Konsole aus.

            int[] array = new int[7] { 1, 3, 1, 33, 1, 4, 9 };
            int zaehler = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 1) zaehler++;
            }
            Console.WriteLine($"Die Zahl 1 kommt {zaehler} Mal vor");
        }
    }
}
