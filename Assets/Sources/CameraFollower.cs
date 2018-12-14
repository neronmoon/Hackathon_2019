using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Project_Hackathon_2019 {
    public class CameraFollower : MonoBehaviour {

        [Required]
        public Transform Target;
        public float SmoothTime = 0.3F;
        private Vector3 velocity = Vector3.zero;

        void LateUpdate () {

            transform.position = Vector3.SmoothDamp (transform.position, Target.position, ref velocity, SmoothTime);
        }
    }
}
