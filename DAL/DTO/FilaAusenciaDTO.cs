using System.Collections.Generic;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class FilaAusenciaDTO
    {
        public string IdVendedorEmAusencia { get; set; }
        public Vendedor Vendedor { get; set;}
    }
}