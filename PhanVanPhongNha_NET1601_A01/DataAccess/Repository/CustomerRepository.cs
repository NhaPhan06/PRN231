using BusinessObjects.Entities;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly FUMiniHotelManagementContext _context;

    public CustomerRepository()
    {
        _context = new FUMiniHotelManagementContext();
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _context.Customers.Include(c => c.BookingReservations).ToListAsync();
    }

    public async Task<Customer> Get(int id)
    {
        return await _context.Customers.Include(c => c.BookingReservations).FirstOrDefaultAsync(c => c.CustomerId == id);
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public void Update(Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var customer = _context.Customers.Find(id);
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }
}