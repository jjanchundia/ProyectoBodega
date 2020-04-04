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
            var jsonBodega = await httpClient.GetStringAsync("https://localhost:44351/api/bodegas/consultarbodegas");
            ViewData["IdBodegas"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonBodega);
            var json = await httpClient.GetStringAsync($"https://localhost:44351/api/categorias/consultarcategoriaporid/{idCategoria}");
            Categoria = JsonConvert.DeserializeObject<CategoriaModel>(json);
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var model = Categoria;

            if (!ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var jsonBodega = await httpClient.GetStringAsync("https://localhost:44351/api/bodegas/consultarbodegas");
                ViewData["IdBodegas"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonBodega);
                return Page();
            }

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