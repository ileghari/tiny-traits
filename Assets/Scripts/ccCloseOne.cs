using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ccCloseOne : MonoBehaviour
{
    private Animator anim;
    private GameObject ccmenu;

    private Animator textTwoAnimator;
    private Animator textThreeAnimator;

    private GameObject pauseMenu;
    private OpenPause openPause;

    void Start()
    {
        anim = GameObject.Find("CCMenu").GetComponent<Animator>();
        pauseMenu = GameObject.Find("SettingsBotton");
        openPause = pauseMenu.GetComponent<OpenPause>();
    }
    public void CCDown()
    {
        ccmenu = GameObject.Find("CCMenu");
        ccmenu.SetActive(false);
        anim.Play("BringDown");
        // resume time
        openPause.paused = false;
    }
}
