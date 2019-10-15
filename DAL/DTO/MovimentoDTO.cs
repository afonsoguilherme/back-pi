using System;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class MovimentoDTO
    {
        public string IdMovimento { get; set; }
        public string IdVendedor { get; set; }
        public string TipoMovimento { get; set; }
        public bool StatusVenda { get; set; }
        public string JustificativaVenda { get; set; }
        public DateTime InicioMovimento { get; set; }
        public DateTime FinalMovimento { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}