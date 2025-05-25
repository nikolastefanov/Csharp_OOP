using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        public string Name => throw new NotImplementedException();

        public string Species => throw new NotImplementedException();

        public int Size => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();

        public void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
