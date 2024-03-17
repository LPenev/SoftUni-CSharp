using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfTheClass, params string[] fields)
        {
            StringBuilder sb = new StringBuilder();

            Type typeOfClass = Type.GetType(nameOfTheClass);
            FieldInfo[] fieldsInfo = typeOfClass.GetFields((BindingFlags)60);
            Object instancedClass = Activator.CreateInstance(typeOfClass);

            sb.AppendLine($"Class under investigation: {instancedClass.ToString()}");

            foreach (FieldInfo field in fieldsInfo.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(instancedClass)}");
            }


            return sb.ToString().TrimEnd();
        }
    }
}