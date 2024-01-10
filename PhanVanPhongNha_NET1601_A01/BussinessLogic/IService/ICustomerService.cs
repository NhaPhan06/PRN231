using BusinessObjects.DTOS.Request;
using BusinessObjects.Entities;

namespace BussinessLogic.IService;

public interface ICustomerService
{
    public Task<List<Customer>> GetAllCustomers();
    public Task<Customer> GetCustomer(int id);
    public Task<Customer> UpdateCustomer(Customer customer);
    public Task<Customer> CreateCustomer(CreateCustomerRequest customerRequest);
    public void Delete(int id);
}