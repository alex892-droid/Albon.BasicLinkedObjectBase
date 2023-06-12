using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtDatabase
{
    internal static class DatabaseMapper<T>
    {
        static public readonly string TableName = "T_" + typeof(T).Name.ToUpper();
        static public string[] Columns = typeof(T).GetProperties().Select(p => p.Name.ToUpper()).ToArray();
    }
}
