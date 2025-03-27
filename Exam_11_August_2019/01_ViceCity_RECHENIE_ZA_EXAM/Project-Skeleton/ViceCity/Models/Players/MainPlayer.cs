using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string InitializeMainPlayr = "Tommy Vercetti";
        private const int InitializeLifePoints = 100;
        public MainPlayer()
            : base(InitializeMainPlayr, InitializeLifePoints)
        {
        }
    }
}
