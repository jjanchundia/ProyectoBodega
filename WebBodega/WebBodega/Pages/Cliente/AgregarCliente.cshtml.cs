using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBodega.Models;

namespace WebBodega
{
    public class AgregarClienteModel : PageModel
    {
        [BindProperty]
        public ClienteModel Cliente { get; set; }
        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            var cliente = Cliente;

            try
            {
                //bool consulta = await ConsultarCliente(model.Cedula);

                //if (!consulta)
                //{
                //    throw new Exception();
                //}

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
    }
}