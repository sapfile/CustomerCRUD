using Microsoft.AspNetCore.Mvc;
using WebUI.Interface;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController(ICustomerApi api) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var customers = await api.GetCustomers();

            return View(customers);
        }

        public async Task<IActionResult> AddNewCustomer()
        {
            return View();
        }

        public async Task<IActionResult> CreateCustomer(CustomerModel customer)
        {
            var res = await api.AddCustomer(customer);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> EditCustomer(int id)
        {
            var customer = await api.GetCustomer(id);

            return View(customer);
        }

        public async Task<IActionResult> UpdateCustomer(CustomerModel customer)
        {
            var res = await api.UpdateCustomer(customer.Id, customer);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RemoveCustomer(int id)
        {
            var customer = await api.GetCustomer(id);

            return View(customer);
        }

        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var res = await api.DeleteCustomer(id);

            return RedirectToAction("Index", "Home");
        }
    }
}
