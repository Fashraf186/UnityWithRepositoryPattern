using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityWithRepoPattern.Interface
{
    interface _IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Insert(T model);

        T FindbyID(int modelID);

        void Update(T model);

        void Remove(int modelID);

        void Save();




    }
}
