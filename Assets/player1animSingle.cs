using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class player1animSingle : MonoBehaviour
{
    public Animator anim1;
    public static player1anim instance;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        anim1 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fail()
    {
        
            anim1.SetTrigger("Fail");
        
        
    }
    public void good()
    {
        
            int randomizedn = Random.Range(1, 4);
            if (randomizedn == 1)
            {
                anim1.SetTrigger("Good");
            }
            if (randomizedn == 2)
            {
                anim1.SetTrigger("Good2");
            }
            if (randomizedn == 3)
            {
                anim1.SetTrigger("Good3");
            }
        
        
    }
    public void great()
    {
        
            int randomizedn = Random.Range(1, 4);
            if (randomizedn == 1)
            {
                anim1.SetTrigger("Great");
            }
            if (randomizedn == 2)
            {
                anim1.SetTrigger("Great2");
            }
            if (randomizedn == 3)
            {
                anim1.SetTrigger("Great3");
            }
        
        
        
    }
}
