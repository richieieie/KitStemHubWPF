﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.HelperExtension
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));
            var combined = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    Expression.Invoke(expr1, parameter),
                    Expression.Invoke(expr2, parameter)
                ),
                parameter
            );
            return combined;
        }
    }
}
