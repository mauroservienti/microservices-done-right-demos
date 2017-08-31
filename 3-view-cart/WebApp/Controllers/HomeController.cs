using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var url = $"http://localhost:20295/api/available/products";
            var client = new HttpClient();
            var response = await client.GetAsync(url).ConfigureAwait(false);
            var responseString = await response.Content.ReadAsStringAsync();
            var availableProducts = JsonConvert.DeserializeObject<int[]>(responseString);

            return View(availableProducts);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
