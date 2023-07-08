using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    private Vector3 currentMBPos;
    private Vector3 currentPlayerPos;
    private Vector3 register;
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
                Debug.Log("hi");
                register = currentMBPos;
                Debug.Log(register);
                currentMBPos = currentPlayerPos;
                currentPlayerPos = register;

                transform.position = currentMBPos;
                player.transform.position = currentPlayerPos;
                return;
            }
        }
        
    }
}
