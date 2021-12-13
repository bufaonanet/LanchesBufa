using LanchesBufa.Repositories;
using LanchesBufa.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesBufa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPrefiridos = _lancheRepository.LanchesPreferidos
            };

            return View(homeViewModel);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}