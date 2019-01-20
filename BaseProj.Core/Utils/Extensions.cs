using System;

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
    }
}
