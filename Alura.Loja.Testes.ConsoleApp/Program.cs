using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            //using (var context = new LojaContext())
            //{
            //    var promocao = new Promocao();
            //    promocao.Descricao = "Queima Total Janeiro 2017";
            //    promocao.DataInicial = new DateTime(2017, 1, 1);
            //    promocao.DataFinal = new DateTime(2017, 1, 31);

            //    var produtos = context.Produtos.Where(p => p.Categoria == "Bebidas").ToList();
            //    foreach (var item in produtos)
            //    {
            //        promocao.IncluirProduto(item);
            //    }

            //    context.Promocoes.Add(promocao);
            //    context.SaveChanges();
            //}

            using(var context2 = new LojaContext())
            {
                var promocao = context2
                    .Promocoes
                    .Include(p => p.Produtos)
                    .ThenInclude(p => p.Produto)
                    .FirstOrDefault();
                Console.WriteLine("Mostrando os produtos da promoção");
                foreach(var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }


        private static void UmPraUm()
        {
            var fulano = new Client();
            fulano.Nome = "Fulano";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua das viúvas",
                Complemeto = "Sobrado",
                Bairro = "Centro",
                Cidade = "Jautinha"
            };

            using (var context = new LojaContext())
            {
                context.Clientes.Add(fulano);
                context.SaveChanges();
            }
        }

        private static void MuitosParaMuitos()
        {
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicial = DateTime.Now;
            promocaoDePascoa.DataFinal = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluirProduto(p1);
            promocaoDePascoa.IncluirProduto(p2);
            promocaoDePascoa.IncluirProduto(p3);



            var paoFrances = new Produto();

            paoFrances.Nome = "Pão Francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();

            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var context = new LojaContext())
            {
                //context.Promocoes.Add(promocaoDePascoa);
                var promocao = context.Promocoes.Find(1);
                context.Promocoes.Remove(promocao);
                context.SaveChanges();
            }
        }
    }
}

