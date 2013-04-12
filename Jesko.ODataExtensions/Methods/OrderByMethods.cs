using System;
using System.Linq.Expressions;
using Jesko.ODataExtensions.Helpers;
using Jesko.ODataExtensions.Mixins;

namespace Jesko.ODataExtensions.Methods
{
    public enum OrderBy
    {
        Ascending, Descending
    }

    public static class OrderByMethods
    {
        public static OData OrderBy<TResult>(this IODataCapable<TResult> instance, Expression<Func<TResult, object>> expression, OrderBy order = Methods.OrderBy.Ascending) where TResult : class
        {
            return OrderBy(instance as IODataCapable, expression, order);
        }

        public static OData OrderBy<TResult>(this IODataCapable instance, Expression<Func<TResult, object>> expression, OrderBy order = Methods.OrderBy.Ascending)
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