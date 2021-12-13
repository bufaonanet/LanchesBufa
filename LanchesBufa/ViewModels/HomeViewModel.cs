using LanchesBufa.Models;
using System.Collections.Generic;

namespace LanchesBufa.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPrefiridos { get; set; }
    }
}