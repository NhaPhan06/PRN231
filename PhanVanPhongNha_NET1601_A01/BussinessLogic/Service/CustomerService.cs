using AutoMapper;
using BusinessObjects.DTOS.Request;
using BusinessObjects.Entities;
using BussinessLogic.IService;
using DataAccess.IRepository;

namespace BussinessLogic.Service;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }
    public Task<List<Customer>> GetAllCustomers()
    {
        return _customerRepository.GetAll();
    }

    public Task<Customer> GetCustomer(int id)
    {
        return _customerRepository.Get(id);
    }

    public Task<Customer> UpdateCustomer(Customer Customer)
    {
        return _customerRepository.Update(Customer);
    }

    public Task<Customer> CreateCustomer(CreateCustomerRequest customerRequest)
    {
        var customer = _mapper.Map<Customer>(customerRequest);
        return _customerRepository.Add(customer);
    }

    public void Delete(int id)
    {
        _customerRepository.Delete(id);
    }
}