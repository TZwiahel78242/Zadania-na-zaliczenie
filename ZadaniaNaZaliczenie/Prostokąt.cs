namespace ZadaniaNaZaliczenie;
using System;
using System.Collections.Generic;

public class Prostokąt
{
    private double bokA;
    private double bokB;

    public double BokA
    {
        get { return bokA; }
        set 
        {
            if (double.IsNaN(value) || value < 0)
            {
                throw new ArgumentException("Długość boku musi być skończoną nieujemną liczbą.");
            }
            bokA = value;
        }
    }

    public double BokB
    {
        get { return bokB; }
        set 
        {
            if (double.IsNaN (value) || value < 0)
            {
                throw new ArgumentException("Długość boku musi być skończoną nieujemną liczbą.");
            }
            bokB = value;
        }
    }

    private static Dictionary<char, decimal> wysokośćArkusza0 = new Dictionary<char, decimal>
    {
        ['A'] = 1189,
        ['B'] = 1414,
        ['C'] = 1297
    };

    public static Prostokąt ArkuszPapieru(string format)
    {
        if (string.IsNullOrEmpty(format) || format.Length < 2)
        {
            throw new ArgumentException("Nieprawidłowy format.");
        }

        char litera = format[0];
        if (!wysokośćArkusza0.ContainsKey(litera))
        {
            throw new ArgumentException("Nieprawidłowy format.");
        }

        byte indeks;
        if (!byte.TryParse(format.Substring(1), out indeks))
        {
            throw new ArgumentException("Nieprawidłowy format.");
        }

        decimal wysokość = wysokośćArkusza0[litera];
        double pierwiastekZDwóch = Math.Sqrt(2);
        double bokA = (double)wysokość / Math.Pow(pierwiastekZDwóch, indeks);
        double bokB = bokA / pierwiastekZDwóch;

        return new Prostokąt(bokA, bokB);
    }

    public Prostokąt(double bokA, double bokB)
    {
        BokA = bokA;
        BokB = bokB;
    }
}