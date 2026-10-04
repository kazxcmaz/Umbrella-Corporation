using System;
using System.IO;
using System.Collections.Generic;
List<Scientists> scientist = new List<Scientists>();  

if (File.Exists("Scientist.txt"))
{
    string[] lines = File.ReadAllLines("Scientist.txt");
    foreach (string line in lines)
    {
        string[] parts = line.Split('|');
        Scientists s = new Scientists();
        s.Name = parts[0];
        s.Lastname = parts[1];
        s.Age = int.Parse(parts[2]);
        s.Post = parts[3];
        s.HighAccess = parts[4] == "1";
        scientist.Add(s);
    }
}
List<Projects> projet = new List<Projects>();
if (File.Exists("Projects.txt"))
{
    string[] lines = File.ReadAllLines("Projects.txt");
    foreach (string line in lines)
    {
        string[] parts2 = line.Split('|');
        Projects p = new Projects();
        p.NameProject = parts2[0];
        p.Structure = parts2[1];
        p.Location = parts2[2];
        p.DescriptionProject = parts2[3];
        projet.Add(p);
    }
}

void Save()
{
    List<string> lines = new List<string>();
    foreach (Scientists sci in scientist)
    {
        string access = sci.HighAccess ? "1" : "0";
        lines.Add($"{sci.Name}|{sci.Lastname}|{sci.Age}|{sci.Post}|{access}");
    }
    File.WriteAllLines("Scientist.txt", lines);
}
void Save2()
{
    List<string> lines2 = new List<string>();
    foreach (Projects pro in projet)
    {
        lines2.Add($"{pro.NameProject}|{pro.Structure}|{pro.Location}|{pro.DescriptionProject}");
    }
    File.WriteAllLines("Projects.txt", lines2);
}


