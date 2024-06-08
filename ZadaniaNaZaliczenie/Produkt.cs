using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Produkt : IElementKoszyka
{
    private string nazwa;
    private decimal cenaNetto;

    private static readonly Dictionary<string, decimal> KategoriaVATStawki = new Dictionary<string, decimal>
    {
        { "Podstawowa", 0.23m },
        { "Obniżona", 0.08m },
        { "Zero", 0.00m },
        { "Zwolnione", 0.00m }
    };

    private static readonly HashSet<string> Kraje = new HashSet<string>
    {
        "Polska", "Niemcy", "Francja", "Wielka Brytania"
    };

    public string Nazwa
    {
        get => nazwa;
        set => nazwa = value ?? throw new ArgumentNullException(nameof(value));
    }

    public decimal CenaNetto
    {
        get => cenaNetto;
        set => cenaNetto = value >= 0 ? value : throw new ArgumentException("Cena netto nie może być ujemna");
    }

    private string kategoriaVAT;
    public virtual string KategoriaVAT
    {
        get => kategoriaVAT;
        set
        {
            if (!KategoriaVATStawki.ContainsKey(value))
                throw new ArgumentException("Nieprawidłowa kategoria VAT");
            kategoriaVAT = value;
        }
    }

    public virtual decimal CenaBrutto => Math.Round(CenaNetto * (1 + KategoriaVATStawki[KategoriaVAT]), 2);

    private string krajPochodzenia;
    public string KrajPochodzenia
    {
        get => krajPochodzenia;
        set
        {
            if (!Kraje.Contains(value))
                throw new ArgumentException("Nieprawidłowy kraj pochodzenia");
            krajPochodzenia = value;
        }
    }
}