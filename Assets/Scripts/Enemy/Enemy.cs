//目前功能:在範圍內追蹤敵人
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float attackRange;
    public float speed;
    private Rigidbody2D enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !BtnForEnd.instance.isPause){
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= attackRange){
                Vector3 lookDirection = (player.transform.position - transform.position).normalized;
                transform.Translate(lookDirection * speed * Time.deltaTime);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Restart();
        }
    }
    void OnDrawGizmosSelected()     //在Scene視圖中繪製調試或可視化信息的圖形元素
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void Restart(){
        Debug.Log("Restart");
        SceneManager.LoadScene(05);
    }
}
