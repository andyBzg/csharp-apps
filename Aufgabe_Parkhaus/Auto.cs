namespace Aufgabe_Parkhaus
{
    internal class Auto
    {
        private string marke { get; set; }
        private string farbe { get; set; }
        private string kennzeichen { get; set; }

        public Auto(string marke, string farbe, string kennzeichen)
        {
            this.marke = marke;
            this.farbe = farbe;
            this.kennzeichen = kennzeichen;
        }

        public string GibAutoDetails()
        {
            return $"Marke: {marke.PadRight(marke.Length)} , Farbe: {farbe.PadRight(farbe.Length)} , Kennzeichen: {kennzeichen}";
        }
    }
}
