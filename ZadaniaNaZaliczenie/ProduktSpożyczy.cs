public abstract class ProduktSpożywczy : Produkt
{
    private static readonly HashSet<string> SpożywczeKategoriaVATStawki = new HashSet<string>
    {
        "Obniżona", "Zero", "Podstawowa"
    };

    private decimal kalorie;
    public decimal Kalorie
    {
        get => kalorie;
        set => kalorie = value >= 0 ? value : throw new ArgumentException("Kalorie nie mogą być ujemne");
    }

    private HashSet<string> alergeny;
    private static readonly HashSet<string> PrzewidywaneAlergeny = new HashSet<string>
    {
        "Gluten", "Orzechy", "Mleko", "Jajka"
    };

    public HashSet<string> Alergeny
    {
        get => alergeny;
        set
        {
            if (!value.All(a => PrzewidywaneAlergeny.Contains(a)))
                throw new ArgumentException("Nieprawidłowy alergen");
            alergeny = value;
        }
    }

    public override string KategoriaVAT
    {
        set
        {
            if (!SpożywczeKategoriaVATStawki.Contains(value))
                throw new ArgumentException("Nieprawidłowa kategoria VAT dla produktu spożywczego");
            base.KategoriaVAT = value;
        }
    }
}