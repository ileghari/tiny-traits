using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCButton : MonoBehaviour
{
    private Animator anim;
    private GameObject ccmenu;

    private GameObject pauseMenu;
    private OpenPause openPause;
    void Start()
    {

        anim = GameObject.Find("CCMenu").GetComponent<Animator>();
        ccmenu = GameObject.Find("CCMenu");
        ccmenu.SetActive(false);
        pauseMenu = GameObject.Find("SettingsBotton");
        openPause = pauseMenu.GetComponent<OpenPause>();

    }
    public void CCUp()
    {
        ccmenu.SetActive(true);
        // freeze time
        openPause.paused = true;
        anim.Play("BringUp");
        Debug.Log("cc up");
    }
}
