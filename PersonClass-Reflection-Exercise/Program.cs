using System;
using System.Linq;
using System.Reflection;

namespace PersonClass_Reflection
{
    public class Person
    {
        public int Property1 { get; set; }

        public void Method1()
        {
            Console.WriteLine("Method1 is executed..");
        }
        public void Method2(int value1, string value2)
        {
            Console.WriteLine($"Method1 is executed with {value1} {value2}..");
        }
        private void MethodPrivate()
        {
            Console.WriteLine("Method1 is executed..");
        }
    }
    public class Program
    {

        public static string GetParameters(ParameterInfo[] parameters)
        {
            return string.Join(",", parameters.Select(p => $"{p.ParameterType} {p.Name}"));
        }
        static void Main(string[] args)
        {

            Type type = typeof(Person);
            Console.WriteLine($"Type Name = {type.Name}");
            Console.WriteLine($"Full Type = {type.FullName}");


            Console.WriteLine($"\nProperties are :");
            foreach (var property in type.GetProperties())
            {
                Console.WriteLine($"\t Property Name :{property.Name} , Property Type: {property.PropertyType}");
            }

            //Get all method inside class Person.//note: private method not appear here.
            Console.WriteLine("Methods are");
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine($"\t{method.ReturnType} {method.Name} ({GetParameters(method.GetParameters())}) ");
            }

            //Great an instance of class Person in runtime throw reflection.
            object person = Activator.CreateInstance(type);

            //set a value to property1 using reflection.
            type.GetProperty("Property1").SetValue(person, 24);
            Console.WriteLine($"Set Property1 to 24 using reflection.");


            //get value of property1 using reflection.
            Console.WriteLine($"\nGetting Property1 using reflection.");
            int value = (int)type.GetProperty("Property1").GetValue(person);
            Console.WriteLine($"value of property1 is : {value}");


            //Invoke method1 using reflection.
            type.GetMethod("Method1").Invoke(person, null);


            //Invoke Method2 with parameters using reflection.
            object[] parameters = { 10, "Roaa Al Homsi" };
            type.GetMethod("Method2").Invoke(person, parameters);

            Console.ReadKey();

        }
    }
}
