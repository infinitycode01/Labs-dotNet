using Lab_dotNet.entity;
using Lab_dotNet.repository.impl;
using Lab_dotNet.Repository.Impl;

namespace Lab_dotNet;

class Program
{
    public static void Main(string[] args)
    {
        var connectionString = "Host=localhost;Port=5432;Database=phone_calls_db;Username=postgres;Password=postgres;";
        var userRepository = new UserRepository(connectionString);
        var cityRepository = new CityRepository(connectionString);
        var tariffRepository = new TariffRepository(connectionString);
        var conversationRepository = new ConversationRepository(connectionString);
        
        var users = userRepository.GetAll();
        
        var user = userRepository.GetById(5);
        var city = cityRepository.GetById(2);
        var tariff = tariffRepository.GetById(3);
        var conversation = conversationRepository.GetById(7);

        userRepository.Save(new User(
            "dima1",
            "badichel1",
            "viacheslavovich1",
            12345561,
            "My home address1"));
        
        var users1 = userRepository.GetAll();
        
        Console.WriteLine($"Retrieved {users.Rows.Count} users.");
        Console.WriteLine(user);
        Console.WriteLine(city);
        Console.WriteLine(tariff);
        Console.WriteLine(conversation);
        Console.WriteLine($"Retrieved {users1.Rows.Count} users1.");
    }
}