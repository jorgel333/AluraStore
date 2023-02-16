using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicial { get; internal set; }
        public DateTime DataFinal { get; internal set; }
        public ICollection<PromocaoProduto> Produtos { get; internal set; }

        public Promocao()
        {
            Produtos = new List<PromocaoProduto>();
        }
        public void IncluirProduto(Produto produto)
        {
            Produtos.Add(new PromocaoProduto() { Produto = produto});
        }
    }
}
