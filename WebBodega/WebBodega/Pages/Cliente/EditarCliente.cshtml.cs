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
    public class EditarClienteModel : PageModel
    {
        [BindProperty]
        public ClienteModel Cliente { get; set; }
        public async Task OnGetAsync(int id)
        {
            int idCliente = id;
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://localhost:44351/api/clientes/consultarclienteporid/{idCliente}");
            Cliente = JsonConvert.DeserializeObject<ClienteModel>(json);
        }

        public ActionResult OnPost()
        {
            var model = Cliente;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/api/clientes/");

                //HTTP POST
                var postTask = client.PostAsJsonAsync("actualizarcliente", model);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                postTask.Wait();
            }

            return RedirectToPage("Index");
        }
    }
}