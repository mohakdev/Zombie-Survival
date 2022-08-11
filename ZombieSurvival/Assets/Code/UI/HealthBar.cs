using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace RadiantGames.ZombieSurvival
{
    public class HealthBar : MonoBehaviour
    {
        PlayerManager player;
        Slider healthSlider;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
            healthSlider = GetComponent<Slider>();
            player.OnHealthChanged += Player_OnHealthChanged;
        }

        private void Player_OnHealthChanged(int health)
        {
            healthSlider.value = health;
        }
    }
}
