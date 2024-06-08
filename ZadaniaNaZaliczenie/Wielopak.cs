public class Wielopak : IElementKoszyka
{
    public Produkt Produkt { get; set; }
    public ushort Ilość { get; set; }

    private decimal cenaNetto;
    public decimal CenaNetto
    {
        get => cenaNetto;
        set => cenaNetto = value >= 0 ? value : throw new ArgumentException("Cena netto nie może być ujemna");
    }

    public decimal CenaBrutto => Math.Round(CenaNetto * (1 + KategoriaVATStawki[Produkt.KategoriaVAT]), 2);

    public string KategoriaVAT => Produkt.KategoriaVAT;
    public string KrajPochodzenia => Produkt.KrajPochodzenia;

    public Wielopak(Produkt produkt, ushort ilość)
    {
        Produkt = produkt ?? throw new ArgumentNullException(nameof(produkt));
        Ilość = ilość;
        CenaNetto = produkt.CenaNetto * ilość;
    }

    private static readonly Dictionary<string, decimal> KategoriaVATStawki = new Dictionary<string, decimal>
    {
        { "Podstawowa", 0.23m },
        { "Obniżona", 0.08m },
        { "Zero", 0.00m },
        { "Zwolnione", 0.00m }
    };

    string IElementKoszyka.Nazwa => $"{Produkt.Nazwa} (Wielopak x{Ilość})";
}