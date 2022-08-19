using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BookOpen : MonoBehaviour
{
    public Button mybutton;
    private Animator anim;
    private Animator bookOpenArrow;
    private Scene currentScene;
    private Button squeeze;
    private Button push;
    private Button shield;

    private GameObject pauseMenu;
    private OpenPause openPause;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        anim = GetComponent<Animator>();
        squeeze = GameObject.Find("SqueezeButton").GetComponent<Button>();
        push = GameObject.Find("PushButton").GetComponent<Button>();
        shield = GameObject.Find("ShieldButton").GetComponent<Button>();


    }

    public void Open()
    {
        anim.Play("BookOpen");
        mybutton.interactable = false;
        squeeze.interactable = true;
        Debug.Log("open");
        pauseMenu = GameObject.Find("SettingsBotton");
        openPause = pauseMenu.GetComponent<OpenPause>();
        Debug.Log(openPause.paused);
        // freeze time
        openPause.paused = true;
        Debug.Log(openPause.paused);

        if (currentScene.name == "Level 4 Map (Ismail)" || currentScene.name == "Level 1 Map (Ismail)")
        {
            bookOpenArrow = GameObject.Find("BookOpenArrow").GetComponent<Animator>();
            bookOpenArrow.Play("ArrowGoAway");
        }

        push.interactable = true;
        shield.interactable = true;
    }
}
