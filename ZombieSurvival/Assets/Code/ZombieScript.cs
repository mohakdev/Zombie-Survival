using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
    }
}
