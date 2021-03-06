﻿using System;
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
    public class AgregarProductoModel : PageModel
    {
        [BindProperty]
        public ProductoModel Producto { get; set; }
        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            string jsonCategoria = await httpClient.GetStringAsync("https://localhost:44351/api/categorias/consultarcategorias");
            ViewData["IdCategorias"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonCategoria);
        }

        public async Task<ActionResult> OnPostAsync()
        {
            var producto = Producto;

            if (!ModelState.IsValid)
            {
                var httpClient = new HttpClient();
                string jsonCategoria = await httpClient.GetStringAsync("https://localhost:44351/api/categorias/consultarcategorias");
                ViewData["IdCategorias"] = JsonConvert.DeserializeObject<List<SelectListItem>>(jsonCategoria);
                return Page();
            }

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

            return RedirectToPage("IndexProducto");
        }
    }
}