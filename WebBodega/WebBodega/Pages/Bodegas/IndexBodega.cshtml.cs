using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebBodega.Models;

namespace WebBodega
{
    public class IndexBodegaModel : PageModel
    {
        public List<BodegaModel> Bodegas = new List<BodegaModel>();
        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44351/api/Bodegas");
            Bodegas = JsonConvert.DeserializeObject<List<BodegaModel>>(json);
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            int idBodega = id;
            var httpClient = new HttpClient();
            await httpClient.GetStringAsync($"https://localhost:44351/api/Bodegas/eliminarbodegas/{idBodega}");
            return RedirectToPage("IndexBodega");
        }
    }
}