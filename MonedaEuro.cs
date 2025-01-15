namespace Proiect_Poo;

internal class MonedaEuro : InterfataCost
{
    public string MonedaStr(float valueInEuro)
    {
        return $"{valueInEuro} \u20ac";
    }
}