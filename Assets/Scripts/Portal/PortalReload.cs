using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalReload : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Reload();
        }
    }
    public void Reload(){
        Debug.Log("Reload");
        SceneManager.LoadScene(06);
    }
}
