namespace SantaWorkshop.Models.Instrument.Contracts
{
    using System;

    public interface IInstrument
    {
        int Power { get; }

        void Use();

        bool IsBroken();
    }
}
