using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_15
{
    internal class SchoolDirector : Person
    {
        public SchoolDirector() 
        {
            Name = "Петр";
            Surname = "Петров";
            Age = 53;
        }

        public void Greeting(Person person) 
        {
            try
            {
                if (person != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Приветствую родителей! Ваш ребенок {person.Name} {person.Surname} принят в школу!");
                    Console.ResetColor();
                }
                else
                    throw new NullReferenceException();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("NULL. " + e.Message);
            }            
        }
    }
}
