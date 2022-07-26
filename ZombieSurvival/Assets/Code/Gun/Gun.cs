using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace RadiantGames.ZombieSurvival
{
    public class Gun : MonoBehaviour
    {
        public string gunName;
        //Gun stats
        [Header("Gun Stats")]
        public int damage;
        public float  spread, reloadTime, fireRate;
        public int magazineSize, bulletsPerTap ;
        public bool isAutomatic ,isEquipped = false;
        int  bulletsShot;
        float nextTimeToFire;
        [HideInInspector] public int ammo;
        [HideInInspector] public bool isReloading;

        //bools 
        bool  isShooting ,  readyToShoot = true;

        //Other variables
        Camera fpsCam;
        GameObject muzzleFlash;
        int bulletRange = 150;

        void Start()
        {
            fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            muzzleFlash = gameObject.transform.Find("Muzzle Flash (2)").gameObject;
            ammo = magazineSize;
        }

        void CheckInput() //Checks for player input 
        {
            if(!isEquipped) { return; }
            if (isAutomatic)
            {
                isShooting = Input.GetMouseButton(0);
            }
            else
            {
                isShooting = Input.GetMouseButtonDown(0);
            }
            // If User Presses Reload Button and is not already reloading and ammo is not already
            // full then we Reload
            if (Input.GetKeyDown(KeyCode.R) && !isReloading && ammo != magazineSize)
            {
                Reload();
            }

            if (isShooting && readyToShoot && !isReloading && ammo > 0)
            {
                Shoot();
            }
        }
        void Update()
        {
            CheckInput();
        }


        void Shoot()
        {
            readyToShoot = false;
            ammo -= bulletsPerTap;

            for (int i = 0; i <= bulletsPerTap; i++)
            { 
                RaycastHit hit;
                Vector3 rayOrigin = fpsCam.transform.position + new Vector3(UnityEngine.Random.Range(-spread, spread), UnityEngine.Random.Range(-spread, spread), 0);
                if (!Physics.Raycast(rayOrigin,fpsCam.transform.forward,out hit, bulletRange)) { continue; };
                if(hit.transform.CompareTag("Enemy")) //If bullet hit enemy then damage enemy
                { 
                    hit.transform.GetComponent<ZombieScript>().TakeDamage(damage);
                    Debug.Log(hit.transform.GetComponent<ZombieScript>().Health);
                }
            }
            muzzleFlash.SetActive(true);
            StartCoroutine(stopMuzzleEffect());
            AudioManager.PlaySound(AudioManager.Instance.AudioList[0]);
            Invoke(nameof(ResetShootState), fireRate);
        }

        void ResetShootState()
        {
            readyToShoot = true;
        }

        void Reload()
        {
            isReloading = true;
            ammo = magazineSize;
            AudioManager.PlaySound(AudioManager.Instance.AudioList[1]);

            Invoke(nameof(ResetReloadState), reloadTime);
        }
        void ResetReloadState()
        {
            isReloading = false;
        }

        IEnumerator stopMuzzleEffect()
        {
            yield return new WaitForSeconds(0.05f);
            muzzleFlash.SetActive(false);
        }

    }

}