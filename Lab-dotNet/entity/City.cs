namespace Lab_dotNet.entity;

public class City
{
    public long CityId { get; init; }
    public string Name { get; init; }
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