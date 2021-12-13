using LanchesBufa.Context;
using LanchesBufa.Models;
using System;
using System.Collections.Generic;

namespace LanchesBufa.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext, CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }
        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            //pedido.PedidoEntregueEm = DateTime.Now;

            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Lanche.Preco
                };
                _appDbContext.PedidoDetalhes.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }

        public Pedido GetPedidoById(int pedidoId)
        {
            throw new System.NotImplementedException();
        }

        public List<Pedido> GetPedidos()
        {
            throw new System.NotImplementedException();
        }
    }
}