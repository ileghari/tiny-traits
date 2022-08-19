using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPause : MonoBehaviour
{
    private Animator anim;
    private Animator anim2;
    private Animator anim3;

    public bool paused;


    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("PauseLabel").GetComponent<Animator>();
        anim2 = GameObject.Find("Settings Menu").GetComponent<Animator>();
        anim3 = GetComponent<Animator>();
        paused = false;
    }

    // Update is called once per frame
    public void PauseDrop()
    {
        anim.Play("LabelDropdown");
        anim2.Play("PauseZoom");
        anim3.Play("ToPlay");
        paused = !paused;
    }
    public void PauseRise()
    {
        anim.Play("LabelAscend");
        anim2.Play("PauseZoomOut");
        anim3.Play("ToPause");
    }

    void Update()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}

