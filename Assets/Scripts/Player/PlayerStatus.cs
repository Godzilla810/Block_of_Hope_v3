using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage){
        HP -= damage;
        Debug.Log("-10");
        if (HP <= 0){
            PlayerDie();
        }
    }
    void PlayerDie(){
        Destroy(gameObject);
    }
}
