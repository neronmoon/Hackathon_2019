using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float Speed = 5f;

    private CharacterController Character;

    private void Start() {
        Character = GetComponent<CharacterController>();
    }

    void Update () {
        if (Input.GetMouseButton (0)) {
            Vector3 direction = getMovementDirection();
            Character.SimpleMove(direction * Speed);

            Quaternion delta = Quaternion.LookRotation (direction);
            transform.rotation = Quaternion.Slerp (transform.rotation, delta, 0.3f);
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
