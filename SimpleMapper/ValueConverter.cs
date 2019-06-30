using System;

namespace SimpleMapper
{
    public sealed class ValueConverter
    {
        public static object Convert(Type destinationType, object value)
        {
            if (value == null)
                return null;

            if (destinationType.IsClass && !destinationType.Assembly.FullName.StartsWith("System."))
                return null;

            if (destinationType.IsInterface)
                return null;

            if (destinationType.IsEnum)
                return Enum.ToObject(destinationType, value);
            
            return System.Convert.ChangeType(value, destinationType);
        }
    }
}
