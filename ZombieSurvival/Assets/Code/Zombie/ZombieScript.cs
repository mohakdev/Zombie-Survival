using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.ZombieSurvival
{
    public class ZombieScript : MonoBehaviour
    {
        GameObject player;
        Animator zombieAnim;
        [SerializeField] int walkSpeed;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            zombieAnim = GetComponent<Animator>();
            zombieAnim.SetFloat("MoveSpeed", walkSpeed);
        }
        void Update()
        {
            transform.LookAt(player.transform);
            transform.Translate(Time.deltaTime * walkSpeed * Vector3.forward);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                player.GetComponent<PlayerManager>().TakeDamage(10);
                Debug.Log("Damage registered");
            }
        }
    }
}
