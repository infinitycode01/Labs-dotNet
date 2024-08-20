using System.Diagnostics.CodeAnalysis;

namespace Lab_dotNet;

class Program
{
    public static void Main(string[] args)
    {
        var connectionString = "Host=localhost;Port=5432;Database=phone_calls_db;Username=postgres;Password=postgres";

        using var context = new PhoneCallsDbContext(connectionString);

        var users = context.Users.ToList();
        
        for (var i = 0; i < 50; i++)
        {
            Console.WriteLine(users[i]);
        }
        
        var cities = context.Cities.ToList();

        foreach (var city in cities)
        {
            Console.WriteLine(city);
        }

        var conversations = context.Conversations.ToList();

        foreach (var conversation in conversations)
        {
            Console.WriteLine(conversation);
        }

        var tariffs = context.Tariffs.ToList();

        foreach (var tariff in tariffs)
        {
            Console.WriteLine(tariff);
        }
    }
}