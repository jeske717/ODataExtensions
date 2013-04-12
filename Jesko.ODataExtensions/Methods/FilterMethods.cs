using System;
using System.Linq.Expressions;
using Jesko.ODataExtensions.Helpers;
using Jesko.ODataExtensions.Mixins;

namespace Jesko.ODataExtensions.Methods
{
    public static class FilterMethods
    {
        public static OData Filter<TResult>(this IODataCapable<TResult> instance, Expression<Func<TResult, bool>> expression) where TResult : class
        {
            return Filter(instance as IODataCapable, expression);
        }

        public static OData Filter<TResult>(this IODataCapable instance, Expression<Func<TResult, bool>> expression)
        {
            var binaryExpression = expression.Body as BinaryExpression;
            if(binaryExpression == null)
            {
                throw new ArgumentException("Operation supplied is not supported");
            }

            var left = binaryExpression.Left as MemberExpression;
            if(left == null)
            {
                throw new ArgumentException("Left side operand must be a property");
            }

            var right = binaryExpression.Right.ToString().Replace("\"", "");
            return new FilterOData
                       {
                           PropertyName = PropertyNameHelper.PropertyName(left.Member),
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
