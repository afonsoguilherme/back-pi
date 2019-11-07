using System.Collections.Generic;
using back_pi.DAL.Models;

namespace back_pi.DAL.DTO
{
    public class VendaNaoSucedidaDTO
    {
        public string IdVendaNaoSucedida { get; set; }
        public string IdMovimento { get; set; }
        public string TipoProduto { get; set; }
        public string MarcaProduto { get; set; }
        public string CorProduto { get; set; }
        public string NumeroProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public Movimento Movimento { get; set; }
    }
}