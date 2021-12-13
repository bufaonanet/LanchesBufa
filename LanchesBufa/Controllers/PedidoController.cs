using LanchesBufa.Models;
using LanchesBufa.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LanchesBufa.Controllers

{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu Carrinho está vazio");
            }

            if (!ModelState.IsValid)
            {
                return View("~/Views/Erro/Erro.cshtml");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Pedido pedido)
        {
            decimal precoTotalPedido = 0.0m;
            int totalItensPedido = 0;

            List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = items;

            //verifica se existem itens de pedidos
            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio, que tal incluir um lanche...");
            }

            //calcula o total do pedido
            foreach (var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
            }

            //atribui o total de itens do pedido
            pedido.TotalItensPedido = totalItensPedido;

            //atribui o total do pedido ao pedido
            pedido.PedidoTotal = precoTotalPedido;

            if (ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);

                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :) ";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                _carrinhoCompra.LimparCarrinho();
                return RedirectToAction("CheckoutCompleto");
                //return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }
            return View(pedido);
        }

        public IActionResult CheckoutCompleto()
        {
            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :) ";
            return View();
        }
    }
}