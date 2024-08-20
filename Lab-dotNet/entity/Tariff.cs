namespace Lab_dotNet.entity;

public class Tariff
{
    public long TariffId { get; init; }
    public int Price { get; init; }
    public int Duration { get; init; }
    public long CityId { get; init; }
    
    public Tariff(long tariffId, int price, int duration, long cityId)
    {
        TariffId = tariffId;
        Price = price;
        Duration = duration;
        CityId = cityId;
    }

    public Tariff()
    {
    }
    
    public override string ToString()
    {
        return $"TariffId: {TariffId}, Price: {Price}, Duration: {Duration}, CityId: {CityId}";
    }
}