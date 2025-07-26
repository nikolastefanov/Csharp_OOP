namespace MXGP.Models.Riders.Contracts
{
    using Motorcycles.Contracts;
    using MXGP.Models.Motorcycles;

    public interface IRider
    {
        string Name { get; }

        Motorcycle Motorcycle { get; }

        int NumberOfWins { get; }

        bool CanParticipate { get; }

        void WinRace();

        void AddMotorcycle(Motorcycle motorcycle);
    }
}