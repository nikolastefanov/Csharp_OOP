namespace ViceCity.Models.Players
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViceCity.Models.Players.Contracts;

    public class CivilPlayer : Player,IPlayer
    {
        public CivilPlayer(string name)
            :base(name,50)
        {
            
        }
    }
}
