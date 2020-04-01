using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebBodega.Models;

namespace WebBodega
{
    public class EditarClienteModel : PageModel
    {
        [BindProperty]
        public ClienteModel Cliente { get; set; }
        public void OnGet()
        {

        }
    }
}