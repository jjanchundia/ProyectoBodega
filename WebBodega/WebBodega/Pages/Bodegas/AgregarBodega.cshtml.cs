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
    public class AgregarBodegaModel : PageModel
    {
        [BindProperty]
        public BodegaModel Bodega { get; set; }
        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            var bodega = Bodega;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44351/api/Bodegas");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync("Bodegas", bodega);
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