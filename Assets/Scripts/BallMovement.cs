using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public float kickForce = 10;
    public float rotationSpeed = 90;
    Rigidbody rb;
    Transform t;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    } // End of Start

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
    }

    private void OnTriggerStay(Collider other) {
        // Check if the player is in range and the player is shooting
        if(other.gameObject.tag == "Player" && other.transform.GetComponent<PlayerMovement>().isShooting) {
            rb.velocity += ((other.transform.forward * kickForce) + (new Vector3(0, 2, 0))); // Update velocity
        }
    } // End of OnCollisionEnter
}
