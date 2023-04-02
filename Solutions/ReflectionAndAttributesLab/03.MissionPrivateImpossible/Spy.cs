using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");
            Type type = Type.GetType(className);

            object instance = Activator.CreateInstance(type);

            FieldInfo[] fields = type.GetFields((BindingFlags)60);

            foreach (FieldInfo field in fields.Where(x => fieldNames.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return sb.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType($"Stealer.{className}");
            FieldInfo[] fieldInfo = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Instance);
            MethodInfo[] gettersInfo = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.Name.StartsWith("get")).ToArray();
            MethodInfo[] settersInfo = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name.StartsWith("set")).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in fieldInfo)
            {
                sb.AppendLine($"{field.Name} cannot be private!");
            }
            foreach (MethodInfo getter in gettersInfo)
            {
                sb.AppendLine($"{getter.Name} have to be public!");
            }
            foreach(MethodInfo setter in settersInfo)
            {
                sb.AppendLine($"{setter.Name} have to be private!");
            }

            return sb.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString();
        }
    }
}
