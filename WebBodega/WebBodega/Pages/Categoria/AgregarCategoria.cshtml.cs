using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebBodega.Models;

namespace WebBodega
{
    public class AgregarCategoriaModel : PageModel
    {
        [BindProperty]
        public CategoriaModel Categoria { get; set; }
        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var jsonBodega = await httpClient.GetStringAsync("https://localhost:44351/api/categorias/consultarbodegas");
            ViewData["IdBodegas"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonBodega);
        }

        public ActionResult OnPost()
        {
            var categoria = Categoria;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44351/api/Categorias");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("Categorias", categoria);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    postTask.Wait();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToPage("IndexCategoria");
        }
    }
}