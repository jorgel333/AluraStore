using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class ProdutoDAOEntity : IProdutoDAO, IDisposable
    {
        private readonly LojaContext context;

        public ProdutoDAOEntity()
        {
            context = new LojaContext();
        }
        public void Adicionar(Produto p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            context.Update(p);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IList<Produto> Produtos()
        {
            return context.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            context.Remove(p);
            context.SaveChanges();
        }
    }
}
