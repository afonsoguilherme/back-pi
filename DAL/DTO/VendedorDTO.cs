using System.Collections.Generic;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class VendedorDTO
    {
        public string IdVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string CodigoVendedor { get; set; }
        public string ImagemVendedor { get; set; }
    }
}