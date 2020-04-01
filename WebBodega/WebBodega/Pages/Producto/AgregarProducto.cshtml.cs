using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBodega.Models;

namespace WebBodega
{
    public class AgregarProductoModel : PageModel
    {
        [BindProperty]
        public ProductoModel Producto { get; set; }
        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            var producto = Producto;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44351/api/Productos");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("Productos", producto);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    postTask.Wait();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Cliente");
        }
    }
}