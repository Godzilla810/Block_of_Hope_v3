using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up_down_enemy : MonoBehaviour
{
   public float speed = 5f; // Speed of enemy movement
    // public Transform topPoint; // Top point of movement
    // public Transform bottomPoint; // Bottom point of movement

    private Animator animator;
    private bool movingUp = true; // Flag to track movement direction
        private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);

            // if (transform.position.y >= topPoint.position.y)
            // {
            //     movingUp = false;
            // }
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            // if (transform.position.y <= bottomPoint.position.y)
            // {
            //     movingUp = true;
            // }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            movingUp = !movingUp;
        }
        // if (collision.gameObject.CompareTag("Player"))
        // {
        //     animator.SetTrigger("atk_L");
        // }
    } 
}
