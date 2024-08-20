using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_dotNet.entity;

[Table("users")]
public class User
{
    [Column("user_id")]
    public long UserId { get; init; }
    
    [Column("name")]
    public string Name { get; init; }
    
    [Column("surname")]
    public string Surname { get; init; }
    
    [Column("patronymic")]
    public string Patronymic { get; init; }
    
    [Column("phone_number")]
    public int PhoneNumber { get; init; }
    
    [Column("address")]
    public string Address { get; init; }

    public User(long userId, string name, string surname, string patronymic, int phoneNumber, string address)
    {
        UserId = userId;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        Address = address;
    }
    
    public User(string name, string surname, string patronymic, int phoneNumber, string address)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public User()
    {
    }
    
    public override string ToString()
    {
        return $"UserId: {UserId}, Name: {Name}, Surname: {Surname}, Patronymic: {Patronymic}, PhoneNumber: {PhoneNumber}, Address: {Address}";
    }
}
