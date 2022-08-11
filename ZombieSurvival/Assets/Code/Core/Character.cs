using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.ZombieSurvival
{
    public class Character : MonoBehaviour
    {
        public int MaxHealth { get; private set; }
        public int Health { get; private set; }
        public int Speed { get; private set; }
        public virtual void TakeDamage(int Amount)
        {
            Health -= Amount;
            if (Health <= 0)
            {
                Die();
            }
        }
        /// <summary>
        /// Heals the Character
        /// </summary>
        /// <param name="percent">Percent of the player health to heal 100% would be complete health</param>
        public void Heal(int percent)
        {
            if (percent > 100)
            {
                Debug.LogWarning("Percent is greater than 100%");
                Health = MaxHealth;
            }
            else
            {
                Health += MaxHealth * percent / 100;
            }
        }
        public virtual void Die()
        {
            //Default Implementation of the method
            Destroy(gameObject);
        }
        public void ChangeSpeed(int NewSpeed)
        {
            Speed = NewSpeed;
        }

        /// <summary>
        /// This is kind of a constructor for the character.
        /// </summary>
        /// <param name="speed">Speed of the character</param>
        /// <param name="maxHealth">Max Health of the character</param>
        public void InitializeStats(int speed, int maxHealth)
        {
            Speed = speed;
            MaxHealth = maxHealth;
            Health = MaxHealth; //This is so that every character always starts with full health
        }
    }
}
