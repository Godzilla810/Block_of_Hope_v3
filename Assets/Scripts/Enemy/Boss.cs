using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// press "O" to kill boss instantly, press "I" to damage boss
public class Boss : MonoBehaviour
{
    //實例化
    public static Boss instance;
    void Awake() {
        if (instance != null){
            return;
        }
        instance = this;
    }

    private Animator animator;
    private int hp;
    public int dmgCount;
    private int dieCount;

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;     // Prefab of the enemy to be generated
    
    private void Start()
    {
        hp = 5;
        animator = GetComponent<Animator>();
        dmgCount=0;
        dieCount=0;
    }

    private void Update()
    {
        // Check for player input to switch between animator states
        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger("Talk");
        }
        else if (dmgCount == hp)
        {
            Die();
        }
    } 
    public void Die(){
        animator.SetTrigger("Die");
        dmgCount=0;
        dieCount++;
        if(dieCount==4){
            StartCoroutine(DestroyBossWithDelay());
        }
    }
    public void GetDamage(){
        animator.SetTrigger("Dmg");
        GenerateNewEnemy();
        BossMove();
        StartCoroutine(DelayOnHit());
    }
    private void GenerateNewEnemy(){
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
    private void BossMove(){
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform movePoint = spawnPoints[randomIndex];
        transform.position = movePoint.position;
    }
    
    IEnumerator DestroyBossWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    IEnumerator DelayOnHit()
    {
        yield return new WaitForSeconds(0.5f);
        dmgCount++;
    }
}

