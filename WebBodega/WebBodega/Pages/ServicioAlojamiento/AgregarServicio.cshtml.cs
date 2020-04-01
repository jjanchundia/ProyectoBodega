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
        public List<ServicioModel> Servicios { get; set; }

        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var jsonBodega = await httpClient.GetStringAsync("https://localhost:44351/api/servicioalojamiento/consultarbodegas");
            ViewData["IdBodega"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonBodega);
            var jsonCliente = await httpClient.GetStringAsync("https://localhost:44351/api/servicioalojamiento/consultarclientes");
            ViewData["IdCliente"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonCliente);
        }

        public ActionResult OnPost(ServicioModel model)
        {
            Servicio = model;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44351/api/servicioalojamiento");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("ServicioAlojamiento", Servicio);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    postTask.Wait();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return RedirectToAction("IndexServicio");
        }
    }
}