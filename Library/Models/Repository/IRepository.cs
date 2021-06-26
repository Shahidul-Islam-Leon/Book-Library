using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Repository
{

    
    interface IRepository<T> where T:class
    {
        List<T> GetALLData();

        T Get(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}
