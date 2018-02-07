using Common.Helpers.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class MappingHelper<TA, TB> 
        where TA: class
        where TB: class
    {
        private MapInfo Result { get; set; }

        public MappingHelper()
        {
            Result = new MapInfo();
        }

        public MappingHelper<TA, TB> MapSameName(bool ignoreCase)
        {
            var from= typeof(TA);
            var to = typeof(TB);

            var fromMembers = Extract(from);
            var toMembers = Extract(to);

            foreach (var fromMember in fromMembers)
            {
                var toMember = toMembers.FirstOrDefault(m => m.Name.Equals(fromMember.Name, ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture));
                if (toMember != null)
                {
                    Result.AddMap(fromMember, toMember);
                }
            }

            return this;
        }

        public MappingHelper<TA, TB> Map<T, X>(Expression<Func<T>> from, Expression<Func<X>> to)
        {
            var ma = GetMember<T>(from);
            var mb = GetMember<X>(to);

            Result.AddMap(ma, mb);

            return this;
        }

        public void Copy(TA from, TB to)
        {
            Result.From.Values.ToList().ForEach(m => Copy(m, Result.To[Result.FromTo[m.Name]], from, to));
        }

        public void Copy(TB from, TA to)
        {
            Result.To.Values.ToList().ForEach(m => Copy(m, Result.From[Result.ToFrom[m.Name]], from, to));
        }

        public void Clear()
        {
            Result = new MapInfo();
        }

        private static void Copy(MemberInfo a, MemberInfo b, object oa, object ob)
        {
            var val = Get(a, oa);
            Set(b, ob, val);
        }

        private static object Get(MemberInfo m, object o)
        {
            if (m is PropertyInfo)
            {
                return ((PropertyInfo)m).GetValue(o);
            }
            else
            {
                return ((FieldInfo)m).GetValue(o);
            }
        }

        private static void Set(MemberInfo m, object o, object val)
        {
            var parsedVal = val;
            var targetType = GetMType(m);

            if (val != null && targetType != val.GetType())
            {
                if (targetType.IsEnum)
                {
                    parsedVal = Convert.ChangeType(val, Enum.GetUnderlyingType(targetType));
                }
                else
                {
                    parsedVal = Convert.ChangeType(val, targetType);
                }
            }

            if (m is PropertyInfo)
            {
                ((PropertyInfo)m).SetValue(o, parsedVal);
            }
            else
            {
                ((FieldInfo)m).SetValue(o, parsedVal);
            }
        }

        private static Type GetMType(MemberInfo m)
        {
            if (m is PropertyInfo)
            {
                return ((PropertyInfo)m).PropertyType;
            }
            else
            {
                return ((FieldInfo)m).FieldType;
            }
        }

        private static IEnumerable<MemberInfo> Extract(Type t)
        {
            foreach (var pi in t.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                yield return pi;
            }

            foreach (var pi in t.GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                yield return pi;
            }
        }

        private static MemberInfo GetMember<T>(Expression<Func<T>> property)
        {
            var me = property.Body as MemberExpression;

            if (me == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            return me.Member;
        }

        private static string GetName<T>(Expression<Func<T>> property)
        {
            var me = property.Body as MemberExpression;

            if (me == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            return me.Member.Name;
        }
    }
}
