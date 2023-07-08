using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_folloe : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform component
    public float newFOV = 120f; // Desired FOV value
    private Camera cameraComponent; // Reference to the Camera component


    // Start is called before the first frame update

    private void Start()
    {
        transform.position = player.position;
        cameraComponent = GetComponent<Camera>();
        cameraComponent.fieldOfView = newFOV;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null){
            transform.position = player.position;
        }
    }

}
