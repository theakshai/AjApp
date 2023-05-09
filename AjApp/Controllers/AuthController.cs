using AjApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AjApp.Controllers
{
    public class AuthController : Controller
    {
        [Route("signup")]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


    }
}
