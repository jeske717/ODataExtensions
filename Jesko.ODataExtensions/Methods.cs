using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Jesko.ODataExtensions
{
    public static class Methods
    {
        public static OData Filter<TResult>(this TResult instance, Expression<Func<TResult, bool>> expression)
        {
            var binaryExpression = expression.Body as BinaryExpression;
            var left = binaryExpression.Left as MemberExpression;
            var field = left.Member as PropertyInfo;

            var right = binaryExpression.Right.ToString().Replace("\"", "");
            return new OData
                       {
                           PropertyName = field.Name,
                           Method = "eq",
                           Value = right
                       };
        }
    }
}
