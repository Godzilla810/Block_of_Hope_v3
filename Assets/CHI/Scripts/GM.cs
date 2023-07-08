using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static int howtoplaylist;
    public GameObject htp01, htp02, htp03;
    public GameObject Stbtn, Ntbtn;

    // Start is called before the first frame update
    void Start()
    {
        howtoplaylist = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (howtoplaylist == 1)
        {
            htp01.SetActive(false);
            htp02.SetActive(true);
        }

        if (howtoplaylist == 2)
        {
            htp02.SetActive(false);
            htp03.SetActive(true);
        }

        if (howtoplaylist == 3)
        {
            Ntbtn.SetActive(false);
            Stbtn.SetActive(true);
        }
    }

    public void nextck ()
    {
        howtoplaylist++;
    }
    

}
