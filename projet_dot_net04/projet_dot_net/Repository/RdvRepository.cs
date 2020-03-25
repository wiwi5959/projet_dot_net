using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projet_dot_net.Repository
{
    public class RdvRepository
    {
        public IQueryable<T> Filter(T model);
        public IQueryable<T> FindAll();
        public T FindByID(int id);
        public IQueryable<T> Remove(int id);
        public T Update(T model);
        public T Save(T model);
    }
}
