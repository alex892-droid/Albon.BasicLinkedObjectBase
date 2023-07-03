using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLinkedObjectBase
{
    internal static class ObjectBaseMapper<T>
    {
        static public readonly string PartitionName = typeof(T).Name.ToUpper();
        static public string[] Columns = typeof(T).GetProperties().Select(p => p.Name.ToUpper()).ToArray();
    }
}
