using System;

public class Macierz<T> : IEquatable<Macierz<T>>
{
    private T[,] tablica;

    public Macierz(int wiersze, int kolumny)
    {
        if (wiersze <= 0 || kolumny <= 0)
        {
            throw new ArgumentException("Wymiary macierzy muszą być większe od zera.");
        }

        tablica = new T[wiersze, kolumny];
    }

    public T this[int wiersz, int kolumna]
    {
        get => tablica[wiersz, kolumna];
        set => tablica[wiersz, kolumna] = value;
    }

    public int Wiersze => tablica.GetLength(0);
    public int Kolumny => tablica.GetLength(1);

    public static bool operator ==(Macierz<T> m1, Macierz<T> m2)
    {
        if (ReferenceEquals(m1, m2)) return true;
        if (ReferenceEquals(m1, null) || ReferenceEquals(m2, null)) return false;

        if (m1.Wiersze != m2.Wiersze || m1.Kolumny != m2.Kolumny)
        {
            return false;
        }

        for (int i = 0; i < m1.Wiersze; i++)
        {
            for (int j = 0; j < m1.Kolumny; j++)
            {
                if (!EqualityComparer<T>.Default.Equals(m1[i, j], m2[i, j]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(Macierz<T> m1, Macierz<T> m2)
    {
        return !(m1 == m2);
    }

    public bool Equals(Macierz<T> other)
    {
        return this == other;
    }

    public override bool Equals(object obj)
    {
        if (obj is Macierz<T> other)
        {
            return Equals(other);
        }
        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        for (int i = 0; i < Wiersze; i++)
        {
            for (int j = 0; j < Kolumny; j++)
            {
                hash = hash * 31 + (tablica[i, j]?.GetHashCode() ?? 0);
            }
        }
        return hash;
    }

    private static void EnsureComparable()
    {
        if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)) &&
            !typeof(IComparable).IsAssignableFrom(typeof(T)))
        {
            throw new InvalidOperationException($"Type {typeof(T)} must implement IComparable<T> or IComparable.");
        }
    }

    static Macierz()
    {
        EnsureComparable();
    }
}
