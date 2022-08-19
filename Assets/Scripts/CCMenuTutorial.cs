using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMenuTutorial : MonoBehaviour
{

    private Animator anim;


    void Start()
    {
        anim = GameObject.Find("Arrow").GetComponent<Animator>();
        Debug.Log(anim);
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.name == "Player Collider")
        {
            Debug.Log("collided");
            anim.Play("OpenCC");
        }
    }


    //anim.Play("OpenCC");
}
