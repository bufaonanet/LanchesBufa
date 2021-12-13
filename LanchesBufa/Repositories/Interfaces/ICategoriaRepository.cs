using LanchesBufa.Models;
using System.Collections.Generic;

namespace LanchesBufa.Repositories
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}