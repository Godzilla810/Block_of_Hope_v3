using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mblock_move : MonoBehaviour
{
    public float speed = 40.0f;
    public bool isMove = false;
    // public GameObject spawnPoint;
    private bool following=true;
    private Vector3 spawnDir;
    public Transform player;
    private Vector3 dist = new Vector3(1f,0f,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 當左鍵點擊時
        {
            following=false;
            isMove = true;
            Vector3 targetPosition = GetMouseWorldPosition(); // 獲取滑鼠點擊位置
            spawnDir = (targetPosition - player.position).normalized;
        }
        else if (Input.GetMouseButtonDown(1)) // 當右鍵點擊時
        {
            following=true;
            isMove = true;
            Vector3 targetPosition = player.position;
            spawnDir = (targetPosition - transform.position).normalized;
            if (transform.position == targetPosition){
                Destroy(gameObject);
            }
            
        }
        if(isMove){
            transform.Translate(spawnDir * speed * Time.deltaTime);
        }
        if(following){
            transform.position = player.transform.position + dist;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    void OnCollisionEnter2D(Collision2D other){
        isMove = false;
    }

}