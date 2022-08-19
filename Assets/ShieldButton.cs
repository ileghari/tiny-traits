using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour
{
    private Animator anim;
    private Button squeeze;
    private Button push;
    private Button shield;
    private GameObject uiParent;
    private GameObject WallVid;
    public GameObject prefab;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        uiParent = GameObject.Find("UI");
        squeeze = GameObject.Find("SqueezeButton").GetComponent<Button>();
        push = GameObject.Find("PushButton").GetComponent<Button>();
        shield = GameObject.Find("ShieldButton").GetComponent<Button>();
    }

    public void PushBtn()
    {
        anim.Play("ShieldTrait");
        WallVid = Instantiate(prefab, uiParent.transform);
        WallVid.name = "WallExampleVid";
        GameObject.Find("WallExampleVid").GetComponent<Animator>().Play("ShieldAnim");
        squeeze.interactable = false;
        push.interactable = false;
        shield.interactable = false;
    }
}
