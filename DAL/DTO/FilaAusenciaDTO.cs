using System.Collections.Generic;
using back_pi.DAL.Models;

namespace back_pi.DAL.DTO
{
    public class FilaAusenciaDTO
    {
        public string IdVendedorEmAusencia { get; set; }
        public Vendedor Vendedor { get; set;}
    }
}