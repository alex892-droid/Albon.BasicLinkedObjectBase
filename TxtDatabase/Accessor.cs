using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TxtDatabase
{
    internal static class Accessor<T, TAttribute> where TAttribute : Attribute
    {
        static private readonly ParameterExpression instance = Expression.Parameter(typeof(T));
        static public readonly Func<T, string> ReadIDValue = Expression.Lambda<Func<T, string>>(GetExpressionGetPropertyID(), instance).Compile();

        private static Expression GetExpressionGetPropertyID()
        {
            var propertyId = typeof(T).GetProperties().FirstOrDefault(p => p.GetCustomAttribute<TAttribute>() != null);

            if (propertyId == null) //No ID property found.
            {
                return Expression.Constant(string.Empty);
            }
            return Expression.Property(instance, propertyId);
        }
    }
}
