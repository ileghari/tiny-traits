using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenName : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("NameAssurance").GetComponent<Animator>();
    }

    // Update is called once per frame
    public void ItsReady()
    {
        anim.Play("NameUp");
    }
}
