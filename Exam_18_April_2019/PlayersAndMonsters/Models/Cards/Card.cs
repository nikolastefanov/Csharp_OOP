namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name,int damagePoints,int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidCardName);
                }
                this.Name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                if (value<0)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidCardDamagePoints);
                }
                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.damagePoints;
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException(
                        ExceptionMessages.InvalidCardHealthPoints);
                }
                this.healthPoints = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                ConstantMessages.CardReportInfo,
                this.Name,
                this.DamagePoints);
        }

    }
}
