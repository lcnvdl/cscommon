using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Linq;
using Common.Delegates;
using Common.Helpers.Extension;
using Common.Web;

namespace Common.Helpers
{
    public static class ReflectionHelper
    {
        ///// <summary>
        ///// Setea los atributos de dos objetos.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="matcher"></param>
        ///// <param name="matched"></param>
        public static void MatchObjects<T>(object matcher, ref T matched)
        {
            MatchObjects<T>(matcher, ref matched, true);
        }

        /// <summary>
        /// Setea los atributos de dos objetos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matcher"></param>
        /// <param name="matched"></param>
        /// <param name="caseSensitive"></param>
        public static void MatchObjects<T>(object matcher, ref T matched, bool caseSensitive)
        {
            var matchedProps = GetMatchedProps<T>(matcher, matched, caseSensitive);

            foreach (var property in matcher.GetType().GetProperties())
            {
                var name = property.Name;

                if (!caseSensitive)
                    name = name.ToLower();

                if (property.CanRead && matchedProps.ContainsKey(name))
                {
                    object targetValue = property.GetValue(matcher, null);
                    matchedProps[name].SetValue(matched, targetValue, null);
                }
            }
        }

        public static IEnumerable<T> FromDatatable<T>(DataTable dt) where T: class, new()
        {
            foreach (DataRow row in dt.Rows)
            {
                var columns = dt.Columns.Cast<DataColumn>().ToList();
                var matched = new T();

                foreach (var property in typeof(T).GetProperties())
                {
                    var col = columns.FirstOrDefault(m => m.Caption.ToLower().Equals(property.Name.ToLower()));

                    if (col != null && property.CanWrite)
                    {
                        int index = columns.IndexOf(col);
                        object value = row[index];
                        property.SetValue(matched, value, null);
                    }
                }

                yield return matched;
            }
        }

        public static bool FromDatatable<T>(DataTable dt, ref T matched) 
        {
            return FromDatatable<T>(dt, ref matched, null);
        }

        public static bool FromDatatable<T>(DataTable dt, ref T matched, Object_StringObject eval)
        {
            if (dt.Rows.Count == 0)
                return false;

            var row = dt.Rows[0] as DataRow;
            var columns = dt.Columns.Cast<DataColumn>().ToList();

            foreach (var property in matched.GetType().GetProperties())
            {
                var col = columns.FirstOrDefault(m => m.Caption.ToLower().Equals(property.Name.ToLower()));

                if (col != null && property.CanWrite)
                {
                    int index = columns.IndexOf(col);
                    object value = row[index];

                    if (eval != null)
                    {
                        value = eval(property.Name.ToLower(), value);
                    }

                    property.SetValue(matched, value, null);
                }
            }

            return true;
        }

        public static Type GetEntityType(string entityName)
        {
            return Type.GetType(entityName);
        }

        public static void SetPropertyValue(object obj, string propertyName, object value)
        {
            PropertyInfo property = obj.GetType().GetProperty(propertyName);
            if (property != null)
            {
                object val = null;
                if (property.PropertyType.IsEnum)
                {
                    val = Convert.ToInt32(value);
                }
                else
                {
                    val = Convert.ChangeType(value, property.PropertyType);
                }
                property.SetValue(obj, val, null);
            }
        }

        public static object GetPropertyValue(object obj, string propertyName)
        {
            PropertyInfo property = obj.GetType().GetProperty(propertyName);
            if(property.PropertyType.IsEnum)
                return (int)property.GetValue(obj, null);
            else
                return property.GetValue(obj, null);
        }

        public static bool ContainsAttribute<A>(PropertyInfo pi)
        {
            return GetAttribute<A>(pi) != null;
        }

        public static A GetAttribute<A>(PropertyInfo pi)
        {
            A attribute = default(A);
            object[] attributes = pi.GetCustomAttributes(true);
            if (attributes != null)
            {
                foreach (object attrib in attributes)
                {
                    if (attrib.GetType() == typeof(A))
                    {
                        attribute = (A)attrib;
                        break;
                    }
                }
            }
            return attribute;
        }

        public static bool HasChanged(object a, object b)
        {
            JavaScriptSerializer j = new JavaScriptSerializer();
            return !j.Serialize(a).Equals(j.Serialize(b));
        }

        private static Dictionary<string, PropertyInfo> GetMatchedProps<T>(object matcher, T matched, bool caseSensitive)
        {
            Dictionary<string, PropertyInfo> matchedProps = new Dictionary<string, PropertyInfo>();
            foreach (var property in matched.GetType().GetProperties())
            {
                if (property.CanRead)
                {
                    var name = "";
                    var props = property.GetCustomAttributes(typeof(ReflectionAttribute), true);

                    ReflectionAttribute prop;

                    if (props.Length == 0)
                    {
                        prop = null;
                    }
                    else
                    {
                        prop = props[0] as ReflectionAttribute;
                    }

                    if (prop != null)
                    {
                        name = prop.Name;
                    }
                    else
                    {
                        name = property.Name;
                    }

                    if (!caseSensitive)
                        name = name.ToLower();

                    matchedProps[name] = property;
                }
            }

            return matchedProps;
        }

        public static bool EqualsTo<T>(object matcher, T matched, bool caseSensitive)
        {
            var matchedProps = GetMatchedProps<T>(matcher, matched, caseSensitive);

            foreach (var property in matcher.GetType().GetProperties())
            {
                var name = property.Name;

                if (!caseSensitive)
                    name = name.ToLower();

                if (property.CanRead && matchedProps.ContainsKey(name))
                {
                    object realValue = property.GetValue(matched, null);
                    object targetValue = property.GetValue(matcher, null);

                    if (realValue == null && targetValue != null)
                        return false;

                    if (realValue != null && targetValue == null)
                        return false;

                    var jsonTarget = JSON.Stringify(targetValue);
                    var jsonReal = JSON.Stringify(realValue);

                    if (!jsonReal.Equals(jsonTarget))
                        return false;
                }
            }

            return true;
        }
    }
}
