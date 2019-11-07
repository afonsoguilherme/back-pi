using System.Collections.Generic;
using back_pi.DAL.Models;

namespace back_pi.DAL.DTO
{
    public class VendedorDTO
    {
        public string IdVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string CodigoVendedor { get; set; }
        public string ImagemVendedor { get; set; }
    }
}