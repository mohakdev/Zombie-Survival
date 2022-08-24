using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace RadiantGames.ZombieSurvival
{
    public class ItemManager : MonoBehaviour
    {
        [SerializeField] Text hintText;
        [SerializeField] GameObject itemManager;
        GameObject objectToPick;

        bool isNear;
        void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("PickObject")) { return; }

            isNear = true;
            hintText.text = "Press F to Pick";
            objectToPick = other.gameObject;
        }
        void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("PickObject")) { return; }

            isNear = false;
            hintText.text = "";

        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && isNear)
            {
                objectToPick.transform.SetParent(itemManager.transform);
                objectToPick.transform.localPosition = new Vector3(0.38f, 0.45f, 0.5f);
                //objectToPick.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}
