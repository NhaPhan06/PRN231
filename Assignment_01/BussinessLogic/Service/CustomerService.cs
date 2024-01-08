using BussinessLogic.IService;
using DataAccess.IRepository;

namespace BussinessLogic.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
}