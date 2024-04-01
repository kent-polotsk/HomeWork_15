using HW_15;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

public delegate void EnrollmentDelegate(Person person);

public delegate void DirectorGreeting(Person person);

public delegate Person SearchDelegate(List<Person> list, string Name, string Surname );


public enum NamesM
{
    Иван,
    Сергей,
    Павел,
    Семён,
    Дмитрий,
    Андрей,
    Антон,
    Петр,
    Владимир,
    Алексей
}

public enum NamesF
{
    Анна,
    Ольга,
    Мария,
    Татьяна,
    Елена,
    Светлана,
    Марина,
    Настя,
    Зоя,
    Евгения,
}

public enum Surnames
{
    Иванов,
    Петров,
    Сидоров,
    Антонов,
    Сергеев,
    Дмитриев,
    Конев,
    Андреев,
    Котов,
    Орехов,
    Окнов,
    Кнопкин,
    Пупкин
}


internal class Program
{
    public Array namesM = typeof(NamesM).GetEnumValues();
    public Array namesF = typeof(NamesF).GetEnumValues();
    public Array surnames = typeof(Surnames).GetEnumValues();


    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Array namesM = typeof(NamesM).GetEnumValues();
        Array namesF = typeof(NamesF).GetEnumValues();
        Array surnames = typeof(Surnames).GetEnumValues();

        object obj = new object();
        Random random = new Random();

        School school = new School();
        Kindergarten kindergarten = new Kindergarten();

        kindergarten.GrownNotify += school.Enrollment;

        ConsoleKeyInfo key = new ConsoleKeyInfo();

        PrintGuide();

        string name, surname;

        SearchDelegate searchDelegate = (List<Person> list, string Name, string Surname) =>
        {
            return list.FirstOrDefault(p => p.Name.ToLower() == Name.ToLower() && p.Surname.ToLower() == Surname.ToLower()); 
           
        };

        Task task1 = new Task(Task1);
        task1.Start();


        do
        {
            key = PressKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    {
                        AddKid();
                        break;
                    }

                case ConsoleKey.D2:
                    {
                        if (school.pupils != null && school.pupils.Count != 0)
                        {
                            lock (obj)
                            {
                                try
                                {
                                    name = string.Empty;
                                    surname = string.Empty;

                                    Console.WriteLine("-----------------------------");
                                    Console.WriteLine("Введите имя искомого ученика:");
                                    name = Console.ReadLine();
                                    if (name == string.Empty)
                                    {
                                        throw new ArgumentException();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Введите фамилию искомого ученика:");
                                        surname = Console.ReadLine();
                                        if (surname == string.Empty)
                                        {
                                            throw new ArgumentException();
                                        }
                                        else
                                        {
                                            lock (obj)
                                            {
                                                Person foundPupil = school.Search(searchDelegate, name, surname);

                                                if (foundPupil != null)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                    Console.WriteLine($"{foundPupil.Name} {foundPupil.Surname} учится в школе.");
                                                    Console.ResetColor();
                                                }
                                                else
                                                {
                                                    
                                                }
                                                Console.WriteLine("-----------------------------");
                                                Thread.Sleep(1500);
                                            }
                                        }
                                    }
                                }
                                catch (ArgumentException e)
                                {
                                    Console.WriteLine("Ошибка. Значения не получены. " + e.Message);
                                }
                                break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"В школе нет учеников.");
                            Console.ResetColor();
                            break;
                        }
                    }

                case ConsoleKey.D0:
                    {
                        PrintGuide();
                        break;
                    }

                case ConsoleKey.Escape:
                    {
                        Console.SetCursorPosition(0, Console.CursorTop);
                        Console.WriteLine("1");
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        string bye = "Работа приложения завершена...";
                        for (int i = 0; i < bye.Length; i++)
                        {
                            Console.Write(bye[i]);
                            Thread.Sleep(30);
                        }
                        Console.ResetColor();
                        Thread.Sleep(200);
                        Console.WriteLine();
                        Environment.Exit(0);
                        break;
                    }

                default: break;
            }

        } while (true);

        void AddKid()
        {
            if (random.Next(1, 3) == 1)
                kindergarten.Add(new(((NamesM)namesM.GetValue(random.Next(0, namesM.Length))).ToString(), ((Surnames)surnames.GetValue(random.Next(0, namesM.Length))).ToString(), random.Next(2, 6)));
            else
                kindergarten.Add(new(((NamesF)namesM.GetValue(random.Next(0, namesF.Length))).ToString(), ((Surnames)surnames.GetValue(random.Next(0, namesM.Length))).ToString() + "а", random.Next(2, 6)));
        }

        void Task1()
        {
            while (true)
            {
                Task.Delay(1000).Wait();
                lock (obj)
                {
                    kindergarten.Growing();
                }
            }
        }
    }

    static ConsoleKeyInfo PressKey()
    {
        int cursorLeft = Console.CursorLeft;
        ConsoleKeyInfo key = Console.ReadKey();
        Console.SetCursorPosition(cursorLeft, Console.CursorTop);
        Console.Write(" ");
        Console.SetCursorPosition(cursorLeft, Console.CursorTop);
        return key;
    }

    static void PrintGuide()
    {
        const string Guide =
            "1 - Отправить ребёнка в детский садик\n2 - Поиск ученика\n" +
            "0 - Инструкция\nESC - выход";

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(Guide);
        Console.ResetColor();
    }
}




