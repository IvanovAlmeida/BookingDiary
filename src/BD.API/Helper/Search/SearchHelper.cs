using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BD.API.Helper.Search
{
    public class SearchHelper<T>
    {
        private readonly ParameterExpression ParameterExpression;
        private readonly List<Expression> Expressions = new List<Expression>();

        public SearchHelper() => ParameterExpression = Expression.Parameter(typeof(T), "x");

        public SearchHelper<T> AddAndExpression(string propertyName, object value, ExpressionOperation operation = ExpressionOperation.EqualTo)
        {
            var member = Expression.Property(ParameterExpression, propertyName);
            var constant = Expression.Constant(value);

            Expression expression = null;

            switch (operation)
            {
                case ExpressionOperation.Contains:
                    {
                        if (!value.GetType().Equals(typeof(string)))
                            break;

                        var body = Expression.Call(
                            Expression.Property(ParameterExpression, propertyName),
                            "Contains",
                            Type.EmptyTypes,
                            Expression.Constant(value)
                        );

                        expression = body;
                    }
                    break;
                case ExpressionOperation.LessThan:
                    expression = Expression.LessThan(member, constant);
                    break;
                case ExpressionOperation.LessThanOrEqualTo:
                    expression = Expression.LessThanOrEqual(member, constant);
                    break;
                case ExpressionOperation.GreaterThan:
                    expression = Expression.GreaterThan(member, constant);
                    break;
                case ExpressionOperation.GreaterThanOrEqualTo:
                    expression = Expression.GreaterThanOrEqual(member, constant);
                    break;
                case ExpressionOperation.NotEqualTo:
                    expression = Expression.NotEqual(member, constant);
                    break;
                case ExpressionOperation.EqualTo:
                default:
                    expression = Expression.Equal(member, constant);
                    break;
            }

            if(expression != null)
                Expressions.Add(expression);

            return this;
        }

        public Expression<Func<T, bool>> BuildExpression()
        {
            Expression expression = Expression.Constant(true);

            foreach (var exp in Expressions)
                expression = Expression.AndAlso(expression, exp);

            return Expression.Lambda<Func<T, bool>>(expression, ParameterExpression);
        }
    }
}
