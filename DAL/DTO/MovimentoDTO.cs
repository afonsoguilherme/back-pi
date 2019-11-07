using System;
using back_pi.DAL.Models;

namespace back_pi.DAL.DTO
{
    public class MovimentoDTO
    {
        public string IdMovimento { get; set; }
        public string IdVendedor { get; set; }
        public string TipoMovimento { get; set; }
        public bool StatusVenda { get; set; }
        public Horario HorarioMovimento { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}