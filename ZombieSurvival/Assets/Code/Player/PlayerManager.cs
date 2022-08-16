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

        ShieldScript shield;
        [SerializeField] int shieldPercent;
        
        private void Awake()
        {
            InitializeStats(12, 100);
            shield = gameObject.GetComponent<ShieldScript>();
        }

        public override void TakeDamage(int amount)
        {
            float totalDamage = amount - shield.ShieldCharacter(amount, shieldPercent);
            base.TakeDamage((int)totalDamage);
            OnHealthChanged?.Invoke(Health); //Invoking a event to update the UI
        }
        
    }
}
