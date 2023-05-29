using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PF.Models;
using Newtonsoft.Json;

namespace PF.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(){
        const string url ="https://random.dog/woof.json";
        var client = new HttpClient();
        var response = client.GetAsync(url).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        Perros imagen_de_perros = JsonConvert.DeserializeObject<Perros>(content);
        return View( imagen_de_perros);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
