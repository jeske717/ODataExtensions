using System;
using System.Linq.Expressions;

namespace Jesko.ODataExtensions
{
    public static class Methods
    {
        public static OData Filter<TResult>(this TResult instance, Expression<Func<TResult, bool>> expression)
        {
            return new OData();
        }
    }
}
