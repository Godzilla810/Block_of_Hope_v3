using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Vector3 currentMBPos;
    private Vector3 currentPlayerPos;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        if (player != null){
            currentMBPos = transform.position;
            currentPlayerPos = player.transform.position;
            if (Input.GetMouseButtonDown(1)) // 當右鍵點擊時
            {
                currentPlayerPos = currentMBPos;
                player.transform.position = currentPlayerPos;
                return;
            }
        }
        
    }
}
