using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel00 ()
    {
        SceneManager.LoadScene(00);
    }

    public void LoadLevel01 ()
    {
        SceneManager.LoadScene(01);
    }

    public void LoadLevel02 ()
    {
        SceneManager.LoadScene(02);
    }

    public void LoadLevel03 ()
    {
        SceneManager.LoadScene(03);
    }
}
