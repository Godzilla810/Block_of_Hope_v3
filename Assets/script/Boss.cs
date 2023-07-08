using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// press "O" to kill boss instantly, press "I" to damage boss
public class Boss : MonoBehaviour
{
    private Animator animator;
    private int dmgCount;
    private int dieCount;
    private Transform spawnPoint;

    public Transform ru,rd,lu,ld;
    public GameObject enemyPrefab;     // Prefab of the enemy to be generated
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private int hp;
    //public MagicBlock MB;
    // Start is called before the first frame update



    private void Start()
    {
        hp = 5;
        animator = GetComponent<Animator>();
        dmgCount=0;
        dieCount=0;
        minX = Mathf.Min(ru.position.x, rd.position.x, lu.position.x, ld.position.x);
        maxX = Mathf.Max(ru.position.x, rd.position.x, lu.position.x, ld.position.x);
        minY = Mathf.Min(ru.position.y, rd.position.y, lu.position.y, ld.position.y);
        maxY = Mathf.Max(ru.position.y, rd.position.y, lu.position.y, ld.position.y);
    }

    private void Update()
    {
        // Check for player input to switch between animator states
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Trigger the "Jump" animation state
            animator.SetTrigger("Talk");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("Dmg");
            GenerateNewEnemy();
            StartCoroutine(DelayOnHit());
        }
        else if (Input.GetKeyDown(KeyCode.O)||dmgCount==hp)
        {
            animator.SetTrigger("Die");
            dmgCount=0;
            dieCount++;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Idle");
        }
        if(dieCount==4){
            StartCoroutine(DestroyEnemyWithDelay());
        }
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("mb"))
        {
            animator.SetTrigger("Dmg");
            TeleportEnemy();
            dmgCount++;
        }
    }
    private System.Collections.IEnumerator DestroyEnemyWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        // SceneManager.LoadScene("level1");
    }
     private void TeleportEnemy()
    {
        // Generate a random position within the teleport area
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Teleport the enemy to the random position
        transform.position = randomPosition;
    }
    private System.Collections.IEnumerator DelayOnHit()
    {
        yield return new WaitForSeconds(0.5f);
        TeleportEnemy();
        dmgCount++;
    }
    private void GenerateNewEnemy(){
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }
}

