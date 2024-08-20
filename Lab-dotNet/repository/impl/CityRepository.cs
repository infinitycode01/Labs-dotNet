using System.Data;
using Lab_dotNet.entity;
using Lab_dotNet.repository;
using Npgsql;

namespace Lab_dotNet.Repository.Impl;

public class CityRepository : IBaseRepository<City>
{
    private const string GetAllQuery = "SELECT * FROM cities";
    private const string GetByIdQuery = "SELECT * FROM cities WHERE city_id = @CityId";
    private const string SaveQuery = "INSERT INTO cities (name, phone_code) VALUES (@Name, @PhoneCode)";
    private const string DeleteByIdQuery = "DELETE FROM cities WHERE city_id = @CityId";

    private readonly string _connectionString;

    public CityRepository(string connectionString)
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

    public City GetById(long id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(GetByIdQuery, connection);
        command.Parameters.AddWithValue("@CityId", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new City(
                Convert.ToInt32(reader["city_id"]),
                reader["name"].ToString()!,
                Convert.ToInt32(reader["phone_code"])
            );
        }
        throw new Exception("City not found.");
    }

    public void Save(City entity)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(SaveQuery, connection);
        command.Parameters.AddWithValue("@Name", entity.Name);
        command.Parameters.AddWithValue("@PhoneCode", entity.PhoneCode);
        command.ExecuteNonQuery();
    }

    public void DeleteById(long id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(DeleteByIdQuery, connection);
        command.Parameters.AddWithValue("@CityId", id);
        command.ExecuteNonQuery();
    }
}
