using Microsoft.AspNetCore.Mvc;
using WebUI.Interface;
using WebUI.Models;

namespace WebUI.Controllers;

public class CustomerController(ICustomerApi api) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> AddNewCustomer(CustomerModel customer)
    {
        var data = await api.AddCustomer(customer);

        return RedirectToAction("Index", "Home");
    }
}