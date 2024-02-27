

using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.BusinessObjects;

namespace DataAccess.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly FUMiniHotelManagementContext _context;

    public CustomerRepository()
    {
        _context = new FUMiniHotelManagementContext();
    }

    public async Task<List<Customer>> GetAll()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> CheckLogin(string email, string password)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.EmailAddress == email && c.Password == password);
        if (customer == null)
        {
            return null;
        }
        return customer;
    }

    public async Task<Customer> Get(int id)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
    }

    public async Task<Customer> Add(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return await _context.Customers.FirstOrDefaultAsync(c => c.EmailAddress == customer.EmailAddress);
    }

    public async Task<Customer> Update(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
        return await _context.Customers.FirstOrDefaultAsync(c => c.EmailAddress == customer.EmailAddress);
    }

    public void Delete(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer.CustomerStatus == 0)
        {
            customer.CustomerStatus = 1;
        }
        else
        {
            customer.CustomerStatus = 0;
        }
        _context.Customers.Update(customer);
        _context.SaveChanges();
    }
}