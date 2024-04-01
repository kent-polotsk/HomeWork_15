using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_15
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public Person()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Age = 0;
        }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public int CompareTo(Person? other)
        {
            try
            {
                if (other != null)
                    return Age.CompareTo(other.Age);
                else
                    throw new NullReferenceException();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("NULL. " + e.Message);
                return -1;
            }
        }

        public bool Equals(Person? other)
        {
            try
            {
                if (other != null)
                {
                    if (other.Name == Name && other.Surname == Surname)
                        return true;
                    else 
                        return false;
                }
                else
                    throw new NullReferenceException();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("NULL. " + e.Message);
                return false;
            }
        }
    }
}
