using MiniCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTen2
{
    public class Worker1 : IWorker
    {
        ILogger Logger { get; set; }

        public Worker1(ILogger logger)
        {
            Logger = logger;
        }

        public void Work()
        {
            Logger.Event("Калькулятор начал работу");
        }
    }

    public class Worker2 : IWorker
    {
        ILogger Logger { get; set; }

        public Worker2(ILogger logger)
        {
            Logger = logger;
        }

        public void Work()
        {
            Logger.Event("Вычисление завершено");
        }
    }
}
