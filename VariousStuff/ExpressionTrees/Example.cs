using System;
using System.Linq;
using System.Linq.Expressions;

namespace JustOneProject.VariousStuff.ExpressionTrees
{
    public static class Example
    {
        public static IQueryable<T> OrderByPropertyOrField<T>(
            this IQueryable<T> queryable,
            string propertyOrFieldName,
            bool ascending
        )
        {
            var elementType = typeof(T);
            var parameter = Expression.Parameter(elementType);
            var prop = Expression.PropertyOrField(parameter, propertyOrFieldName);
            var selector = Expression.Lambda(prop, parameter);

            throw new NotImplementedException();
        }
    }
}