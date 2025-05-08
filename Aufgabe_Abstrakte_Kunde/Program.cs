using Aufgabe_Abstrakte_Kunde.Model;
using Aufgabe_Abstrakte_Kunde.Service;
using Aufgabe_Abstrakte_Kunde.Utils;

// Programiere ein Kunden Model
// Erstelle eine abstrakte Klasse, diese soll beinhalten:
// Eine Eigenschaft Name, einen Konstruktor, der den Namen setzt
// Eine Methode Begrüßen mit dem Namen
// Eine abstrakte Methode BerechneRabatt (mit Rückgabewert decimal)

// Dazu abgeleitete Klassen Privatkunden, die 5% Rabatt bekommen, und Firmenkunden, die 10% Rabatt bekommen

// Erstelle zudem ein Algorythmus der es uns erlaubt eine beliebige anzahl an Kunden
// zu erstellen und der uns entschieden lässt ob der entsprechende Kunde Privat oder Firmen Kunden ist
// Am Ende sollen alle Kunden ausgegeben werden mit Begrüßung und ihrem jeweiligen Rabatt

List<KundenEintrag> kunden = new List<KundenEintrag>();
string name;
bool istFirmenkunde, weiter = true;
decimal summe = 0;

while (weiter)
{
    name = UserInputUtils.ReadValidatedString("Bitte Kunden Namen eingeben: ", "Die Eingabe darf nicht leer sein.");
    istFirmenkunde = UserInputUtils.ReadConsoleKey("Drücken Sie Enter, wenn es sich um einen Firmenkunden handelt \n(andernfalls eine beliebige Taste drücken) ", ConsoleKey.Enter);
    summe = UserInputUtils.ReadValidatedDecimal("\nBitte ein Betrag eingeben: ", "Ungültige Eingabe. Versuchen Sie es erneut.");
    Kunde kunde = KundenService.ErstelleKunde(name, istFirmenkunde);
    kunden.Add(new KundenEintrag(kunde, summe));

    weiter = UserInputUtils.ReadConsoleKey("\nMöchten Sie noch eine Kunde erstellen? Drücken Sie Enter", ConsoleKey.Enter);
    Console.Clear();
}

KundenService.ZeigeKundenRabatte(kunden);
UserInputUtils.WaitUserKey("Zum Beenden eine beliebige Taste drücken");
