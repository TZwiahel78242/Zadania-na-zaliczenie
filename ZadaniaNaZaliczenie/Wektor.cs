namespace ZadaniaNaZaliczenie;
using System;


public class Wektor
{
  private double[] współrzędne;

  public Wektor(byte wymiar)
  {
    współrzędne = new double[wymiar];
  }

  public Wektor(params double[] współrzędne)
  {
    this.współrzędne = (double[])współrzędne.Clone();
  }

  public double Długość
  {
    get
    {
      return Math.Sqrt(IloczynSkalarny(this, this));
    }
  }

  public byte Wymiar
  {
    get
    {
      return (byte)współrzędne.Length;
    }
  }

  public double this[byte indeks]
  {
    get
    {
      return współrzędne[indeks];
    }
    set
    {
      współrzędne[indeks] = value;
    }
  }

  public static double IloczynSkalarny(Wektor V, Wektor W)
  {
    if (V.Wymiar != W.Wymiar)
    {
      throw new ArgumentException("Wektory muszą mieć ten sam wymiar.");
    }
    return V.współrzędne.Zip(W.współrzędne, (v, w) => v * w).Sum();
  }

  public static Wektor Suma(params Wektor[] Wektory)
  {
    if (Wektory.Length == 0)
    {
      throw new ArgumentException("Lista wektorów nie może być pusta.");
    }

    byte wymiar = Wektory[0].Wymiar;
    if (Wektory.Any(w => w.Wymiar != wymiar))
    {
      throw new ArgumentException("Wszystkie wektory muszą mieć ten sam wymiar.");
    }

    double[] suma = new double[wymiar];
    foreach (var wektor in Wektory)
    {
      for (byte i = 0; i < wymiar; i++)
      {
        suma[i] += wektor[i];
      }
    }

    return new Wektor(suma);
  }

  public static Wektor operator +(Wektor V, Wektor W)
  {
    if (V.Wymiar != W.Wymiar)
    {
      throw new ArgumentException("Wektory muszą mieć ten sam wymiar.");
    }

    double[] wynik = new double[V.Wymiar];
    for (byte i = 0; i < V.Wymiar; i++)
    {
      wynik[i] = V[i] + W[i];
    }

    return new Wektor(wynik);
  }

  public static Wektor operator -(Wektor V, Wektor W)
  {
    if (V.Wymiar != W.Wymiar)
    {
      throw new ArgumentException("Wektory muszą mieć ten sam wymiar.");
    }

    double[] wynik = new double[V.Wymiar];
    for (byte i = 0; i < V.Wymiar; i++)
    {
      wynik[i] = V[i] - W[i];
    }

    return new Wektor(wynik);
  }

  public static Wektor operator *(Wektor V, double skalar)
  {
    double[] wynik = new double[V.Wymiar];
    for (byte i = 0; i < V.Wymiar; i++)
    {
      wynik[i] = V[i] * skalar;
    }

    return new Wektor(wynik);
  }

  public static Wektor operator *(double skalar, Wektor V)
  {
    return V * skalar;
  }

  public static Wektor operator /(Wektor V, double skalar)
  {
    if (skalar == 0)
    {
      throw new DivideByZeroException("Skalar nie może być równy zero.");
    }

    double[] wynik = new double[V.Wymiar];
    for (byte i = 0; i < V.Wymiar; i++)
    {
      wynik[i] = V[i] / skalar;
    }

    return new Wektor(wynik);
  }

  public override string ToString()
  {
    return $"[{string.Join(", ", współrzędne)}]";
  }
}