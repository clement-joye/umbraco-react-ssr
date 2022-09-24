using System.Reflection;

namespace Umbraco.React.Ssr.Web.Infrastructure.Extensions
{
    public static class AssemblyExtension
    {
        public static List<Type> GetTypesAssignableFrom<T>(this Assembly assembly)
        {
            return assembly.GetTypesAssignableFrom(typeof(T));
        }
        public static List<Type> GetTypesAssignableFrom(this Assembly assembly, Type compareType)
        {
            List<Type> ret = new();
            foreach (var type in assembly.DefinedTypes)
            {
                if (compareType.IsAssignableFrom(type) && compareType != type)
                {
                    ret.Add(type);
                }
            }
            return ret;
        }
    }
}
