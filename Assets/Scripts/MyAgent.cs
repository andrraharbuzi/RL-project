
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class MyAgent : Agent
{
    Rigidbody m_rigidbody;
    float m_speed = 20;

    public GameObject Spawner; // Reference to the GameObject that acts as the spawner

    private Vector3 startingPosition = new Vector3(162.3f, 0.0f, -1407.01f); // Starting position of the agent

    private float boundXLeft = -20f; // Left boundary for the agent's movement
    private float boundXRight = 20f; // Right boundary for the agent's movement

    private enum ACTIONS // Actions that the agent can take
    {
        LEFT = 0,
        NOTHING = 1,
        RIGHT = 2
    }

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>(); // Get the Rigidbody component of this GameObject
    }

    public override void OnEpisodeBegin()
    {
        // We reset the agent's position to the starting position at the beginning of each episode
        transform.localPosition = startingPosition;
    }
    

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // Heuristic method to enable manual control of the agent for testing purposes

        ActionSegment<int> actions = actionsOut.DiscreteActions;

        var horizontal = Input.GetAxisRaw("Horizontal"); // Get input from the Horizontal axis (e.g., arrow keys)
        var vertical = Input.GetAxisRaw("Vertical"); // Get input from the Vertical axis

        if (horizontal == -1)
        {
            actions[0] = (int)ACTIONS.LEFT; // Set action to move left if input is -1 (left arrow)
        }
        else if (horizontal == +1)
        {
            actions[0] = (int)ACTIONS.RIGHT; // Set action to move right if input is +1 (right arrow)
        }
        else
        {
            actions[0] = (int)ACTIONS.NOTHING; // Set action to do nothing if no horizontal input
        }

    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        // Actions executed by the agent based on the received action

        var actionTaken = actions.DiscreteActions[0]; // Get the action taken

        switch (actionTaken)
        {
            case (int)ACTIONS.NOTHING:
                break; // Do nothing
            case (int)ACTIONS.LEFT:
                // Move the agent's body to the left if it can move left within the defined boundary
                if (transform.localPosition.x > boundXLeft)
                    transform.Translate(-Vector3.right * m_speed * Time.deltaTime);
                else
                {
                    AddReward(-1); // Decrease reward for hitting the boundary
                    EndEpisode(); // End the episode
                }
                break;
            case (int)ACTIONS.RIGHT:
                // Move the agent's body to the right if it can move right within the defined boundary
                if (transform.localPosition.x > boundXRight)
                    transform.Translate(Vector3.right * m_speed * Time.deltaTime);
                else
                {
                    AddReward(-1); // Decrease reward for hitting the boundary
                    EndEpisode(); // End the episode
                }
                break;
        }

        AddReward(0.1f); // Add a small positive reward after each action
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the agent collided with a bear, we delete the bears & end the episode
        if (other.tag == "Bear")
        {
            // Delete each bear object spawned by the spawner
            var parent = Spawner.transform;
            int numberOfChildren = parent.childCount;

            for (int i = 0; i < numberOfChildren; i++)
            {
                if (parent.GetChild(i).tag == "Bear ")
                {
                    Destroy(parent.GetChild(i).gameObject);
                }
            }
            AddReward(-0.5f); // Add a negative reward for hitting the bear
            EndEpisode(); // End the episode
        }
    }

}
