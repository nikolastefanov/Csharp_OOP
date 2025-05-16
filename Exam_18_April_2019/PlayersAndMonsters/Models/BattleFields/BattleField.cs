namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.DeadPlayer);
            }
            if (attackPlayer is Beginner)
            {
                attackPlayer.Health += 40;

                foreach (ICard card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            if (enemyPlayer is Beginner)
            {
                enemyPlayer.Health += 40;
                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            int attackPlayerDamage = attackPlayer
                .CardRepository
                .Cards
                .Sum(c => c.DamagePoints);

            int enemyPlayerDamage = enemyPlayer
                .CardRepository
                .Cards
                .Sum(c => c.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
