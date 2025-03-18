using System;
using System.Linq;
using System.Reflection;

namespace Training_Reflection
{
    internal class Program
    {
        public static string GetParameters(ParameterInfo[] parameters)
        {
            return string.Join(",", parameters.Select(p => $"{p.ParameterType} {p.Name}"));
        }
        static void Main(string[] args)
        {
            //get the assembly containing the system.string type.
            Assembly assembly = typeof(string).Assembly;

            //get the system string type.
            Type stringType = assembly.GetType("System.String");

            if (stringType != null)
            {
                Console.WriteLine("Methods of the system.string class..");

                var stringMethods = stringType.GetMethods(BindingFlags.Public | BindingFlags.Instance).OrderBy(method => method.Name);
                foreach (var method in stringMethods)
                {
                    Console.WriteLine($"\t{method.ReturnType} {method.Name} ({GetParameters(method.GetParameters())}) ");
                }

            }
            Console.ReadKey();

        }
    }
}
