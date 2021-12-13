using LanchesBufa.Models;
using System.Collections.Generic;

namespace LanchesBufa.Repositories
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);

        Pedido GetPedidoById(int pedidoId);

        List<Pedido> GetPedidos();
    }
}