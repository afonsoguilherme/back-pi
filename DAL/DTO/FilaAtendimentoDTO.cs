using System.Collections.Generic;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class FilaAtendimentoDTO
    {
        public string IdVendedorEmAtendimento { get; set; }
        public Vendedor Vendedor { get; set;}
    }
}