using LanchesBufa.Context;
using LanchesBufa.Models;
using System.Collections.Generic;

namespace LanchesBufa.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}