using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RadiantGames.ZombieSurvival
{
    public class GunUI : MonoBehaviour
    {
        [SerializeField] GameObject gunBackpack;
        [SerializeField] Text gunName;
        [SerializeField] Text gunInfo;


        void Update()
        {
            if(gunBackpack.transform.childCount.Equals(0)) { return; }
            Gun gunEquipped = gunBackpack.transform.GetChild(0).GetComponent<Gun>();

            gunName.text = gunEquipped.gunName;
            if (gunEquipped.isReloading)
            {
                gunInfo.text = "Reloading...";
            }
            else
            {
                gunInfo.text = $"{gunEquipped.ammo} / {gunEquipped.magazineSize}";
            }
        }
    }
}
