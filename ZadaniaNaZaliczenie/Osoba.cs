namespace ZadaniaNaZaliczenie;
using System;

public class Osoba
{
    private string imię;
    private string nazwisko;
    public DateTime? DataUrodzenia { get; set; }
    public DateTime? DataŚmierci { get; set; }

    public Osoba(string imięNazwisko)
    {
        ImięNazwisko = imięNazwisko;
    }

    public string Imię
    {
        get { return imię;}
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Imię nie może być puste.");
            }
            imię = value;
        }
    }

    public string Nazwisko 
    {
        get { return nazwisko;}
        set { nazwisko = value; }
    }

    public string ImięNazwisko
    {
        get { return $"{imię} {nazwisko}".Trim(); }
        set 
        {
            string[] parts = value.Split(' ');
            imię = parts[0];
            nazwisko = (parts.Length > 1) ? parts[1] : string.Empty;
        }
    }

    public TimeSpan? Wiek
    {
        get
        {
            if (DataUrodzenia.HasValue)
            {
                DateTime endDate = DataŚmierci ?? DateTime.Now;
                return endDate - DataUrodzenia.Value;
            }
            return null;
        }
    }
}