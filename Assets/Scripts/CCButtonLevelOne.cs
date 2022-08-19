using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCButtonLevelOne : MonoBehaviour
{

    private Animator anim;
    private GameObject ccmenu;

    private Animator arrowAnimator;

    private Animator textOneAnimator;

    private Animator backgroundOneAnimator;

    private GameObject pauseMenu;
    private OpenPause openPause;

    void Start()
    {

        arrowAnimator = GameObject.Find("Arrow").GetComponent<Animator>();
        textOneAnimator = GameObject.Find("InstructionsOne").GetComponent<Animator>();
        backgroundOneAnimator = GameObject.Find("InstructionsOneBackground").GetComponent<Animator>();
        anim = GameObject.Find("CCMenu").GetComponent<Animator>();
        ccmenu = GameObject.Find("CCMenu");
        ccmenu.SetActive(false);
        pauseMenu = GameObject.Find("SettingsBotton");
        openPause = pauseMenu.GetComponent<OpenPause>();

    }
    public void CCUp()
    {
        ccmenu.SetActive(true);
        //freeze time
        openPause.paused = true;
        anim.Play("BringUp");
        arrowAnimator.Play("ArrowFade");
        textOneAnimator.Play("BringTextOneUp");
        backgroundOneAnimator.Play("FadeBackgroundOneIn");
    }

}
