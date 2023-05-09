using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AjApp.Controllers
{
    [Route("ajfy/playlist")]
    public class PlayListController : Controller
    {
        public async Task<IActionResult> Index(string? playlistname)
        {
            if(playlistname != null)
            {

                var _pclient = new HttpClient();
                var content = new StringContent(playlistname);
try
                {
                    using var _presponse = await _pclient.PostAsync("https://localhost:7020/ajfy/createnewplaylist", content);
                    if (_presponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Created successfully");
                        return Redirect("https://spotify.com");
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:7020/ajfy/getallplaylists"),
        };

        try
        {
                using var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    dynamic body = (JArray)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                    ViewBag.PlaylistData = body;
                    Console.WriteLine(body);
                    return View();
                }
                else
                {
                    ViewBag.NoData = "No Playlist";
                    return View();
                }
        }catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }


            return View();
        }
    }
}
