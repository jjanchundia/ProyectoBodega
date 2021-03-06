﻿using System;
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
    public class IndexModel : PageModel
    {
        public List<ClienteModel> Clientes = new List<ClienteModel>();
        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44351/api/Clientes");
            Clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(json);
        }

        public async Task<ActionResult> OnGetDelete(int id)
        {
            int idCliente = id;
            var httpClient = new HttpClient();
            await httpClient.GetStringAsync($"https://localhost:44351/api/clientes/eliminarcliente/{idCliente}");
            return RedirectToPage("Index");
        }
    }
}