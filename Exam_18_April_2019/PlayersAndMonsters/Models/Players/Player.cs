namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository,
            string username,int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }
        public ICardRepository CardRepository
        { get; private set; }

        public string Username
        {
            get => this.username;
           private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidUserName);
                }
                this.username = value;
            }
        }
            

        public int Health
        {
            get => this.health;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidUserHealth);
                }
                this.health = value;
            }
        }

        public bool IsDead
        {
            get { return this.Health <= 0; }
        }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints<0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidDamagePoints);
            }
            int newHealth = this.Health - damagePoints;
            if (newHealth<0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health = newHealth;
            }
        }

        public override string ToString()
        {
            return string.Format(
                ConstantMessages.PlayerReportInfo,
                this.Username,
                this.Health,
                this.CardRepository.Count);
        }
    }
}
