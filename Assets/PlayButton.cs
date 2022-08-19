using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private Animator anim;
    private Animator anim2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("PauseLabel").GetComponent<Animator>();
        anim2 = GameObject.Find("Settings Menu").GetComponent<Animator>();

    }

    // Update is called once per frame
    public void PauseDrop()
    {
        anim.Play("LabelDropdown");
        anim2.Play("PauseZoom");
    }
    public void PauseRise()
    {
        anim.Play("LabelAscend");
        anim2.Play("PauseZoomOut");
    }
}

