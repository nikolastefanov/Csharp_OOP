namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
