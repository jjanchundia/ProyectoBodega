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
    public class IndexProductoModel : PageModel
    {
        public List<ProductoModel> Productos = new List<ProductoModel>();
        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44351/api/Productos");
            Productos = JsonConvert.DeserializeObject<List<ProductoModel>>(json);
        }

        public async Task<ActionResult> OnGetDelete(int id)
        {
            int idProducto = id;
            var httpClient = new HttpClient();
            await httpClient.GetStringAsync($"https://localhost:44351/api/Productos/eliminarproductos/{idProducto}");
            return RedirectToPage("IndexProducto");
        }
    }
}