using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination; // The destination portal
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.transform);
        }
    }
    private void TeleportPlayer(Transform playerTransform)
    {
        playerTransform.position = destination.position;
    }
}
