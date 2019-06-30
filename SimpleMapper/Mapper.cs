using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimpleMapper
{
    public sealed class Mapper
    {
        internal readonly Dictionary<Type, Delegate> Methods;

        public Mapper()
        {
            Methods = new Dictionary<Type, Delegate>();
        }

        public void Configurate<TSource, TDestination>() where TDestination : new()
        {
            Func<TSource, TDestination> func = (source) => Map<TSource, TDestination>(source);
            Methods.Add(typeof(TSource), func);
        }

        //public void Test<TSource, TDestination>(TSource source, ref TDestination destinationType)
        //{
        //    Convert.ChangeType()
        //}

        public TDestination Map<TSource, TDestination>(TSource sourceModel) where TDestination : new()
        {
            var destinationModel = new TDestination();
            
            Dictionary<string, PropertyInfo> properties = sourceModel.GetType().GetProperties()
                .ToDictionary(p => p.Name);

            foreach (var destinationProperty in destinationModel.GetType().GetProperties())
            {
                PropertyInfo sourcePropertyInfo;
                if (!properties.TryGetValue(destinationProperty.Name, out sourcePropertyInfo))
                    continue;

                var value = sourcePropertyInfo.GetValue(sourceModel);

                object result = null;
                if (value.GetType().IsClass && !value.GetType().Assembly.FullName.Contains("System."))
                {
                    Delegate del;
                    Methods.TryGetValue(sourcePropertyInfo.PropertyType, out del);

                    result = del.DynamicInvoke(sourcePropertyInfo.GetValue(sourceModel));
                }
                else
                {
                    result = ValueConverter.Convert(destinationProperty.PropertyType,
                        sourcePropertyInfo.GetValue(sourceModel));
                }

                if(result == null)
                    continue;

                destinationProperty.SetValue(destinationModel, result);
            }

            return (TDestination)destinationModel;
        }
    }
}
