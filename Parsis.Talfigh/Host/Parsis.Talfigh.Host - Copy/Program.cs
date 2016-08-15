using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace Parsis.Talfigh.Host
{
    class Program
    {
        static void Main(string[] args)
        {
           new AppHost().Init().Start("http://*:8088/");

           

            Process.Start("http://localhost:8088/");

            Console.ReadLine();
        }
    }
}
