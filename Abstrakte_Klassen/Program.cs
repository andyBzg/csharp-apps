// Eine abstrakte Klasse ist eine Klasse, die nicht instanziert werden kann, also mit der man keine Objekte erstellen kann
// Sie dient als Basisklasse für andere Klassen. Sie kann sowohl implementierte Methoden als auch abstrakte beinhalten
// Sie kann zudem einen Konstruktor und Felder sowie Eigenschaften beherbegen

// Aufbau
/*
abstract class MeineAbstrakteKlasse
{
    public abstract void MeineAbstrakteMEthode();

    public void EineGanzNormaleMethode()
    {
        Console.WriteLine("Ich bin Normal ...");
    }
}

class Kindklasse : MeineAbstrakteKlasse
{
    public override void MeineAbstrakteMEthode()
    {
        Console.WriteLine("Ich wurde überschrieben");
    }
}
*/


//Tier tier = new Tier(); // Unmöglich zu instanzieren, da der Tier eine abstrakte Klasse ist

Hund hund = new Hund();
hund.MachGeraeusch();
hund.Schlafen();

Katze katze = new Katze();
katze.MachGeraeusch();
katze.Schlafen();

abstract class Tier
{
    public abstract void MachGeraeusch();

    public void Schlafen()
    {
        Console.WriteLine("Das Tier schläft");
    }
}

class Hund : Tier
{
    public override void MachGeraeusch()
    {
        Console.WriteLine("Wau");
    }
}

class Katze : Tier
{
    public override void MachGeraeusch()
    {
        Console.WriteLine("Miau");
    }
}
