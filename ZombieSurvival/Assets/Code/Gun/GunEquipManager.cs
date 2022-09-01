using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace RadiantGames.ZombieSurvival
{
    public class GunEquipManager : MonoBehaviour
    {
        [SerializeField] Text hintText;
        [SerializeField] GameObject itemManager;
        GameObject nearColliderObj; //This is the gameobject which has the near collider which checks player is near
        GameObject gunEquipped;
        Gun gunScript;

        bool isNear;
        void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("GunNearCollider")) { return; }

            isNear = true;
            hintText.text = "Press F to Pick";
            nearColliderObj = other.gameObject;
        }
        void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("GunNearCollider")) { return; }
            isNear = false;
            hintText.text = "";
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && isNear) //If player wants to pick a gun
            {
                EquipGun();
            }
            if (Input.GetKeyDown(KeyCode.G) && gunEquipped != null)
            {
                DropGun();
            }
        }
        void EquipGun()
        {
            if (gunEquipped != null) //If Player already has a gun we need to drop it first
            {
                DropGun();
            }
            gunEquipped = nearColliderObj.transform.parent.gameObject;
            gunScript = gunEquipped.GetComponent<Gun>();

            hintText.text = "";
            if (gunEquipped.GetComponent<Rigidbody>() != null)
            {
                gunEquipped.GetComponent<Rigidbody>().isKinematic = true;
            }
            nearColliderObj.tag = "Untagged";
            gunScript.isEquipped = true; //Letting the gun know that it is equipped

            gunEquipped.transform.SetParent(itemManager.transform);
            gunEquipped.transform.localPosition = new Vector3(0.38f, 0.45f, 0.5f);
            gunEquipped.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        void DropGun()
        {
            gunEquipped.transform.parent = null;
            if (gunEquipped.GetComponent<Rigidbody>() != null)
            {
                gunEquipped.GetComponent<Rigidbody>().isKinematic = false;
            }
            gunScript.isEquipped = false; //Letting the gun know that it is unequipped
            nearColliderObj.tag = "GunNearCollider";
        }

    }
}
