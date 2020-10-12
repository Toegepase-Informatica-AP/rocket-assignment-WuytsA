using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket2DController : MonoBehaviour
{
    // SerializedField is a qualifier for a variable that makes it public in the Inspector
    // but private in other scripts. On the other hand, public variables can be accessed
    // from other scripts. The default qualifier is private. 
    // Now, we can edit these values in the Inspector. Inspector values will override globally declared
    // values, but will not overload values set in start.
    // For floating point numbers, use 10f not 10 to avoid errors!
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float shipThrust = 100f;

    Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called every 0.02 sec
    void FixedUpdate()
    {

        Thrust();
        Rotate();

    }

    private void Thrust()
    {

        // We calculate the thrust for this frame by multiplying our scalar shipThrust
        // by the change in time from the previous frame. Time.deltaTime is frame independent
        // because it tells us the time since the last time the function was called.
        // Thus, longer frames = more movement, just like we want
        float thrustThisFrame = shipThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            // We scale up our force by the thrust for the frame
            print("Thrusting");
            rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);

        }

    }

    private void Rotate()
    {

        rigidBody.freezeRotation = true; // take manual control of rotation

        // We do the same thing as in thrust
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            print("Rotating left");
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            print("Rotating right");
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control

    }
}
