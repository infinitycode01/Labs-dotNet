using System.Data;
using Lab_dotNet.entity;
using Npgsql;

namespace Lab_dotNet.repository.impl;

public class ConversationRepository : IBaseRepository<Conversation>
{
    private const string GetAllQuery = "SELECT * FROM conversations";
    private const string GetByIdQuery = "SELECT * FROM conversations WHERE conversation_id = @ConversationId";
    private const string SaveQuery = "INSERT INTO conversations (user_id, tariff_id, duration, date) VALUES (@UserId, @TariffId, @Duration, @Date)";
    private const string DeleteByIdQuery = "DELETE FROM conversations WHERE conversation_id = @ConversationId";
    private readonly string _connectionString;

    public ConversationRepository(string connectionString)
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

    public Conversation GetById(long id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(GetByIdQuery, connection);
        command.Parameters.AddWithValue("@ConversationId", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Conversation(
                Convert.ToInt64(reader["conversation_id"]),
                Convert.ToInt64(reader["user_id"]),
                Convert.ToInt64(reader["tariff_id"]),
                Convert.ToInt32(reader["duration"]),
                Convert.ToDateTime(reader["date"])
            );
        }
        throw new Exception("Conversation not found.");
    }

    public void Save(Conversation entity)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(SaveQuery, connection);
        command.Parameters.AddWithValue("@UserId", entity.UserId);
        command.Parameters.AddWithValue("@TariffId", entity.TariffId);
        command.Parameters.AddWithValue("@Duration", entity.Duration);
        command.Parameters.AddWithValue("@Date", entity.Date);
        command.ExecuteNonQuery();
    }

    public void DeleteById(long id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var command = new NpgsqlCommand(DeleteByIdQuery, connection);
        command.Parameters.AddWithValue("@ConversationId", id);
        command.ExecuteNonQuery();
    }
}
