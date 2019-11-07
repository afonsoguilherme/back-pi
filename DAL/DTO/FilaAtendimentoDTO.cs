using System.Collections.Generic;
using back_pi.DAL.Models;

namespace back_pi.DAL.DTO
{
    public class FilaAtendimentoDTO
    {
        public string IdVendedorEmAtendimento { get; set; }
        public Vendedor Vendedor { get; set;}
    }
}