namespace ZadaniaNaZaliczenie;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Zadanie 1:");
        Osoba osoba1 = new("Jan Kowalski");
        Console.WriteLine($"Imię: {osoba1.Imię}");
        Console.WriteLine($"Nazwisko: {osoba1.Nazwisko}");
        Console.WriteLine($"Imię i Nazwisko: {osoba1.ImięNazwisko}");
        osoba1.DataUrodzenia = new DateTime(1989, 1, 25);
        int age = (int)(osoba1.Wiek.Value.TotalDays / 365.25);
        Console.WriteLine($"Wiek: {age}\n");

        Console.WriteLine("Zadanie 2:");
        Prostokąt p1 = new(7, 12);
        double bokA = Prostokąt.ArkuszPapieru("A4").BokA;
        Console.WriteLine($"Bok A arkusza 'A4': {bokA.ToString("F")}");
        double bokB = Prostokąt.ArkuszPapieru("A4").BokB;
        Console.WriteLine($"Bok B arkusza 'A4': {bokB.ToString("F")}\n");

        Console.WriteLine("Zadanie 3:");
        Wektor w1 = new(3.0, 11.0, 4.0, 5.0, 2.0);
        Wektor w2 = new(9.0, 1.0, 8.0, 2.0, 7.0);
        Console.WriteLine("Wymiar w1: " + w1.Wymiar);
        Console.WriteLine("Wymiar w2: " + w2.Wymiar);
        double iloczyn = Wektor.IloczynSkalarny(w1, w2);
        Wektor suma = w1 + w2;
        Console.WriteLine($"Iloczyn skalarny wektorów wynosi: {iloczyn}");
        Console.WriteLine($"Wektor z dodawania wektorów w1 i w2 to: {suma}");
        Console.WriteLine($"Długość wektora w1 to: {w1.Długość.ToString("F")}"); 
        Console.WriteLine($"Długość wektora w2 to: {w2.Długość.ToString("F")}\n"); 

        Console.WriteLine("Zadanie 4:");
        ProduktSpożywczyNaWagę jabłka = new ProduktSpożywczyNaWagę
        {
          Nazwa = "Jabłka",
          CenaNetto = 3.50m,
          KategoriaVAT = "Obniżona",
          KrajPochodzenia = "Polska",
          Kalorie = 52m,
          Alergeny = new HashSet<string>{}
        };

        ProduktSpożywczyPaczka chipsy = new ProduktSpożywczyPaczka
        {
          Nazwa = "Chipsy",
          CenaNetto = 5.00m,
          KategoriaVAT = "Podstawowa",
          KrajPochodzenia = "Niemcy",
          Kalorie = 536m,
          Alergeny = new HashSet<string> {"Gluten"},
          Waga = 150m
        };

        ProduktSpożywczyNapój cola = new ProduktSpożywczyNapój
        {
          Nazwa = "Cola",
          CenaNetto = 4.00m,
          KategoriaVAT = "Podstawowa",
          KrajPochodzenia = "Francja",
          Kalorie = 42m,
          Alergeny = new HashSet<string>{},
          Waga = 500m,
          Objętość = 500
        };

        Console.WriteLine($"Produkt: {jabłka.Nazwa}, Cena Netto: {jabłka.CenaNetto}, Cena Brutto: {jabłka.CenaBrutto}, Kalorie: {jabłka.Kalorie}, Kraj: {jabłka.KrajPochodzenia}");
        Console.WriteLine($"Produkt: {chipsy.Nazwa}, Cena Netto: {chipsy.CenaNetto}, Cena Brutto: {chipsy.CenaBrutto}, Kalorie: {chipsy.Kalorie}, Kraj: {chipsy.KrajPochodzenia}, Waga: {chipsy.Waga}");
        Console.WriteLine($"Produkt: {cola.Nazwa}, Cena Netto: {cola.CenaNetto}, Cena Brutto: {cola.CenaBrutto}, Kalorie: {cola.Kalorie}, Kraj: {cola.KrajPochodzenia}, Waga: {cola.Waga}, Objętość: {cola.Objętość}");

        Wielopak wielopakChipsy = new Wielopak(chipsy, 3);
        Console.WriteLine($"Wielopak: {wielopakChipsy.Produkt.Nazwa}, Ilość: {wielopakChipsy.Ilość}, Cena Netto: {wielopakChipsy.CenaNetto}, Cena Brutto: {wielopakChipsy.CenaBrutto}");

        List<IElementKoszyka> koszyk = new List<IElementKoszyka> { jabłka, chipsy, cola, wielopakChipsy };
        Console.WriteLine("Zawartość koszyka:");
        foreach (var produkt in koszyk)
        {
            Console.WriteLine($"- {produkt.Nazwa}, Cena Brutto: {produkt.CenaBrutto}");
        }

        Console.WriteLine("\nZadanie 5:");
        Macierz<int> macierz1 = new Macierz<int>(2, 2);
        Macierz<int> macierz2 = new Macierz<int>(2, 2);

        macierz1[0, 0] = 1;
        macierz1[0, 1] = 2;
        macierz1[1, 0] = 3;
        macierz1[1, 1] = 4;

        macierz2[0, 0] = 1;
        macierz2[0, 1] = 2;
        macierz2[1, 0] = 3;
        macierz2[1, 1] = 4;

        Console.WriteLine($"macierz1 == macierz2: {macierz1 == macierz2}");
        Console.WriteLine($"macierz1.Equals(macierz2): {macierz1.Equals(macierz2)}");

        macierz2[1, 1] = 5;

        Console.WriteLine("Po zmianie elementu macierzy2:");
        Console.WriteLine($"macierz1 == macierz2: {macierz1 == macierz2}");
        Console.WriteLine($"macierz1.Equals(macierz2): {macierz1.Equals(macierz2)}");
    }
}