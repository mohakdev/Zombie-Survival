using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RadiantGames.ZombieSurvival
{
    public class PlayerMovement : MonoBehaviour
    {
        CharacterController controller;
        public float speed;

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
                Velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * Time.deltaTime * speed);



            Velocity.y += gravity * Time.deltaTime;
            controller.Move(Velocity * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                Velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
    }
}