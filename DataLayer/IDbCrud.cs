using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDbCrud<T>
    {
        void Create(T entity);
        IEnumerable<T> Get();
        T Get(int id);
        void Update(T entity);
        void Delete(int id);
    }
}
