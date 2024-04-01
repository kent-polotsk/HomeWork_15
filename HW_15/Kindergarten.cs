using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_15
{

    public class Kindergarten
    {
        public List<Person> kids;

        public delegate void GrovnEventDelegate(Person person);
        public event GrovnEventDelegate GrownNotify;

        public Kindergarten()
        {
            kids = new List<Person>();
        }

        public void Growing()
        {
            if (kids != null && kids.Count != 0)
                foreach (Person p in kids.ToList())
                {
                    p.Age++;
                    if (p.Age >= 6)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{p.Name} {p.Surname} вырос и окончил детский садик!");
                        Thread.Sleep(50);
                        GrownNotify?.Invoke(p);
                        kids.Remove(p);
                        if (kids.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("В детском садике не осталось детей.");
                            Console.ResetColor();
                        }
                    }
                }
            else
            {
                
            }
        }


        public void Add(Person person)
        {
            try
            {
                if (person != null)
                {
                    kids.Add(person);
                    Console.WriteLine($"{person.Name} {person.Surname} ({person.Age}лет) пошел в детский садик.");
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
