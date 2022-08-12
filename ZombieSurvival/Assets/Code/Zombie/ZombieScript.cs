using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.ZombieSurvival
{
    public class ZombieScript : MonoBehaviour
    {
        GameObject player;
        PlayerManager playerScript;
        Animator zombieAnim;
        [SerializeField] int walkSpeed;
        [SerializeField] int damage;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerScript = player.GetComponent<PlayerManager>();
            zombieAnim = GetComponent<Animator>();
            zombieAnim.SetFloat("MoveSpeed", walkSpeed);
        }
        void Update()
        {
            transform.LookAt(player.transform);
            transform.Translate(Time.deltaTime * walkSpeed * Vector3.forward);
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                zombieAnim.SetBool("Attack", true);
                playerScript.TakeDamage(damage);
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                zombieAnim.SetBool("Attack", false);
            }
        }
    }
}
