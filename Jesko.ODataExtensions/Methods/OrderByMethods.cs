using System;
using System.Linq.Expressions;
using Jesko.ODataExtensions.Helpers;

namespace Jesko.ODataExtensions.Methods
{
    public enum OrderBy
    {
        Ascending, Descending
    }

    public static class OrderByMethods
    {
        public static OData OrderBy<TResult>(this TResult instance, Expression<Func<TResult, object>> expression, OrderBy order = Methods.OrderBy.Ascending)
        {
            return OrderBy(instance as object, expression, order);
        }

        public static OData OrderBy<TResult>(this object instance, Expression<Func<TResult, object>> expression, OrderBy order = Methods.OrderBy.Ascending)
        {
            var member = expression.Body as MemberExpression;

            if (member == null)
            {
                throw new ArgumentException("Expression must be a member");
            }

            return new OrderByOData
            {
                PropertyName = PropertyNameHelper.PropertyName(member.Member),
                Order = order == Methods.OrderBy.Ascending ? "asc" : "desc"
            };
        }
    }
}