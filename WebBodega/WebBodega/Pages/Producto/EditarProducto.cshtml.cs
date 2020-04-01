using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebBodega.Models;

namespace WebBodega
{
    public class EditarProductoModel : PageModel
    {
        [BindProperty]
        public ProductoModel Producto { get; set; }
        public async Task OnGetAsync(int id)
        {
            int idProducto = id;
            var httpClient = new HttpClient();
            string jsonCategoria = await httpClient.GetStringAsync("https://localhost:44351/api/productos/consultarcategorias");
            ViewData["IdCategoria"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonCategoria);
            var json = await httpClient.GetStringAsync($"https://localhost:44351/api/productos/consultarproductoporid/{idProducto}");
            Producto = JsonConvert.DeserializeObject<ProductoModel>(json);
        }
    }
}