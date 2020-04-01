using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebBodega.Models;
using System.Linq;

namespace WebBodega
{
    public class AgregarClienteModel : PageModel
    {
        [BindProperty]
        public ClienteModel Cliente { get; set; }
        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPostAsync()
        {
            var cliente = Cliente;

            try
            {
                bool consulta = await ConsultarCliente(cliente.Cedula);

                if (!consulta)
                {
                    throw new Exception();
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44351/api/Clientes");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("Clientes", cliente);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    postTask.Wait();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            return RedirectToPage("Index");
        }

        public async Task<bool> ConsultarCliente(string cedula)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost:44328/api/Clientes");
            var clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(json);

            if (clientes.Any(x => x.Cedula == cedula))
            {
                return false;
            }

            return true;
        }
    }
}