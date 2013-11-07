using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.Linq
{
    static class MojioTranslate
    {
        public static Expression StripQuotes(Expression e)
        {
            while (e.NodeType == ExpressionType.Quote)
            {
                e = ((UnaryExpression)e).Operand;
            }
            return e;
        }

        public static string GetMemberName(Expression expr)
        {
            expr = StripQuotes(expr);

            if (expr is ConstantExpression)
                return ((ConstantExpression)expr).Value.ToString();

            var member = GetMember(expr);
            if (member == null)
                return "";

            return member.Member.Name;
        }

        public static MemberExpression GetMember(Expression expr)
        {
            expr = StripQuotes(expr);

            MemberExpression me;
            switch (expr.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var ue = expr as UnaryExpression;
                    me = ((ue != null) ? ue.Operand : null) as MemberExpression;
                    break;
                case ExpressionType.MemberAccess:
                    me = expr as MemberExpression;
                    break;
                case ExpressionType.Lambda:
                    var lambda = expr as LambdaExpression;
                    me = GetMember(lambda.Body);
                    break;
                default:
                    throw new Exception("Unkown Type");
            }

            return me;
        }

        public static string GetValue(ConstantExpression constant, Type type)
        {
            if (constant.Type == type)
                return (String)constant.Value.ToString();

            if (constant.Value is IEnumerable)
            {
                var value = "";
                foreach (var e in (IEnumerable)constant.Value)
                {
                    if (value != "") value += ",";
                    value += GetValue(Expression.Constant(e, type), type);
                }
                return value;
            }

            if (type.IsSubclassOf(typeof(Enum)))
                return Enum.GetName(type, constant.Value);
            else if (constant.Type == type)
                return constant.Value.ToString();
            else
                throw new Exception("Type missmatch");
        }

        public static ConstantExpression EvaluateSubtree(Expression e)
        {
            if (e.NodeType == ExpressionType.Constant)
            {
                return (ConstantExpression)e;
            }
            LambdaExpression lambda = Expression.Lambda(e);
            Delegate fn = lambda.Compile();
            return Expression.Constant(fn.DynamicInvoke(null), e.Type);
        }

        public static object GetMemberValue(MemberExpression node)
        {
            var obj = Expression.Convert(node, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(obj);

            return getterLambda.Compile();
        }

        // private static methods
        public static Type GetDocumentType(Expression expression)
        {
            // look for the innermost nested constant of type MongoQueryable<T> and return typeof(T)
            var constantExpression = expression as ConstantExpression;
            if (constantExpression != null)
            {
                var constantType = constantExpression.Type;
                if (constantType.IsGenericType)
                {
                    var genericTypeDefinition = constantType.GetGenericTypeDefinition();
                    if (genericTypeDefinition == typeof(MojioQueryable<>))
                    {
                        return constantType.GetGenericArguments()[0];
                    }
                }
            }

            var methodCallExpression = expression as MethodCallExpression;
            if (methodCallExpression != null && methodCallExpression.Arguments.Count != 0)
            {
                return GetDocumentType(methodCallExpression.Arguments[0]);
            }

            var message = string.Format("Unable to find document type of expression: {0}.", expression.ToString());
            throw new ArgumentOutOfRangeException("expression", message);
        }
    }

    class MojioCriteriaTranslator : ExpressionVisitor
    {
        IDictionary<string, string> criteria;
        bool orMember;

        internal IDictionary<string, string> Translate(Expression expression)
        {
            criteria = new Dictionary<string, string>();
            Visit(expression);

            return criteria;
        }

        protected override void VisitMethodCall(MethodCallExpression methodCall)
        {
            switch (methodCall.Method.Name)
            {
                case "Where":
                    // ??? this.Visit(m.Arguments[0]);

                    LambdaExpression lambda = (LambdaExpression)MojioTranslate.StripQuotes(methodCall.Arguments[1]);
                    this.Visit(lambda.Body);
                    break;
                case "Equals":
                    AddCriteria(methodCall.Object, methodCall.Arguments[0]);
                    break;
                case "In":
                    AddCriteria(methodCall.Arguments[0], methodCall.Arguments[1]);
                    break;
                case "Contains":
                    AddCriteria(methodCall.Arguments[0], methodCall.Object);
                    break;
                default:
                    throw new NotSupportedException(string.Format("The method '{0}' is not supported", methodCall.Method.Name));
            }
        }

        private void AddCriteria(Expression left, Expression right)
        {
            var memberExpression = MojioTranslate.GetMember(left);

            if (memberExpression == null)
                throw new Exception("Cannot do this?");

            var key = memberExpression.Member.Name;

            var constant = MojioTranslate.EvaluateSubtree(right);
            string value = MojioTranslate.GetValue(constant, memberExpression.Type);

            criteria.Add(key, value);
        }

        protected override void VisitBinary(BinaryExpression b)
        {
            switch (b.NodeType)
            {
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                    // Only support AND at the moment!
                    Visit(b.Left);
                    Visit(b.Right);
                    break;
                case ExpressionType.Or:
                    // We could maybe check if b.Left exists?
                    break;
                case ExpressionType.Equal:
                    // Equals is what we want!

                    AddCriteria(b.Left, b.Right);
                    break;
                default:
                    throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));
            }
        }
    }
}
