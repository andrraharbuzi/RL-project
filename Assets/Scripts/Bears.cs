    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Bears : MonoBehaviour
    {
    public float speed = 20.0f; // Speed variable for the bear's movement
    private Rigidbody rb; // Reference to the Rigidbody component attached to this GameObject
    
    void Update()
    {
        rb = this.GetComponent<Rigidbody>(); // Fetch the Rigidbody component of this GameObject
        rb.velocity = new Vector3(0, 0, -speed); // Set the velocity to move the bear downwards on the Z-axis
    }
    }