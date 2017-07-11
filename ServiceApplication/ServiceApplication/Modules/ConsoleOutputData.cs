using System;
using System.Collections.Generic;
using ServiceApplication.Interfaces;

namespace ServiceApplication.Modules
{
    class ConsoleOutputData : IDisplayData
    {
        public void DisplayData(List<string> data)
        {
            try
            {
                foreach (var x in data)
                {
                    Console.WriteLine(x.ToString());
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Error: ConsoleOutputData has recieved an empty dataset.");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