int mainChoice;
while (true)
{
    Console.WriteLine("=== Umbrella Corporation ===");
    Console.WriteLine("1. Учённые");
    Console.WriteLine("2. Проекты");
    Console.WriteLine("3. Выход");
    if (int.TryParse(Console.ReadLine(), out mainChoice))
    {
        if (mainChoice <= 3 && mainChoice >= 1)
        {
            int subChoice;
            switch (mainChoice)
            {
                case 1:
                    {
                        while (true)
                        {
                            Console.WriteLine("=== Учённые ===");
                            Console.WriteLine("1. Список");
                            Console.WriteLine("2. Должности");
                            Console.WriteLine("3. Выход в меню");
                            if (int.TryParse(Console.ReadLine(), out subChoice))
                            {
                                switch (subChoice)
                                {
                                    case 1:
                                        {
                                            int subChoice2;
                                            while (true)
                                            {
                                                Console.WriteLine("=== Список учённых ===");
                                                if (scientist.Count == 0)
                                                {
                                                    Console.WriteLine("Список пуст");
                                                }
                                                else
                                                {
                                                    for (int i = 0; i < scientist.Count; i++)
                                                    {
                                                        Console.WriteLine($"{i + 1}. {scientist[i].Name} {scientist[i].Lastname } | Возраст: {scientist[i].Age} | Должность: {scientist[i].Post}");
                                                    }
                                                }
                                                Console.WriteLine("_________________________");
                                                Console.WriteLine("1. Добавить Учённого");
                                                Console.WriteLine("2. Удалить Учённого");
                                                Console.WriteLine("3. Назад");
                                                if (int.TryParse(Console.ReadLine(), out subChoice2))
                                                {
                                                    switch (subChoice2)
                                                    {
                                                        case 1:
                                                            {
                                                                Console.Write("Имя: ");
                                                                string name = Console.ReadLine();
                                                                Console.Write("Фамилия: ");
                                                                string lastname = Console.ReadLine();
                                                                Console.Write("Возраст: ");
                                                                int age = int.Parse(Console.ReadLine());
                                                                Console.Write("Должность: ");
                                                                string post = Console.ReadLine();
                                                                Console.Write("Доступ (да/нет): ");
                                                                bool access = Console.ReadLine() == "да";
                                                                
                                                                Scientists NewSci = new Scientists();
                                                                NewSci.Name = name;
                                                                NewSci.Lastname = lastname;
                                                                NewSci.Age = age;
                                                                NewSci.Post = post;
                                                                NewSci.HighAccess = access;

                                                                scientist.Add(NewSci);
                                                                Console.WriteLine("Добавлен");
                                                                Save();
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (scientist.Count == 0)
                                                                {
                                                                    Console.WriteLine("Список пуст");
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("=== Список учённых ===");
                                                                    for (int i = 0; i < scientist.Count; i++)
                                                                    {
                                                                        Console.WriteLine($"{i + 1}. {scientist[i].Name} {scientist[i].Lastname} | Возраст: {scientist[i].Age} | Должность: {scientist[i].Post}");
                                                                    }
                                                                    Console.WriteLine("_________________________");
                                                                    Console.Write("Введите номер: ");
                                                                    if (int.TryParse(Console.ReadLine(), out int numberremove) && numberremove > 0 && numberremove <= scientist.Count)
                                                                    {
                                                                        scientist.RemoveAt(numberremove - 1);
                                                                        Console.WriteLine("Удален");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Ошибка");
                                                                    }
                                                                    Save();
                                                                }
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                Console.WriteLine("Ошибка");
                                                                break;
                                                            }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Ошибка");
                                                }
                                                if (subChoice2 == 3) break;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            while(true)
                                            {
                                                int subchoice3;
                                                if (scientist.Count == 0)
                                                {
                                                    Console.WriteLine("Список пуст");
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("=== Должности ===");
                                                    for (int i = 0; i < scientist.Count; i++)
                                                    {
                                                        Console.WriteLine($"{i + 1}. {scientist[i].Post}");
                                                    }
                                                    Console.WriteLine("_________________________");
                                                    Console.WriteLine("1. Назад");
                                                    if (int.TryParse(Console.ReadLine(),out subchoice3))
                                                    {
                                                        if (subchoice3 == 1) break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Ошибка");
                                                    }
                                                    break;
                                                }

                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Ошибка, выберите из списка");
                                            break;
                                        }
                                }
                            }
                            if (subChoice == 3) break;
                        }
                        break;
                    }
                case 2:
                    {
                        while (true)
                        {
                            Console.WriteLine("=== Проекты ===");
                            Console.WriteLine("1. Список");
                            Console.WriteLine("2. Лаборатории");
                            Console.WriteLine("3. Выход в меню");
                            if (int.TryParse(Console.ReadLine(), out subChoice))
                            {
                                switch (subChoice)
                                {
                                    case 1:
                                        {
                                            if (projet.Count == 0)
                                            {
                                                Console.WriteLine("Отсутствует список");
                                                Console.Write("Название проекта: ");
                                                string namepro = Console.ReadLine();
                                                Console.Write("Количество участников: ");
                                                string structure = Console.ReadLine();
                                                Console.Write("Локация: ");
                                                string locate = Console.ReadLine();
                                                Console.Write("Описание: ");
                                                string description = Console.ReadLine();
                                                Console.WriteLine("Проект создан");

                                                Projects NewPro = new Projects();
                                                NewPro.NameProject = namepro;
                                                NewPro.Structure = structure;
                                                NewPro.Location = locate;
                                                NewPro.DescriptionProject = description;

                                                projet.Add(NewPro);
                                                Save2();
                                                break;

                                            }
                                            else
                                            {
                                                int subChoice4;
                                                while (true)
                                                {
                                                    Console.WriteLine("=== Список ===");
                                                    for (int i = 0; i < projet.Count; i++)
                                                    {
                                                        Console.WriteLine($"{i + 1}. Проект: {projet[i].NameProject} | Участников: {projet[i].Structure} | {projet[i].Location} | {projet[i].DescriptionProject}");
                                                    }
                                                    Console.WriteLine("1. Создать проект");
                                                    Console.WriteLine("2. Удалить проект");
                                                    Console.WriteLine("3. Назад");
                                                    if (int.TryParse(Console.ReadLine(), out subChoice4))
                                                    {
                                                        switch (subChoice4)
                                                        {
                                                            case 1:
                                                                {
                                                                    Console.Write("Название проекта: ");
                                                                    string namepro = Console.ReadLine();
                                                                    Console.Write("Количество участников: ");
                                                                    string structure = Console.ReadLine();
                                                                    Console.Write("Локация: ");
                                                                    string locate = Console.ReadLine();
                                                                    Console.Write("Описание: ");
                                                                    string description = Console.ReadLine();
                                                                    Console.WriteLine("Проект создан");

                                                                    Projects NewPro = new Projects();
                                                                    NewPro.NameProject = namepro;
                                                                    NewPro.Structure = structure;
                                                                    NewPro.Location = locate;
                                                                    NewPro.DescriptionProject = description;

                                                                    projet.Add(NewPro);
                                                                    Save2();
                                                                    break;
                                                                }
                                                            case 2:
                                                                {
                                                                    Console.Write("Введите номер проекта: ");
                                                                    if (int.TryParse(Console.ReadLine(), out int numberpolz) && projet.Count >= numberpolz && numberpolz != 0)
                                                                    {
                                                                        projet.RemoveAt(numberpolz - 1);
                                                                        Console.WriteLine("Удалено");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Ошибка");
                                                                    }
                                                                    Save2();
                                                                    break;
                                                                }
                                                            case 3:
                                                                {
                                                                    break;
                                                                }
                                                            default:
                                                                {
                                                                    Console.WriteLine("Ошибка");
                                                                    break;
                                                                }
                                                        }
                                                        if (subChoice4 == 3) break;
                                                    }
                                                    else
                                                    {
                                                                    Console.WriteLine("Ошибка");
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (projet.Count == 0)
                                            {
                                                Console.WriteLine("Отсутствует список");
                                            }
                                            else
                                            {
                                                Console.WriteLine("=== Лаборатории ===");
                                                for (int i = 0; i < projet.Count; i++)
                                                {
                                                    Console.WriteLine($"{i + 1}. {projet[i].Location}");
                                                }
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Ошибка, выберите из списка");
                                            break;
                                        }
                                }
                            }
                            if (subChoice == 3) break;
                        }
                        break;
                    }
            }
        }
        else
        {
            Console.WriteLine("Не корректное число, выберите из списка");
        }
    }
    else
    {
        Console.WriteLine("Введите число");
    }
    if (mainChoice == 3) break;
}
class Scientists
{
    public int Age;
    public string Name;
    public string Lastname;
    public bool HighAccess;
    public string Post;

}
class Projects
{
    public string NameProject;
    public string Location;
    public string Structure;
    public string DescriptionProject;
}