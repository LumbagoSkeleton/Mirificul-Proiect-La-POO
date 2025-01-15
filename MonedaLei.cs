namespace Proiect_Poo;

internal class MonedaLei : InterfataCost
{
    public string MonedaStr(float valueInEuro)
    {
        return $"{valueInEuro*4,97} Lei";
    }
}