using BusinessObjects.Entities;

namespace DataAccess.IRepository;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAll();
    Task<Customer> Get(int id);
    void Add(Customer customer);
    void Update(Customer customer);
    void Delete(int id);
}