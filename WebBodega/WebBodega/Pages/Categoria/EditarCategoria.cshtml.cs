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
    public class EditarCategoriaModel : PageModel
    {
        [BindProperty]
        public CategoriaModel Categoria { get; set; }
        public async Task OnGetAsync(int id)
        {
            int idCategoria = id;
            var httpClient = new HttpClient();
            var jsonBodega = await httpClient.GetStringAsync("https://localhost:44351/api/categorias/consultarbodegas");
            ViewData["IdBodega"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonBodega);
            var json = await httpClient.GetStringAsync($"https://localhost:44351/api/categorias/consultarcategoriaporid/{idCategoria}");
            Categoria = JsonConvert.DeserializeObject<CategoriaModel>(json);
        }

        public ActionResult OnPost()
        {
            var model = Categoria;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/categorias/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("actualizarcategoria", model);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                postTask.Wait();
            }

            return RedirectToPage("IndexCategoria");
        }
    }
}