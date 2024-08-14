using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

 
public class HelloWorldController : Controller
{
    // 
    // GET: /HelloWorld/
     
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/
    public IActionResult HelloWorldPage()
    {
        return View();
    }
    public string Welcome2Town(string name, int ID = 2)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {ID}");
    }
}
