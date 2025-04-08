using System.Text.Json;

namespace Dictionarys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ein Dictionary ist eine Sammlung von Schlüssel-Wert-Paaren, die genutzt wird, um Daten zu speichern und schnell darauf zuzugreifen.
            // Der vorteil ist der das man nicht über einen Index auf die Daten zugreifen muss, sondern über einen Schlüssel.
            // Man kann sich das wie ein Wörterbuch vorstellen.

            // Aufbau eines Dictionarys:
            // Dictionary<TypSchlüssel, TypWert> bezeihner = new Dictionary<TypSchlüssel, TypWert>();

            Dictionary<string, int> alterVonPersonen = new Dictionary<string, int>();

            // Zuweisung von Schlüssel/Werten
            alterVonPersonen["Anna"] = 25;
            alterVonPersonen["Ben"] = 30;
            alterVonPersonen["Clara"] = 22;

            // Alternativ
            alterVonPersonen.Add("Thorsten", 45);

            // Abrufen eines Wertes aus unserem Dictionary
            Console.WriteLine("Alter von Ben " + alterVonPersonen["Ben"]);
            Console.WriteLine("Alter von Thorsten " + alterVonPersonen["Thorsten"]);

            // Entfernen von Schlüsselpaaren
            alterVonPersonen.Remove("Anna");
            //Console.WriteLine("Alter von Ben " + alterVonPersonen["Anna"]);

            // Dictionary mit undefiniertem Wert-Datentyp
            Dictionary<string, object> person = new Dictionary<string, object>();

            person["name"] = "Thorsten";
            person["alter"] = 45;
            person["funktion"] = "Trainer";

            // Möglichkeit zur überprüfung des Datentüps
            bool x = person["alter"].GetType() == typeof(int);
            Console.WriteLine(x);

            // Oberflächlicher einblick in die Serielisierung zum Speichern und Laden von Informationen

            // Serialisierung in eine Json-Datei
            string jsonString = JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true }); // person in der Dictionary den wir Umwandeln wollen
            File.WriteAllText("person.json", jsonString); // jsonString ist das Dictionary das wir speichern wollen

            // Desiearilisieren aus einer Json in ein Dictionary
            string gelesenerText = File.ReadAllText("person.json");
            Dictionary<string, object>? geladenesDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(gelesenerText);

            if (geladenesDictionary != null)
                Console.WriteLine("Funktion von Thorsten: " + geladenesDictionary["funktion"]);

            Console.WriteLine(jsonString);
        }
    }
}
