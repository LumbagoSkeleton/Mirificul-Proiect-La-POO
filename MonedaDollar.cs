namespace Proiect_Poo;

internal class MonedaDollar : InterfataCost
{
    public string MonedaStr(float valueInEuro)
    {
        return $"{valueInEuro*4,83} $";
    }
}