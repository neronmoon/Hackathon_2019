using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Velocity = 200f;

    void FixedUpdate () {
        Rigidbody rb = GetComponent<Rigidbody> ();
        if (Input.GetMouseButton (0)) {
            Vector3 direction = getMovementDirection ();
            rb.velocity = direction * Velocity * Time.deltaTime;
            Quaternion delta = Quaternion.LookRotation (direction);
            transform.rotation = Quaternion.Slerp (transform.rotation, delta, 0.3f);
        } else {
            rb.velocity = Vector3.zero;
        }
    }

    private Vector3 getMovementDirection () {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit)) {
            Vector3 point = hit.point;
            point.y = transform.position.y;
            return (point - transform.position).normalized;
        }

        return Vector3.zero;
    }
}
