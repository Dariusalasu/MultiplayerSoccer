using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {
    public float rotationSpeed = 1;
    public float force = 700f;
    private bool isWalking = false;
    private bool isRunning = false;
    public bool isShooting = false;
    public bool shouldShoot = false;
    private bool isMoving;
    private float walkingSpeed = 1f;
    private float runningMult = 3f;

    Rigidbody rb;
    Transform t;
    Animator mAnimator;
    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        mAnimator = gameObject.GetComponent<Animator>();
        // t = GetComponent<Transform>();
    } // End of Start

    // Update is called once per frame
    void Update() {
        if(!isLocalPlayer) { return; }
        // Assume character is not moving
        isMoving = false;
        float speed = 0f;

        // Exit Game
        if(Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }

        // Character movement
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) { // Moving Forward
            isRunning = Input.GetKey(KeyCode.LeftShift); // See if shift is pressed meaning character should run
            isWalking = !isRunning; // If running, character is not walking. Otherwise, character is walking
            isMoving = true; // Character is moving

            // Assign speed
            if(isRunning) {
                speed = walkingSpeed*runningMult;
            } else {
                speed = walkingSpeed;
            }
        } else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) { // Moving Backward
            isRunning = Input.GetKey(KeyCode.LeftShift); // See if shift is pressed meaning character should run
            isWalking = !isRunning; // If running, character is not walking. Otherwise, character is walking
            isMoving = true; // Character is moving

            // Assign speed
            if(isRunning) {
                speed = -walkingSpeed*runningMult;
            } else {
                speed = -walkingSpeed;
            }
        }
        rb.position += this.transform.forward * (speed/15);
        
        // Character rotation
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) { // Turn Left
            Quaternion rotate = Quaternion.Euler((new Vector3(0, -1, 0)) * rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotate);
        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) { // Turn Right
            Quaternion rotate = Quaternion.Euler((new Vector3(0, 1, 0)) * rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * rotate);
        }
        
        // Stop animation if character is not moving
        if(!isMoving) {
            isWalking = false;
            isRunning = false;
        }

        // Start animation for character shooting
        if(Input.GetKeyDown(KeyCode.Space) && !isShooting) {
            isWalking = false;
            isRunning = false;
            isShooting = true;
            shouldShoot = true;
            Invoke("stopShooting", 1.1f);
        } else {
            shouldShoot = false;
        }

        // Assign animation booleans
        mAnimator.SetBool("walking", isWalking);
        mAnimator.SetBool("running", isRunning);
        mAnimator.SetBool("shooting", isShooting);
    } // End of Update

    private void stopShooting() {
        isShooting = false;
    } // End of stopShooting
}
