using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_PBL3.Interface
{
    public interface IGeneral<T>
    {
        List<T> GetList();
        List<T> GetList(int key);
        void Add(T temp);
        void Delete(T temp);
        void Update(T before, T after);

        void Sync();

    }
}
