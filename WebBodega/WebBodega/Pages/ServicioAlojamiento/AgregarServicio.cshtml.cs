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
    public class AgregarServicioModel : PageModel
    {
        [BindProperty]
        public ServicioModel Servicio { get; set; }

        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var jsonBodega = await httpClient.GetStringAsync("https://localhost:44351/api/bodegas/consultarbodegas");
            ViewData["IdBodegas"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonBodega);
            var jsonCliente = await httpClient.GetStringAsync("https://localhost:44351/api/clientes/consultarclientes");
            ViewData["IdClientes"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonCliente);
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var producto = Servicio;

            if (!ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                var jsonBodega = await httpClient.GetStringAsync("https://localhost:44351/api/bodegas/consultarbodegas");
                ViewData["IdBodegas"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonBodega);
                string jsonCliente = await httpClient.GetStringAsync("https://localhost:44351/api/clientes/consultarclientes");
                ViewData["IdClientes"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonCliente);
                return Page();
            }

            try
            {
                var client = new HttpClient();

                //HTTP POST
                var postTask = await client.PostAsJsonAsync("https://localhost:44351/api/ServicioAlojamiento/", new
                {
                    NombreServicio = producto.NombreServicio,
                    IdCliente = producto.IdCliente.Value,
                    IdBodega = producto.IdBodega.Value,
                });
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToPage("IndexServicio");
        }
    }
}