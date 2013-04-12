using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Jesko.ODataExtensions
{
    public static class Methods
    {
        public static OData Filter<TResult>(this TResult instance, Expression<Func<TResult, bool>> expression)
        {
            return Filter(instance as object, expression);
        }

        public static OData Filter<TResult>(this object instance, Expression<Func<TResult, bool>> expression)
        {
            var binaryExpression = expression.Body as BinaryExpression;
            var left = binaryExpression.Left as MemberExpression;
            var field = left.Member as PropertyInfo;
            var right = binaryExpression.Right.ToString().Replace("\"", "");

            return new OData
                       {
                           PropertyName = field.Name,
                           Method = Method(binaryExpression.NodeType),
                           Value = right
                       };
        }

        private static string Method(ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    return "eq";
                case ExpressionType.NotEqual:
                    return "ne";
                case ExpressionType.GreaterThan:
                    return "gt";
                case ExpressionType.GreaterThanOrEqual:
                    return "ge";
                case ExpressionType.LessThan:
                    return "lt";
                case ExpressionType.LessThanOrEqual:
                    return "le";
            }
            return null;
        }
    }
}
