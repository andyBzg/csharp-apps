
// Vererbung bedeutet Eine Klasse (Kindklasse) erbt einer anderen Klasse (Elternklasse) und
// übernimmt deren Eigenschaften und Methoden. -> Vorteil ist wir sparen Code und wir erleichten
// die Wartung

/*
// Aufbau
class Eltern
{
    // Basisklassen
}

class Kind : Eltern // WICHTIG: Jede Klasse kann jeweils nur von einer anderen Klasse erben.
{
    // Kindklasse, erbt von Eltern
}
*/

Hund dogmeat = new Hund("Dogmeat");
dogmeat.Bewegen();
dogmeat.Bellen();
dogmeat.Gerausch();

Katze msKitty = new Katze();
msKitty.Gerausch(); // Weil wir überschrieben haben wird die Methode der Kindklasse genutzt

Tier mensch1 = new Mensch();
mensch1.Bewegen();

Mensch mensch2 = new Mensch();
mensch2.Bewegen();

Schiff schiff = new Schiff();
Kreuzer kreuzer = new Kreuzer("USS Enterprise");
Console.WriteLine(kreuzer.Name);

Kreuzer kreuzer1 = new Kreuzer("Anna");
Console.WriteLine(kreuzer1.Name);

Flugzeugtraeger flugzeugtraeger = new Flugzeugtraeger("Santa Maria");

Console.WriteLine(flugzeugtraeger.Name);

flugzeugtraeger.ZeigeName("1234");

class Tier
{
    public Tier() // Der Konstruktor der Elternklasse wird priorisiert insbesondere
    {             // wenn ein parameter übergeben wird    
        Console.WriteLine("Das ist der Tier-Konstruktor");
    }

    public void Bewegen()
    {
        Console.WriteLine("Das Tier bewegt sich"); // Kindklassen können diese Methode nutzen
    }

    public virtual void Gerausch() // Mit virtual ermöglichen wir das Überschreiben der Methode
    {
        Console.WriteLine("Das Tier macht ein Geräusch");
    }
}

class Hund : Tier
{
    public Hund(string name) // Wenn im Eltern-Konstruktor ein Parameter gesetzt wurde, muss dieser mit
    {                        // base(bezeichner) übergeben werden, also public Hund (string name) : base (name)    
        Console.WriteLine("Das ist der Hund-Konstruktor " + name);
    }

    public void Bellen()
    {
        Console.WriteLine("Wau wau");
    }

    public override void Gerausch()
    {
        Console.WriteLine("WAU WAU WAU");
    }
}


// Polymorphe anwendung mit überschreiben von Methoden

// mit override
class Katze : Tier
{
    public override void Gerausch() // Mit override überschreiben wir die Eltern Methode
    {
        Console.WriteLine("Miau");
    }
}

// mit new
class Mensch : Tier
{
    public new void Bewegen() // Bei new wird die Elternmethode nicht überschrieben wird, sondern verschteckt wird
    {
        Console.WriteLine("Der Mensch läuft");
    }
}


// Polymorphe Umgang mit Propertys

class Schiff
{
    public virtual string Name { get; set; }
}

class Kreuzer : Schiff
{
    public override string Name
    {
        get => base.Name;
        set
        {
            if (value.Length < 5)
            {
                Console.WriteLine("Kreuzschiffe müssen eine Namenlänge von Mindestens 5 Zeichen haben");
                base.Name = "Platzhalter";
            }
            else
                base.Name = value;
        }
    }

    public Kreuzer(string name)
    {
        Name = name;
    }
}

class Flugzeugtraeger : Schiff
{
    private string _name;

    public override string Name
    {
        get
        {
            Console.WriteLine("Der Name von Millitärschiffen sind geheim");
            return "";
        }
        set
        {
            _name = value;
        }
    }

    public Flugzeugtraeger(string name)
    {
        _name = name;
        Console.WriteLine("Flugzeugräger mit Name " + Name + " wurde erstellt");
    }

    public void ZeigeName(string password)
    {
        if (password == "1234")
            Console.WriteLine(_name);
    }
}
