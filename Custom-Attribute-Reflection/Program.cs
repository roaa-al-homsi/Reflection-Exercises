using System;
using System.Reflection;

namespace Custom_Attribute_Reflection
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    class EmployeeAttribute : Attribute
    {
        public string Description { get; set; }
        public EmployeeAttribute(string description) => Description = description;

    }

    [Employee("this is a class attribute ")]//calling to ctr EmployeeAttribute . Employee refers to my custom attribute.
    //not c# remove a word attribute.

    class MyClass
    {
        [Employee("this is a method attribute.. ")]
        public void Method1()
        {
            //Console.WriteLine("");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass);

            object[] classAttributes = type.GetCustomAttributes(typeof(EmployeeAttribute), false);
            foreach (EmployeeAttribute attribute in classAttributes)
            {
                Console.WriteLine($"Class attributes: {attribute.Description}");
            }

            //get method-level attributes
            MethodInfo methodInfo = type.GetMethod("Method1");
            object[] methodAttributes = methodInfo.GetCustomAttributes(typeof(EmployeeAttribute), false);
            foreach (EmployeeAttribute attribute in classAttributes)
            {
                Console.WriteLine($"Class attributes: {attribute.Description}");
            }

            Console.ReadKey();
        }
    }
}
