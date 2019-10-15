using System.Collections.Generic;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg.DAL.DTO
{
    public class VendaNaoSucedidaDTO
    {
        public string IdVendaNaoSucedida { get; set; }
        public string IdMovimento { get; set; }
        public string ModeloProduto { get; set; }
        public string CorProduto { get; set; }
        public string NumeroProduto { get; set; }
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public Movimento Movimento { get; set; }
    }
}