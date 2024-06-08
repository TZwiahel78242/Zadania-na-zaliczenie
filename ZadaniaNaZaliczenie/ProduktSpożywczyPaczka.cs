public class ProduktSpożywczyPaczka : ProduktSpożywczy
{
    private decimal waga;
    public decimal Waga
    {
        get => waga;
        set => waga = value >= 0 ? value : throw new ArgumentException("Waga nie może być ujemna");
    }
}