namespace ViceCity.Models.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViceCity.Models.Players.Contracts;

    public class MainPlayer : Player,IPlayer
    {
        public MainPlayer()
            :base("Tommy Vercetti",100)
        {
        
        }
    }

 
}
