using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // identify player object
    private Transform playerTransform;

    public int EnemyMoveSpeed = 20;
    int MaxDist = 10;
    int MinDist = 5;


    private void Start()
    {
        // Find the player GameObject with the "Player" tag
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            // Access the player's transform
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene with the 'Player' tag!");
        }
    }


    private void Update()
    {
        // You can now use playerTransform to do whatever you need with the player's transform
        if (playerTransform != null)
        {
            // Example: Rotate the prefab towards the player
            transform.LookAt(playerTransform);

            if (Vector3.Distance(transform.position, playerTransform.position) >= MinDist)
            {
                transform.position += transform.forward * EnemyMoveSpeed * Time.deltaTime;
                if (Vector3.Distance(transform.position, playerTransform.position) <= MaxDist)
                {
                    //Here Call any function U want Like Shoot at here or something
                }

            }
        }
    }
}

