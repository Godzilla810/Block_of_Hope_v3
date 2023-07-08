using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private float moveX;
    private float moveY;
    public float moveSpeed = 5f ;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if( !BtnForEnd.instance.isPause){
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            if ( inputX != 0 || inputY !=0 ){
                animator.SetBool("isWalk", true);
                animator.SetFloat("moveX", inputX);
                animator.SetFloat("moveY", inputY);
            }
            else{
                animator.SetBool("isWalk", false);
            }

            transform.Translate(Vector3.right * inputX * moveSpeed * Time.deltaTime + 
            Vector3.up * inputY * moveSpeed * Time.deltaTime, Space.World);

        }
    }
}
