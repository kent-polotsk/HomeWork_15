using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_15
{

    public class School
    {
        public List<Person> pupils;

        SchoolDirector director;

        public EnrollmentDelegate enrollmentDelegate;

        public DirectorGreeting directorGreeting;

        public School()
        {
            director = new SchoolDirector();
            pupils = new List<Person>();
            directorGreeting = (director.Greeting);
        }

        public void Enrollment(Person person)
        {

            try
            {
                if (person != null)
                {
                    pupils.Add(person);
                    directorGreeting?.Invoke(person);
                }
                else
                    throw new NullReferenceException();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("NULL. " + e.Message);
            }
        }

        public Person Search(SearchDelegate searchDelegate, string Name, string Surname)
        {
            //foreach (Person person in pupils)
            //{
            //    if (value(person))
            //        return person;
            //}
            return searchDelegate(pupils, Name, Surname);
        }
    }
}

