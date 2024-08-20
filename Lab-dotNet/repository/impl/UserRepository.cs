using System.Data;
using Lab_dotNet.entity;
using Lab_dotNet.repository;
using Npgsql;

namespace Lab_dotNet.Repository.Impl;

public class UserRepository : IBaseRepository<User>
{
    private const string GetAllQuery = "SELECT * FROM users";
    private const string GetByIdQuery = "SELECT * FROM users WHERE user_id = @UserId";
    private const string SaveQuery = "INSERT INTO users (name, surname, patronymic, phone_number, address) VALUES (@Name, @Surname, @Patronymic, @PhoneNumber, @Address)";
    private const string DeleteByIdQuery = "DELETE FROM users WHERE user_id = @UserId";

    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable GetAll()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(GetAllQuery, connection);
        using var adapter = new NpgsqlDataAdapter(command);
        var dataTable = new DataTable();
        adapter.Fill(dataTable);
        return dataTable;
    }

    public User GetById(long id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(GetByIdQuery, connection);
        command.Parameters.AddWithValue("@UserId", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new User(
                Convert.ToInt64(reader["user_id"]),
                reader["name"].ToString()!,
                reader["surname"].ToString()!,
                reader["patronymic"].ToString()!,
                Convert.ToInt32(reader["phone_number"]),
                reader["address"].ToString()!
            );
        }
        throw new Exception("User not found.");
    }

    public void Save(User entity)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(SaveQuery, connection);
        command.Parameters.AddWithValue("@Name", entity.Name);
        command.Parameters.AddWithValue("@Surname", entity.Surname);
        command.Parameters.AddWithValue("@Patronymic", entity.Patronymic);
        command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
        command.Parameters.AddWithValue("@Address", entity.Address);
        command.ExecuteNonQuery();
    }

    public void DeleteById(long id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(DeleteByIdQuery, connection);
        command.Parameters.AddWithValue("@UserId", id);
        command.ExecuteNonQuery();
    }
}
