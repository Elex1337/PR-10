using System;
using System.Collections;
interface IPart
{
    void Build();
}
interface IWorker
{
    void Work(House house);
}
class Basement : IPart
{
    public void Build()
    {
        Console.WriteLine("Фундамент сделан ");
    }
}
class Walls : IPart
{
    public void Build()
    {
        Console.WriteLine("Стены построены ");
    }
}
class Door : IPart
{
    public void Build()
    {
        Console.WriteLine("Дверь установлена ");
    }
}
class Window : IPart
{
    public void Build()
    {
        Console.WriteLine("Окно установлено");
    }
}

class Roof : IPart
{
    public void Build()
    {
        Console.WriteLine("Крыша построена");
    }
}

class House
{
    public List<IPart> parts = new List<IPart>();
    public void AddPart(IPart part)
    {
        parts.Add(part);
    }
    public void Show()
    {
        Console.WriteLine("Дом построен");
        foreach (var part in parts)
        {
            part.Build();
        }
    }
}
class Worker : IWorker
{
    public void Work(House house)
    {
        Console.WriteLine("Строитель работает:");
        house.AddPart(new Basement());
        house.AddPart(new Walls());
        house.AddPart(new Walls());
        house.AddPart(new Walls());
        house.AddPart(new Walls());
        house.AddPart(new Door());
        house.AddPart(new Window());
        house.AddPart(new Window());
        house.AddPart(new Window());
        house.AddPart(new Window());
        house.AddPart(new Roof());
    }
}
class Team
{
    private List<IWorker> workers = new List<IWorker>();

    public void AddWorker(IWorker worker)
    {
        workers.Add(worker);
    }

    public void StartBuilding(House house)
    {
        foreach (var worker in workers)
        {
            worker.Work(house);
        }
    }
}
class TeamLeader : IWorker
{
    public void Work(House house)
    {
        Console.WriteLine("Бригадир проверяет работу:");
        house.Show();
    }
}

class Program
{
    static void Main()
    {
        House house = new House();
        Team team = new Team();
        team.AddWorker(new Worker());
        team.AddWorker(new Worker());
        team.AddWorker(new Worker());
        team.AddWorker(new TeamLeader());
        team.StartBuilding(house);
        house.Show();
        DisplayHouseArt();
        static void DisplayHouseArt()
        {
            Console.WriteLine("\nРисунок дома:");

            Console.WriteLine("   _______");
            Console.WriteLine("  /       \\");
            Console.WriteLine(" /_________\\");
            Console.WriteLine(" |    _    |");
            Console.WriteLine(" |[] | | []|");
            Console.WriteLine(" |   | |   |");
        }
    }
}
