using AjApp.Models;
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

        [HttpPost]
        public async Task<IActionResult> NewUser([Bind("Email, Password")]Auth auth, [Bind("Name,DOB,Country")]User user)
        {

            var newUser = new
            {
                name = user.Name,
                email = auth.Email,
                password = auth.Password,
                dob = user.DOB,
                country = user.Country,
            };

            var data = JObject.Parse(JsonConvert.SerializeObject(newUser));
            Console.WriteLine(data);
            var client = new HttpClient();
            try
            {
                using var response = await client.PostAsJsonAsync("https://localhost:7020/ajfy/user/addnewuser",newUser);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Created Successfully");
                    return Redirect("https://spotify.com");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Redirect("https://spotify.com");

        }

    }
}
