using Refit;
using WebUI.Models;

namespace WebUI.Interface;

public interface ICustomerApi
{
    [Get("/GetCustomers")]
    Task<List<CustomerModel>> GetCustomers();

    [Get("/GetCustomersByName/{name}")]
    Task<List<CustomerModel>> GetCustomersByName(string name);

    [Get("/GetCustomer/{id}")]
    Task<CustomerModel> GetCustomer(int id);
    

    [Post("/AddCustomer")]
    Task<bool> AddCustomer([Body] CustomerModel customer);

    [Put("/UpdateCustomer/{id}")]
    Task<bool> UpdateCustomer(int id, [Body] CustomerModel customer);

    [Delete("/DeleteCustomer/{id}")]
    Task<bool> DeleteCustomer(int id);
}