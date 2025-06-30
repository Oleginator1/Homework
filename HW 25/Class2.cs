using System;
using System.Collections.Generic;


public interface IWorker
{
    void Work();    
}

public interface IEat
{
    void Eat();
}


public class HumanWorker : IWorker, IEat
{
    public void Work()
    {
        Console.WriteLine("Human working...");
    }


    public void Eat()
    {
        Console.WriteLine("Human eating...");
    }
}


public class RobotWorker : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot working...");
    }
}


public class Worker
{
    private readonly IWorker worker;
    
    public Worker(IWorker worker)
    {
        this.worker = worker; 
    }
    
    public void Working()
    {
        worker.Work();
    }
}

public class Eater
{
    private readonly IEat worker;

    public Eater(IEat worker)
    {
        this.worker = worker;
    }

    public void Eating()
    {
        worker.Eat();
    }
}