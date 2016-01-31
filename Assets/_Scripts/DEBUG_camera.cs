using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DEBUG_camera : MonoBehaviour {

    private float pitch;
    private float yaw;

    void Start() {
        pitch = 0;
        yaw = 0;
    }

    void Update() {
        yaw += Input.GetAxis("Yaw");
        pitch += Input.GetAxis("Pitch");
    }

    void FixedUpdate() {
        transform.rotation = Quaternion.Euler(transform.rotation.x + pitch * 2, transform.rotation.y + yaw * 2, 0);
    }
}
