using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameRedo : MonoBehaviour
{
    private Animator anim3;
    // Start is called before the first frame update
    void Start()
    {
        anim3 = GameObject.Find("NameAssurance").GetComponent<Animator>();
    }
    public void tryAgain()
    {
        anim3.Play("NameDown");
    }
}
