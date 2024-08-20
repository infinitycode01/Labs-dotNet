namespace Lab_dotNet.entity;

public class User
{
    public long UserId { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Patronymic { get; init; }
    public int PhoneNumber { get; init; }
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
