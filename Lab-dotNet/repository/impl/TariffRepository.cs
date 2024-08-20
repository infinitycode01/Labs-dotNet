using System.Data;
using Lab_dotNet.entity;
using Lab_dotNet.repository;
using Npgsql;

namespace Lab_dotNet.Repository.Impl
{
    public class TariffRepository : IBaseRepository<Tariff>
    {
        private const string GetAllQuery = "SELECT * FROM tariffs";
        private const string GetByIdQuery = "SELECT * FROM tariffs WHERE tariff_id = @TariffId";
        private const string SaveQuery = "INSERT INTO tariffs (price, duration, city_id) VALUES (@Price, @Duration, @CityId)";
        private const string DeleteByIdQuery = "DELETE FROM tariffs WHERE tariff_id = @TariffId";

        private readonly string _connectionString;

        public TariffRepository(string connectionString)
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

        public Tariff GetById(long id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            using var command = new NpgsqlCommand(GetByIdQuery, connection);
            command.Parameters.AddWithValue("@TariffId", id);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Tariff(
                    Convert.ToInt64(reader["tariff_id"]),
                    Convert.ToInt32(reader["price"]),
                    Convert.ToInt32(reader["duration"]),
                    Convert.ToInt64(reader["city_id"])
                );
            }
            throw new Exception("Tariff not found.");
        }

        public void Save(Tariff entity)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            using var command = new NpgsqlCommand(SaveQuery, connection);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@Duration", entity.Duration);
            command.Parameters.AddWithValue("@CityId", entity.CityId);
            command.ExecuteNonQuery();
        }

        public void DeleteById(long id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            using var command = new NpgsqlCommand(DeleteByIdQuery, connection);
            command.Parameters.AddWithValue("@TariffId", id);
            command.ExecuteNonQuery();
        }
    }
}
