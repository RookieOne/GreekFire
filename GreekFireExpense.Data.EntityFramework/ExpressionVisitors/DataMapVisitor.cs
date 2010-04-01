using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GreekFireExpense.Domain;
using GreekFireExpense.Foundation.ExpressionVisitors;

namespace GreekFireExpense.Data.EntityFramework.ExpressionVisitors
{
    public class DataMapVisitor : ExpressionVisitor
    {
        private readonly GreekFireExpenseDBEntities _database;
        private Dictionary<Type, ParameterExpression> _parameterCache;

        public DataMapVisitor(GreekFireExpenseDBEntities database)
        {
            _database = database;
        }

        public IQueryable Execute(Expression expression)
        {
            _parameterCache = new Dictionary<Type, ParameterExpression>();
            Console.WriteLine(expression);

            Expression exp = Visit(expression);

            Console.WriteLine(exp);
            //Console.ReadLine();

            Expression<Func<IQueryable>> final = Expression.Lambda<Func<IQueryable>>(exp);
            Func<IQueryable> d = final.Compile();
            return d();
        }

        protected override MemberBinding VisitBinding(MemberBinding binding)
        {
            return base.VisitBinding(binding);
        }

        protected override Expression VisitMemberInit(MemberInitExpression init)
        {
            return base.VisitMemberInit(init);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            if (p.Type == typeof (Expense))
            {
                return GetParameterExpression(p);
            }

            return base.VisitParameter(p);
        }

        protected override IEnumerable<MemberBinding> VisitBindingList(ReadOnlyCollection<MemberBinding> original)
        {
            return base.VisitBindingList(original);
        }

        protected override Expression VisitListInit(ListInitExpression init)
        {
            return base.VisitListInit(init);
        }

        protected override ElementInit VisitElementInitializer(ElementInit initializer)
        {
            return base.VisitElementInitializer(initializer);
        }

        protected override Expression VisitUnary(UnaryExpression u)
        {
            return base.VisitUnary(u);
        }


        protected override Expression VisitLambda(LambdaExpression lambda)
        {
            var ps = new List<ParameterExpression>();
            foreach (ParameterExpression p in lambda.Parameters)
            {
                ParameterExpression pExp = GetParameterExpression(p);
                ps.Add(pExp);
            }

            LambdaExpression final = Expression.Lambda(lambda.Body, ps.ToArray());

            return base.VisitLambda(final);
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Type == typeof (IQueryable<Expense>))
            {
                var arguments = new List<Expression>();

                foreach (Expression argument in m.Arguments)
                {
                    if (argument.NodeType == ExpressionType.Constant)
                    {
                        ConstantExpression arg = Expression.Constant(_database.Expenses,
                                                                     typeof (ObjectQuery<Expenses>));
                        arguments.Add(Visit(arg));
                    }
                    else
                    {
                        arguments.Add(Visit(argument));
                    }
                }

                var typeArgs = new[] {typeof (Expenses)};

                return Expression.Call(typeof (Queryable), "Where", typeArgs, arguments.ToArray());
            }

            return base.VisitMethodCall(m);
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (c.Value != null)
            {
                var queryable = c.Value as IQueryable<Expense>;

                if (queryable != null)
                {
                    return Expression.Constant(_database.Expenses, typeof (Expenses));
                }
            }

            return base.VisitConstant(c);
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Expression.Type == typeof (Expense))
            {
                string memberName = m.Member.Name;

                var pExp = (ParameterExpression) m.Expression;
                ParameterExpression exp = GetParameterExpression(pExp);
                PropertyInfo methodInfo = (typeof (Expenses)).GetProperty(memberName);

                return Expression.MakeMemberAccess(exp, methodInfo);
            }

            return base.VisitMemberAccess(m);
        }

        private ParameterExpression GetParameterExpression(ParameterExpression expression)
        {
            if (expression.Type == typeof (Expense))
            {
                if (_parameterCache.ContainsKey(expression.Type))
                {
                    return _parameterCache[expression.Type];
                }
                else
                {
                    ParameterExpression paramExp = Expression.Parameter(typeof (Expenses), expression.Name);
                    _parameterCache.Add(expression.Type, paramExp);

                    return paramExp;
                }
            }

            return expression;
        }


        protected override MemberAssignment VisitMemberAssignment(MemberAssignment assignment)
        {
            return base.VisitMemberAssignment(assignment);
        }
    }
}