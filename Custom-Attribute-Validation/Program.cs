using System;

namespace Custom_Attribute_Validation
{
    class RangeAttribute : Attribute
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public string ErrorMessage { get; set; }

        public RangeAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
    class Person
    {
        [Range(20, 80, ErrorMessage = "Age must be between 20 and 80")]
        public int Age { get; set; }
        public string Name { get; set; }

        [Range(3, 7, ErrorMessage = "Experience must be between 3 and 7")]
        public int Experience { get; set; }
    }

    internal class Program
    {
        public static bool ValidationPerson(Person person)
        {
            Type type = typeof(Person);

            foreach (var property in type.GetProperties())
            {
                if (Attribute.IsDefined(property, typeof(RangeAttribute)))
                {
                    var rangeAttribute = (RangeAttribute)Attribute.GetCustomAttribute(property, typeof(RangeAttribute));
                    int value = (int)property.GetValue(person);

                    //perform validation
                    if (value < rangeAttribute.Min || value > rangeAttribute.Max)
                    {
                        Console.WriteLine($"Validation failed for property {property.Name} : {rangeAttribute.ErrorMessage}");
                        return false;
                    }
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Person person = new Person() { Age = 100, Name = "Roaa Homsi", Experience = 10 };
            if (ValidationPerson(person))
            {
                Console.WriteLine("Person is valid..");
            }
            else
            {
                Console.WriteLine("Person is not valid..");
            }

            Console.ReadKey();
        }
    }
}






