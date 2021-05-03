using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AccessData.Commad.Repository;
using PetsLife_Adoptions.AccessData;
using PetsLife_Adoptions.Domain.Entities;


namespace AccessData.Commad
{
    public class GenericRepository : IGenericRepository 
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context )
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete<T> (int _id) where T : class
        {
            _context.Remove(_context.Find<T>(_id));
            _context.SaveChanges();
        }

    }
}
