using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookOpenTutorial : MonoBehaviour
{
    public Button mybutton;
    public GameObject prefab;
    private Animator anim;
    private Animator anim2;
    private Animator arrowAnim;
    private Button squeeze;
    private Button push;
    private Button shield;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim2 = GameObject.Find("CloseBookText").GetComponent<Animator>();
        arrowAnim = GameObject.Find("Arrow").GetComponent<Animator>();
        squeeze = GameObject.Find("SqueezeButton").GetComponent<Button>();
        push = GameObject.Find("PushButton").GetComponent<Button>();
        shield = GameObject.Find("ShieldButton").GetComponent<Button>();
    }

    public void Open()
    {
        anim.Play("BookOpen");
        anim2.Play("CloseBook");
        arrowAnim.Play("Book");
        mybutton.interactable = false;
        squeeze.interactable = true;
        push.interactable = true;
        shield.interactable = true;
    }
}
