using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebBodega.Models;

namespace WebBodega
{
    public class EditarBodegaModel : PageModel
    {
        [BindProperty]
        public BodegaModel Bodega { get; set; }

        public async Task OnGetAsync(int id)
        {
            int idBodega = id;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://localhost:44351/api/Bodegas/consultarbodegaporid/{idBodega}");
            Bodega = JsonConvert.DeserializeObject<BodegaModel>(json);
        }

        public ActionResult OnPost()
        {
            var model = Bodega;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/Bodegas/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("actualizarbodega", model);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                postTask.Wait();
            }

            return RedirectToPage("IndexBodega");
        }
    }
}