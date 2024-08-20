using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_dotNet.entity;

[Table("cities")]
public class City
{
    [Column("city_id")]
    public long CityId { get; init; }
    
    [Column("name")]
    public string Name { get; init; }
    
    [Column("phone_code")]
    public int PhoneCode { get; init; }

    public City(long cityId, string name, int phoneCode)
    {
        CityId = cityId;
        Name = name;
        PhoneCode = phoneCode;
    }

    public City()
    {
    }
    
    public override string ToString()
    {
        return $"CityId: {CityId}, Name: {Name}, PhoneCode: {PhoneCode}";
    }
}