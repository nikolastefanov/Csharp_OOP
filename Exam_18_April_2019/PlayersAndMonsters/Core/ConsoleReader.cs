namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ConsoleReader: IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
