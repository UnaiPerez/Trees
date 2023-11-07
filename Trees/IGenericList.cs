using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IGenericList<T>
    {
        string AsString();

        int Count();

        T Get(int index);

        void Add(T value);

        void Remove(int index);

        void Clear();
    }
}
