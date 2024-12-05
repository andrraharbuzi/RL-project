using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject bearPrefab; // Reference to the bear prefab that will be spawned
    public int respawnTime = 100; // Time interval for bear respawning
    private int step = 0; // Counter to track time between spawns
   
    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if it's time to spawn a bear based on the respawnTime interval
        if (step < respawnTime)
        {
            step++; // Increment the step counter
        }
        else
        {
            // Generate a random X position within the range of -30 to 30
            float xPosition = Random.Range(-30, 30);

            // Spawn a bear at a calculated position with a 180-degree Y rotation
            var bear = Instantiate(bearPrefab, transform.position + new Vector3(xPosition, 0, 0), Quaternion.identity, gameObject.transform);
            bear.transform.Rotate(new Vector3(0, 180, 0)); // Rotate the bear

            Destroy(bear, 7); // Destroy the bear object after 7 seconds
            step = 0; // Reset the step counter for the next spawn interval
        }
    }
}
