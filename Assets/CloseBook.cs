using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseBook : MonoBehaviour
{
    public Button myButton;
    private Animator anim;
    public bool tutorial;
    private Animator anim2;
    private Animator arrowAnim;
    public Text squeezeText;
    private Button squeeze;
    private Button push;
    private Button shield;

    private GameObject pauseMenu;
    private OpenPause openPause;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("BookOfTraits").GetComponent<Animator>();
        squeeze = GameObject.Find("SqueezeButton").GetComponent<Button>();

        pauseMenu = GameObject.Find("SettingsBotton");
        openPause = pauseMenu.GetComponent<OpenPause>();

        if (tutorial)
        {
            arrowAnim = GameObject.Find("Arrow").GetComponent<Animator>();
            anim2 = GameObject.Find("CloseBookText").GetComponent<Animator>();
        }
        push = GameObject.Find("PushButton").GetComponent<Button>();
        shield = GameObject.Find("ShieldButton").GetComponent<Button>();
    }

    // Update is called once per frame
    public void BookClose()
    {
        // Delete videos if they appear in the scene
        if (GameObject.Find("SqueezeExampleVid") != null) Destroy(GameObject.Find("SqueezeExampleVid"));
        if (GameObject.Find("PushExampleVid") != null) Destroy(GameObject.Find("PushExampleVid"));
        if (GameObject.Find("WallExampleVid") != null) Destroy(GameObject.Find("WallExampleVid"));

        anim.Play("BookClose");
        myButton.interactable = true;
        squeeze.interactable = false;
        // resume time
        openPause.paused = false;

        if (tutorial)
        {
            Debug.Log("BookClose");
            anim2.Play("BookClosed");
            arrowAnim.Play("WASD");
            squeezeText.text = "Use the Squeeze trait\nto get to the flag";
        }
        push.interactable = false;
        shield.interactable = false;
    }
}
