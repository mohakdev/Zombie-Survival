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
        private void Start()
        {
            InitializeStats(10, 100);
        }

        public override void TakeDamage(int Amount)
        {
            base.TakeDamage(Amount);
            Debug.Log(Health);
            OnHealthChanged?.Invoke(Health);
        }
        
    }
}
