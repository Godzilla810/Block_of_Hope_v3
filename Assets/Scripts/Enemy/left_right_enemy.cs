using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class left_right_enemy : MonoBehaviour
{
    public float speed = 5f; // Speed of enemy movement
    private Animator animator;
    private bool movingUp = true; // Flag to track movement direction
    private Rigidbody2D enemyRb;
    private GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
    }


    private void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            movingUp = !movingUp;
        }

        else if (collision.gameObject.tag == "player")
        {
            Destroy(collision.gameObject);
            Restart();
        }

    }
    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(05);
    }

}