using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_dotNet.entity;

[Table("tariffs")]
public class Tariff
{
    [Column("tariff_id")]
    public long TariffId { get; init; }
    
    [Column("price")]
    public int Price { get; init; }
    
    [Column("duration")]
    public int Duration { get; init; }
    
    [Column("city_id")]
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