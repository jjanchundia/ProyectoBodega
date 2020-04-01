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
    public class AgregarCategoriaModel : PageModel
    {
        [BindProperty]
        public CategoriaModel Categoria { get; set; }
        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            var categoria = Categoria;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44351/api/Categorias");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("Categorias", categoria);
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