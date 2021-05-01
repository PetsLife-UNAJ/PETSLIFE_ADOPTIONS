using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Commands;
using PetsLife_Adoptions.AccessData;

namespace AccessData.Commad
{
    public class GenericRepository : IGenericRepository
    {
        private readonly AdoptionDbContext _context;
        public GenericRepository(AdoptionDbContext context )
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }
}
