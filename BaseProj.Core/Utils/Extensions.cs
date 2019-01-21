using System;
using System.Linq;

namespace BaseProj.Core.Utils
{
    public static class Extensions
    {
        public static T Without<T>(this T t, params string[] prop)
        {
            var obj = t;
            foreach (var p in prop)
                obj.GetType().GetProperty(p).SetValue(obj, null);
            return obj;
        }

        public static DateTime ToDateTime(this string value)
        {
            var array = value.Split("-");

            var firstInteger = int.Parse(array[0]);
            var secondInteger = int.Parse(array[1]);
            var thirdInteger = int.Parse(array[2]);

            if (firstInteger.ToString().Length > 3)
                return new DateTime(firstInteger, secondInteger, thirdInteger);
            else if (thirdInteger.ToString().Length > 3)
                return new DateTime(thirdInteger, secondInteger, firstInteger);
            else return new DateTime().Date;
        }

        public static void ApplyProperties<T>(this T from, ref T to, params string[] exception)
        {
            foreach (var propTo in to.GetType().GetProperties())
                foreach (var propFrom in from.GetType().GetProperties())
                    if (propFrom.Name == propTo.Name)
                        if (propTo.CustomAttributes.Where(ca => ca.AttributeType.Name == "KeyAttribute" || ca.AttributeType.Name == "DatabaseGeneratedAttribute").Count() == 0)
                            if (!exception.Contains(propFrom.Name))
                                propTo.SetValue(to, propFrom.GetValue(from));
        }
    }
}
