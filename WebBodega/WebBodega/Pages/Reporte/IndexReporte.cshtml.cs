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
    public class IndexReporteModel : PageModel
    {
        [BindProperty]
        public ServicioModel Servicio { get; set; }
        [BindProperty]
        public List<ProductoModel> Producto{ get; set; }
        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var jsonCliente = await httpClient.GetStringAsync("https://localhost:44351/api/clientes/consultarclientes");
            ViewData["IdClientes"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonCliente);
            int idCliente = 0;
            var json = await httpClient.GetStringAsync($"https://localhost:44351/api/servicioalojamiento/reporte/{idCliente}");
            Producto = JsonConvert.DeserializeObject<List<ProductoModel>>(json);
        }

        public async Task OnPostReporte()
        {
            var model = Servicio;
            int idCliente = model.IdCliente;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://localhost:44351/api/servicioalojamiento/reporte/{idCliente}");
            Producto = JsonConvert.DeserializeObject<List<ProductoModel>>(json);
            var jsonCliente = await httpClient.GetStringAsync("https://localhost:44351/api/clientes/consultarclientes");
            ViewData["IdClientes"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonCliente);
        }
    }
}