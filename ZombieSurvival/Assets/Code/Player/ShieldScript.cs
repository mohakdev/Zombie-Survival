using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.ZombieSurvival
{
    public class ShieldScript : MonoBehaviour
    {
        /// <summary>
        /// Shields a character by supressing the damage taken
        /// </summary>
        /// <param name="damage">damage taken by the player</param>
        /// <param name="maxHealth">Character's max health</param>
        /// <param name="suppressPercent">Percent by which take damage is suppressed</param>
        /// <returns>the suppressed damage</returns>
        public float ShieldCharacter(float damage,float suppressPercent)
        {
            float value = damage / 100 * suppressPercent;
            return value;
        }
    }
}
