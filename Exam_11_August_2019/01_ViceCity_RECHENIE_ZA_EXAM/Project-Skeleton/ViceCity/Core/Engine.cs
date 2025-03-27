using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;
using System.Runtime.CompilerServices;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private  IController controller;

     //IController controller=new Controller();


        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();

        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        
                    }
                    else if (input[0] == "AddGun")
                    {
                       // this.writer.WriteLine(this.controller.AddPlayer(input[1]));
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {

                    }
                    else if (input[0] == "Fight")
                    {

                    }            
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
