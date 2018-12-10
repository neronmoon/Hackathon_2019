using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Hackathon_2019 {

    public class PlayerMovementController : MonoBehaviour {

        public float Speed = 8f;

        private CharacterController Character;

        private void Start () {
            Character = GetComponent<CharacterController> ();
        }

        void Update () {
            Vector3 direction = new Vector3 (
                Input.GetAxis ("Horizontal"),
                0,
                Input.GetAxis ("Vertical")
            ).normalized;
            if (direction.magnitude > 0) {
                Character.SimpleMove (direction * Speed);

                Quaternion delta = Quaternion.LookRotation (direction);
                transform.rotation = Quaternion.Slerp (transform.rotation, delta, 0.3f);
            }
        }
    }
}
