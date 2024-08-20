using System.Data;

namespace Lab_dotNet.repository;

public interface IBaseRepository<T> where T : class
{
    DataTable GetAll();
    T GetById(long id);
    void Save(T entity);
    void DeleteById(long id);
}