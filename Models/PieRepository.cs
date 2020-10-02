using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanPieShop.Models
{
    public class PieRepository: IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get 
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOftheWeek);
            }
        }
        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.PieID == pieId);
        }

    }
}
