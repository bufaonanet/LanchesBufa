using LanchesBufa.Context;
using LanchesBufa.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LanchesBufa.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches
            .Include(p => p.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches
            .Where(p => p.IsLanchePreferido)
            .Include(p => p.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
        }
    }
}