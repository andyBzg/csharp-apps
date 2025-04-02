namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Array: Collection => Möglichkeit, mehrere Werte unter einem Bezeichner zu speichern

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
        }
    }
}
