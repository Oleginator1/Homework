using Exercise;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Exemplu
{
   
    public class MyClass
    {
        static void Main(string[] args)
        {
           IWorker hworker = new HumanWorker();
           IWorker rworker = new RobotWorker();
           IEat eater = new HumanWorker();
            
           Worker humanWorker = new Worker(hworker);
           Worker robotWorker = new Worker(rworker);
           Eater eater1 = new Eater(eater);

            humanWorker.Working();
            robotWorker.Working();
            eater1.Eating();

        }
      

    }
}
