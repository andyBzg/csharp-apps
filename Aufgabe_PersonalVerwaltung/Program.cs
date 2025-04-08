using System.Text.Json;

namespace Aufgabe_PersonalVerwaltung
{
    // Erstelle ein einfaches Personal verwaltungsprogramm 
    // Dieses soll uns erlauben eine Kartei über einen oder mehrere Mittarbeiter zu erstellen und auszugeben und auch einzelne Mittarbeiter wieder entfernen
    // mit folgenden Informationen: Name - Nachname - Urlaubstage - Array(mit Datum von Krankheitstagen)(das Array darf leer sein)
    // Sorge dafür das die Personen gespeichert werden in einer json-datei
    // und auch wieder abgerufen werden können automatisch beim start des Programms
    internal class Program
    {
        static void Main(string[] args)
        {
            bool weiter = true;
            int index;
            string id, filename = "mitarbeiter.json";
            string[] informationen = { "Name", "Nachname", "Urlaubstage", "Krankheitstage" };
            string[] menue = { "Alle Mitarbeiter anzeigen", "Mitarbeiter mit Id suchen", "Neuer Mitarbeiter erstellen", "Mitarbeiter entfernen", "Programm beenden" };

            if (!File.Exists(filename))
            {
                Dictionary<string, Dictionary<string, object>> dictionary = new Dictionary<string, Dictionary<string, object>>();
                string jsonString = JsonSerializer.Serialize(dictionary, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filename, jsonString);
            }

            do
            {
                index = MenueAnzeigen(menue);
                switch (index)
                {
                    case 1:
                        LoadAllEmployeesFromFile(filename);
                        break;
                    case 2:
                        id = GetMitarbeiterId();
                        LoadEmployeeByIdFromFile(filename, id);
                        break;
                    case 3:
                        RegisterEmployee(filename);
                        break;
                    case 4:
                        id = GetMitarbeiterId();
                        RemoveEmployeeById(filename, id);
                        break;
                    case 5:
                        weiter = false;
                        break;
                    default:
                        Console.WriteLine("Unbekannter Fehler...");
                        break;
                }

                Console.WriteLine("Bitte drücken Sie Enter, um fortzufahren...");
                Console.ReadKey();
                Console.Clear();
            } while (weiter);
        }

        private static string GetMitarbeiterId()
        {
            Console.Write("Bitte Mitarbeiter Id eingeben: ");
            return Console.ReadLine() ?? "";
        }

        private static int MenueAnzeigen(string[] menue)
        {
            int index;
            bool check;
            for (int i = 0; i < menue.Length; i++)
            {
                Console.WriteLine($"({i + 1}) {menue[i]}");
            }
            Console.WriteLine();

            do
            {
                Console.Write($"Ihre Wahl (1 - {menue.Length}): ");
                check = int.TryParse(Console.ReadLine(), out index);
            }
            while (!(check && index > 0 && index <= menue.Length));
            return index;
        }

        private static void RemoveEmployeeById(string filename, string id)
        {
            string file = File.ReadAllText(filename);
            Dictionary<string, Dictionary<string, object>>? dictionary = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(file);
            if (dictionary != null && dictionary.ContainsKey(id))
            {
                dictionary.Remove(id);
                SaveEmployeesToFile(filename, dictionary);
                Console.WriteLine($"Mitarbeiter mit id {id} wurde erfolrgreich entfernt");
            }
            else
            {
                Console.WriteLine($"Fehler: Mitarbeiter mit id {id} wurde nicht gefunden");
            }
        }

        private static void LoadEmployeeByIdFromFile(string filename, string id)
        {
            string gelesenerText = File.ReadAllText(filename);
            Dictionary<string, object>? geladenesDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(gelesenerText);

            if (geladenesDictionary != null && geladenesDictionary.ContainsKey(id))
            {
                Console.WriteLine(geladenesDictionary[id]);
            }
            else
            {
                Console.WriteLine($"Fehler: Mitarbeiter mit id {id} wurde nicht gefunden");
            }
        }

        private static void LoadAllEmployeesFromFile(string filename)
        {
            string gelesenerText = File.ReadAllText(filename);
            Dictionary<string, Dictionary<string, object>>? geladenesDictionary = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(gelesenerText);
            if (geladenesDictionary != null)
            {
                foreach (var id in geladenesDictionary.Keys)
                {
                    Console.WriteLine($"ID: {id}");
                    foreach (var key in geladenesDictionary[id].Keys)
                    {
                        Console.WriteLine($"{key}: {geladenesDictionary[id][key]}");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Fehler: Keine Mitarbeiter gefunden");
            }
        }

        private static void SaveEmployeesToFile(string filename, Dictionary<string, Dictionary<string, object>> employees)
        {
            string jsonString = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, jsonString);
        }

        private static void RegisterEmployee(string filename)
        {
            string file = File.ReadAllText(filename);
            Dictionary<string, Dictionary<string, object>>? dictionary = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(file);
            if (dictionary == null)
            {
                dictionary = new Dictionary<string, Dictionary<string, object>>();
            }

            string id = GetMitarbeiterId();

            if (dictionary.ContainsKey(id))
            {
                Console.WriteLine($"Fehler: Mitarbeiter mit id {id} ist bereits registriert");
            }
            else
            {
                Dictionary<string, object> employee = new Dictionary<string, object>();
                Console.Write("Bitte Namen eingeben: ");
                employee.Add("Name", Console.ReadLine() ?? "");
                Console.Write("Bitte Nachname eingeben: ");
                employee.Add("Nachname", Console.ReadLine() ?? "");
                Console.Write("Bitte Urlaubstage eingeben: ");
                int.TryParse(Console.ReadLine(), out int tage);
                employee.Add("Urlaubstage", tage);
                employee.Add("Krankheitstage", new string[] { });

                dictionary.Add(id, employee);
                SaveEmployeesToFile(filename, dictionary);
            }
        }
    }
}
