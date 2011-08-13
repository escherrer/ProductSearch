using System;
using System.Linq.Expressions;

namespace ProductSearch.Utility
{
    public static class ReflectionHelper
    {
        public static string GetPropertyName<T, TReturn>(Expression<Func<T, TReturn>> expression)
        {
            var body = (MemberExpression)expression.Body;

            return body.Member.Name;
        }

        public static string GetPropertyName<T>(Expression<Func<T>> e)
        {
            var member = (MemberExpression)e.Body;
            return member.Member.Name;
        }
    }
}
