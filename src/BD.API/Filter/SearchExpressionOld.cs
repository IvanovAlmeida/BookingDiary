using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BD.API.Filter
{
    public class SearchExpressionOld
    {
        private List<Expression> _expressions = new List<Expression>() {
             Expression.Constant(true)
        };

        private ParameterExpression _parameterExpression;
        private Type _targetClass;

        public Expression<Func<object, bool>> BuildSearchExpression(object filter)
        {
            var type = filter.GetType();

            _parameterExpression = Expression.Parameter(type, "x");

            if (!HasSearchAttribute(type))
                throw new ArgumentException("The filter does not have the SearchAttribute");

            _targetClass = GetTypeClassTarget(type);

            var properties = GetPropertyInfos(type);
            foreach (var prop in properties)
            {
                if (!HasSearchAttribute(prop))
                    continue;

                string propertyTarget = GetPropertyTarget(prop);

                AddExpression(propertyTarget);
            }

            return null;
        }

        private void AddExpression(string propertyTarget) {

            var member = Expression.Property(_parameterExpression, "Entry");
            //var constant = Expression.Constant(reserveSearch.Entry);
            //Expression expression = Expression.Equal(member, constant);
        }

        private string GetPropertyTarget(PropertyInfo propertyInfo)
        {
            var searchAttribute = propertyInfo.GetCustomAttribute(typeof(SearchAttribute)) as SearchAttribute;
            return searchAttribute.PropertyTarget;
        }

        private Type GetTypeClassTarget(Type type)
        {
            var searchAttribute = type.GetCustomAttribute(typeof(SearchAttribute)) as SearchAttribute;

            if (searchAttribute == null)
                throw new NullReferenceException("searchAttribute is null");

            return searchAttribute.ClassTarget;
        }

        private IEnumerable<PropertyInfo> GetPropertyInfos(Type type)
        {
            return type.GetProperties()
                        .Where(p => p.GetCustomAttributes()
                                        .Any(ca => ca.GetType()
                                                        .Equals(typeof(SearchAttribute))));
        }

        private bool HasSearchAttribute(PropertyInfo property)
        {
            var attr = (SearchAttribute)property.GetCustomAttribute(typeof(SearchAttribute), false);

            return attr != null;
        }

        private bool HasSearchAttribute(Type type)
        {
            var attr = (SearchAttribute)type.GetCustomAttribute(typeof(SearchAttribute), false);

            return attr != null;
        }
    }
}
