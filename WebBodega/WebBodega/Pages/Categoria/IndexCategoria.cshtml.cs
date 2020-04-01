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
    public class IndexCategoriaModel : PageModel
    {
        public List<CategoriaModel> Categorias = new List<CategoriaModel>();
        public async Task OnGetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:44351/api/Categorias");
            Categorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(json);
        }
    }
}