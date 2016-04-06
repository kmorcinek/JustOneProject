using System;
using System.Linq.Expressions;
using AutoMapper;

namespace JustOneProject.Extensions
{
    // Source: https://gist.github.com/kmorcinek/64641a11a4cd5b8c18d8
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Maps properties as ignored.
        /// </summary>
        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map,
            Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());

            return map;
        }

        /// <summary>
        /// Sets mapping from source property to destination property. Convenient extension method. 
        /// </summary>
        public static IMappingExpression<TSource, TDestination> MapProperty<TSource, TDestination, TProperty>(
            this IMappingExpression<TSource, TDestination> map,
            Expression<Func<TSource, TProperty>> sourceMember,
            Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, opt => opt.MapFrom(sourceMember));

            return map;
        }
    }
}