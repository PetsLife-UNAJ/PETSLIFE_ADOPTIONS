using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsLife_Adoptions.Domain.Entities;

namespace AccessData.Commad.Repository
{
    public interface IGenericRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity);
        public void Delete(int _id);

    }
}
