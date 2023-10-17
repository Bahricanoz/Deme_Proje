using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T :class
    {
        void TAdd(T p);
        void TDelete(T p);
        void TUpdate(T p);
        T GetById(int id);
        List<T> GetList();
    }
}
