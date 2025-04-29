namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Programmiere eine Methode, die genau ein Argument entgegen nimmt,
            // dieses sortiert mit dem Bubblesort Algorithmus.
            // Recherchire selbständig wie Bubblesort funktioniert.
            // Die Ausgabe soll vom Typ Double sein, bedeutet wenn wir der Methode
            // ein int-array geben, gibt die ein sortiertes double-array zurück.

            // GANZ WICHTIG!
            // Es muss ein eigner Algorithmus geschrieben werden
            // verboten sind (Listen, Sort-Funktion und Reverse Funktion)!

            //    [45, 99, 62, 8, 5, 33, 4, 8, 6, 5]
            // -> [4, 5, 5, 6, 8, 8, 33, 45, 62, 99]

            int[] daten1 = { 45, 99, 62, 8, 5, 33, 4, 8, 6, 5 };
            double[] daten2 = { 20.5, 18.6, 10.4, 12.3 };
            float[] daten3 = { 15.7f, 22.55f, 99.99f, 1.6f, 10.8f };

            double[] sorted1 = Sortiere(daten1);
            double[] sorted2 = Sortiere(daten2);
            double[] sorted3 = Sortiere(daten3);

            PrintArray(sorted1);
            PrintArray(sorted2);
            PrintArray(sorted3);
        }

        private static double[] Sortiere(object input)
        {
            double[] array = CastObjectToDoubleArray(input);

            int length = array.Length;
            while (length != 0)
            {
                int maxIndex = 0;
                for (int i = 1; i < length; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        double temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;

                        maxIndex = i;
                    }
                }
                length = maxIndex;
            }
            return array;
        }

        private static double[] CastObjectToDoubleArray(object input)
        {
            Array array = (Array)input;
            double[] result = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = Convert.ToDouble(array.GetValue(i));
            }
            return result;
        }

        private static void PrintArray(double[] array)
        {
            foreach (var item in array)
            {
                Console.Write(Math.Round(item, 2) + " ");
            }
            Console.WriteLine();
        }
    }
}
