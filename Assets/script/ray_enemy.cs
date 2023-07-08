using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray_enemy : MonoBehaviour
{
    public float raycastDistance = 100f; // Distance of the raycast
    public LayerMask playerLayer; // Layer mask for the player
    public Transform player;

    private void Update()
    {
        // Cast a ray in the enemy's forward direction
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, raycastDistance, playerLayer);

        // Check if the raycast hits the player
        if (hit.collider != null && hit.collider.CompareTag("player"))
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        // Perform actions to kill the player
        Debug.Log("Player killed!");
        transform.position = player.position;
        // Add your own code here to handle player death, such as reloading the level or showing a game over screen.
    }
  
}
