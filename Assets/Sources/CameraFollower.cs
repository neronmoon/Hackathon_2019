using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public Transform Target;

    void Update () {
        transform.position = Vector3.Lerp (transform.position, Target.position, 0.3f);
    }
}
