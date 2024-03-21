using System.Reflection;
using System.Text;

namespace Stealer
{
    internal class Spy
    {
        public string StealFieldInfo(string nameOfTheClass, params string[] fields)
        {
            StringBuilder sb = new StringBuilder();

            Type typeOfClass = Type.GetType(nameOfTheClass);
            FieldInfo[] fieldsInfo = typeOfClass.GetFields((BindingFlags)60);
            Object instancedClass = Activator.CreateInstance(typeOfClass);

            sb.AppendLine($"Class under investigation: {instancedClass}");

            foreach (FieldInfo field in fieldsInfo.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instancedClass)}");
            }


            return sb.ToString().TrimEnd();
        }


        public string AnalyzeAccessModifiers(string nameOfTheClass)
        {
            StringBuilder sb = new StringBuilder();

            Type typeOfClass = Type.GetType(nameOfTheClass);
            FieldInfo[] fieldsInfo = typeOfClass
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = typeOfClass
                .GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] privateMethods = typeOfClass
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fieldsInfo)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in publicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            foreach (MethodInfo method in privateMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string nameOfClass)
        {
            Type typeOfClass = Type.GetType(nameOfClass);
            MethodInfo[] privateMothods = typeOfClass
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {nameOfClass}");
            sb.AppendLine($"Base Class: {typeOfClass.BaseType.Name}");

            foreach (MethodInfo method in privateMothods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}