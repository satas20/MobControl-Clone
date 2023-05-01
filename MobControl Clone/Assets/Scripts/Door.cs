using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject runnerPrefab;
    bool hasCollided = false;

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the wall and if we haven't already collided
        if (other.CompareTag("Player") && !hasCollided)
        {
            // Get the player object


            // Clone the player object 3 times
            for (int i = 0; i < 3; i++)
            {
                Instantiate(runnerPrefab, transform.position, Quaternion.identity);
            }

            // Set the flag to true so we don't create any more clones
            hasCollided = true;
        }
    }


}

