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
            Dictionary<string, Dictionary<string, object>>? employeesDictionary = new Dictionary<string, Dictionary<string, object>>();

            if (File.Exists(filename))
            {
                string jsonText = File.ReadAllText(filename);
                employeesDictionary = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(jsonText);
            }
            if (employeesDictionary == null)
                employeesDictionary = new Dictionary<string, Dictionary<string, object>>();

            do
            {
                index = MenueAnzeigen(menue);
                switch (index)
                {
                    case 1:
                        FindAllEmployees(employeesDictionary);
                        break;
                    case 2:
                        FindEmployeeById(employeesDictionary);
                        break;
                    case 3:
                        RegisterEmployee(employeesDictionary, filename);
                        break;
                    case 4:
                        RemoveEmployeeById(employeesDictionary, filename);
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

        private static string GetEmployeeId()
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

        private static void RemoveEmployeeById(Dictionary<string, Dictionary<string, object>> employees, string filename)
        {
            string id = GetEmployeeId();
            if (employees.Count > 0 && employees.ContainsKey(id))
            {
                employees.Remove(id);
                SaveEmployeesToFile(filename, employees);
                Console.WriteLine($"Mitarbeiter mit id {id} wurde erfolrgreich entfernt");
            }
            else
            {
                Console.WriteLine($"Fehler: Mitarbeiter mit id {id} wurde nicht gefunden");
            }
        }

        private static void FindEmployeeById(Dictionary<string, Dictionary<string, object>> employees)
        {
            string id = GetEmployeeId();
            if (employees.Count > 0 && employees.ContainsKey(id))
            {
                Console.WriteLine(employees[id]);
            }
            else
            {
                Console.WriteLine($"Fehler: Mitarbeiter mit id {id} wurde nicht gefunden");
            }
        }

        private static void FindAllEmployees(Dictionary<string, Dictionary<string, object>> employees)
        {
            if (employees.Count > 0)
            {
                foreach (var id in employees.Keys)
                {
                    Console.WriteLine($"ID: {id}");
                    foreach (var key in employees[id].Keys)
                    {
                        Console.WriteLine($"{key}: {employees[id][key]}");
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

        private static void RegisterEmployee(Dictionary<string, Dictionary<string, object>> employees, string filename)
        {
            string id = GetEmployeeId();

            if (employees.ContainsKey(id))
            {
                Console.WriteLine($"Fehler: Mitarbeiter mit id {id} ist bereits registriert");
            }
            else
            {
                Dictionary<string, object> employee = new Dictionary<string, object>();
                Console.Write("Bitte Namen eingeben: ");
                employee.Add("Name", (Console.ReadLine() ?? "").Trim());
                Console.Write("Bitte Nachname eingeben: ");
                employee.Add("Nachname", (Console.ReadLine() ?? "").Trim());
                Console.Write("Bitte Urlaubstage eingeben: ");
                int.TryParse(Console.ReadLine(), out int tage);
                employee.Add("Urlaubstage", tage);
                employee.Add("Krankheitstage", new string[] { });

                employees.Add(id, employee);
                SaveEmployeesToFile(filename, employees);
            }
        }
    }
}
