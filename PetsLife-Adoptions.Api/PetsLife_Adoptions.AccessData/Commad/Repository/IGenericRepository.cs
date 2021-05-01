using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Commad.Repository
{
    public interface IGenericRepository
    {
        public void Add<T>(T entity) where T : class;
    }
}
