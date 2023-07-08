using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiracleBlock : MonoBehaviour
{
    private Rigidbody2D currentBlockRb;
    public SpriteRenderer spriteRenderer;

    private int wallLayer;
    private int enemyLayer;
    private int playerLayer;
    private int bossLayer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentBlockRb = GetComponent<Rigidbody2D>();

        wallLayer = LayerMask.NameToLayer("Wall");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        playerLayer = LayerMask.NameToLayer("Player");
        bossLayer = LayerMask.NameToLayer("Boss");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //碰牆
        if (collision.gameObject.layer == wallLayer)
        {
            //停止運動
            currentBlockRb.velocity = Vector2.zero;
        }
        //碰敵人
        else if (collision.gameObject.layer == enemyLayer)
        {
            // 擊殺
            Destroy(collision.gameObject);
        }
        //碰玩家
        else if (collision.gameObject.layer == playerLayer)
        {
            //收回
            currentBlockRb.velocity = Vector2.zero; // 清除方塊的速度
            currentBlockRb.angularVelocity = 0f; // 清除方塊的角速度
            transform.position = collision.transform.position;
            transform.SetParent(collision.transform); //跟隨玩家
            PlayerController.instance.isHold = true;
            spriteRenderer.color = new Color(0, 0, 0, 0);
        }
        //碰boss
        else if (collision.gameObject.layer == bossLayer)
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Dmg");
            Boss.instance.dmgCount++;
        }
    }

    // public void PullStatus(){
    //     spriteRenderer.color = transparent;
    // }
    // public void ShootStatus(){
    //     spriteRenderer.color = originalColor;
    // }
}