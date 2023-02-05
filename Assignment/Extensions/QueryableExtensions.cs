using System.Linq.Expressions;

namespace Assignment.Extensions
{
	public static class QueryableExtensions
	{
		public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> conditionTruePredicate, Expression<Func<TSource, bool>>? conditionFalsePredicate = null)
		{
			if( condition )
			{
				return source.Where(conditionTruePredicate);
			}

			if( conditionFalsePredicate != null )
			{
				return source.Where(conditionFalsePredicate);
			}

			return source;
		}
	}
}
