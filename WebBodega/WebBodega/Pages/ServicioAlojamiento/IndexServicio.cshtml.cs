using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WebBodega.Models;

namespace WebBodega
{
    public class IndexServicioModel : PageModel
    {
        public List<ServicioModel> Servicios = new List<ServicioModel>();
        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44351/api/ServicioAlojamiento");
            Servicios = JsonConvert.DeserializeObject<List<ServicioModel>>(json);
        }
    }
}