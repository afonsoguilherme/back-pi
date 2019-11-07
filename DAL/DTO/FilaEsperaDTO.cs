using System.Collections.Generic;
using back_pi.DAL.Models;

namespace back_pi.DAL.DTO
{
    public class FilaEsperaDTO
    {
        public string IdVendedorEmEspera { get; set; }
        public Vendedor Vendedor { get; set;}
    }
}