using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RadiantGames.ZombieSurvival
{
    public class PlayerMovement : MonoBehaviour
    {
        CharacterController controller;
        public int speed;

        public float jumpHeight = 3f;
        public float gravity = -9.81f;
        Vector3 Velocity;
        private void Start()
        {
            PlayerManager player = GetComponent<PlayerManager>();
            speed = player.Speed;
        }
        void Update()
        {
            controller = GetComponent<CharacterController>();
            if (controller.isGrounded && Velocity.y < 0)
            {
                Velocity.y = -2f; //This is just to cancel any gravity applied on the player while on ground
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            Velocity.y += gravity * Time.deltaTime;
            move = speed * Time.deltaTime * move;
            move.y = Velocity.y * Time.deltaTime;
            controller.Move(move);

            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                Velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
    }
}