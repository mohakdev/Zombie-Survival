using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class manages all the player actions other than Camera and movement
namespace RadiantGames.ZombieSurvival
{
    public class PlayerManager : Character
    {
        public delegate void healthDelegate(int health);
        public event healthDelegate OnHealthChanged;
        private void Awake()
        {
            InitializeStats(12, 100);
        }

        public override void TakeDamage(int Amount)
        {
            base.TakeDamage(Amount);
            OnHealthChanged?.Invoke(Health); //Invoking a event to update the UI
        }
        
    }
}
