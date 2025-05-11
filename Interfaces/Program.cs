// Ein Interface ist ein Vertrag der festlegt, welche Methoden, Eigenschaften, Indexer und Events eine
// Klasse haben muss, wenn sie dieses Interface implementiert, man spricht auch von Schnittstellen.

// Aufbau eines Interfaces

// Ein Interface nutzt ausschließlich Signaturen bedeutet sämliche elemente haben naormalerweise keine Implementierung
// In Interfaces sind Felder nicht vorhanden
// Eigenschaften sind jedoch erlaubt

/*public interface IBeweglich
{
    void Bewege(float x, float y); // Methoden können deklariert werden (aber nicht implementiert)
    float Geschwindigkeit { get; set; } // Das gleiche gilt für Eigenschaften

    // Felder gibt es keine
}

// Beispiel:

public interface ISchwimmen
{
    void Schwimmen();
}

public interface IFahrbar
{
    void Fahren();
}

class AmphibienFahrzeug : ISchwimmen, IFahrbar
{
    public void Schwimmen()
    {
        throw new NotImplementedException();
    }

    public void Fahren()
    {
        throw new NotImplementedException();
    }
}*/


// Neuerungen ab C# 8.0
//Console.WriteLine(station.TemperaturCelsius);


WetterStation station = new WetterStation(22.3);
Console.WriteLine(station.TemperaturCelsius);
Console.WriteLine(station.TemperaturFahrenheit());

public interface ITemperatur
{
    double TemperaturCelsius { get; set; }
    double TemperaturFahrenheit // muss/soll nicht mehr in der implementierten Klasse überschrieben werden
    {
        get => TemperaturCelsius * 9 / 5 + 32;
        set => TemperaturCelsius = (value - 32) * 5 / 9;
    }
}

class WetterStation : ITemperatur
{


    private double _temperaturCelsius;

    public double TemperaturCelsius
    {
        get => _temperaturCelsius;
        set => _temperaturCelsius = value;
    }

    public WetterStation(double temperaturCelsius)
    {
        TemperaturCelsius = temperaturCelsius;
    }

    //public double TemperaturFahrenheit { get; set; }

    // aber genau die implementierung von Logik basierten Interfaces würde die interessant machen zb. ein Klasse Auto hat
    // Interface Bauteile wie Motor der etwas kann, Turboloader der etwas kann usw...
    // In C# 8 wurden default Interface implementation eingeführt aber sie sind auf halben weg stehen geblieben
    // Microsoft macht das nicht aus Sicherheits und Klarheitsgründen denn Interfaces sollen keine Konflikte verursachen
    // denn wenn mehrere Interfaces gleichnamige Props oder Methoden mit default Logik haben könnte es eben zu Konflikten führen
    // Vielleicht gibt es für C# 13 ausblicke über Mixins "traits like behavior" oder Interface Compositions
    // Das Thema composable logik components ist erkannt aber wurde in C# nie vollständig ausgearbeitet 

    // How Break this Old Stuff

    private double _temperaturFahrenheit => ((ITemperatur)this).TemperaturFahrenheit;

    public double TemperaturFahrenheit()
    {
        return _temperaturFahrenheit;
    }
}
