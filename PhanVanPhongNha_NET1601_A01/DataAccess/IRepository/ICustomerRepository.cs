

using ModelsLayer.BusinessObjects;

namespace DataAccess.IRepository;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAll();
    Task<Customer> CheckLogin(String email, String password);
    Task<Customer> Get(int id);
    Task<Customer> Add(Customer customer);
    Task<Customer> Update(Customer customer);
    void Delete(int id);
}