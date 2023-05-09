using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace AjApp.Controllers
{
    public class AjMusicController : Controller
    {
        [HttpGet]
        [Route("ajfy")]
        public async Task<IActionResult> Ajfy(string? query)
        {
            if (query != null)
            {
                var _sclient = new HttpClient();
                var _srequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://localhost:7020/ajfy/searchsong?query={query}")
                };

                try
                {
                    using var response = await _sclient.SendAsync(_srequest);
                    if (response.IsSuccessStatusCode)
                    {
                        var body = (JArray)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                        Console.WriteLine($"The body is {body}");
                        ViewBag.SearchedSong = body;
                        Console.WriteLine(body);
                        return View();
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Exception = e.Message;
                    return View();
                }
            }
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://localhost:7020/ajfy/getalltracks")
                };

            try
            {
                using var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    dynamic body = (JArray)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                    ViewBag.SearchedData = body;
                    return View();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ViewBag.ApiDown = "API is Down! Sorry For the Inconvinence. Please try after sometime! Thank you for supporting Ajfy";
            return View();
        }
    }
}
