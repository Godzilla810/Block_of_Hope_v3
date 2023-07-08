using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiracleBlock : MonoBehaviour
{
    private Rigidbody2D currentBlockRb;


    private int wallLayer;
    private int enemyLayer;
    private int playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        currentBlockRb = GetComponent<Rigidbody2D>();

        wallLayer = LayerMask.NameToLayer("Wall");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        playerLayer = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == wallLayer)
        {
            // 方塊碰到牆壁時不穿透，停止方塊的運動
            currentBlockRb.velocity = Vector2.zero;
        }
        else if (collision.gameObject.layer == enemyLayer)
        {
            // 方塊碰到鬼時擊殺鬼，殺死鬼
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == playerLayer && !PlayerController.instance.isHold)
        {
            // 碰到玩家收回
            Debug.Log("Player");
            currentBlockRb.velocity = Vector2.zero; // 清除方塊的速度
            currentBlockRb.angularVelocity = 0f; // 清除方塊的角速度
            transform.position = collision.transform.position;
            transform.SetParent(collision.transform);
            PlayerController.instance.isHold = true;
        }
    }
}