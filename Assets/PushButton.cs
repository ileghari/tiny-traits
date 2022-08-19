using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PushButton : MonoBehaviour
{
    private Animator anim;
    private Button squeeze;
    private Button push;
    private Button shield;
    private GameObject uiParent;
    private GameObject PushVid;
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
        anim.Play("SqueezeTrait");
        PushVid = Instantiate(prefab, uiParent.transform);
        PushVid.name = "PushExampleVid";
        GameObject.Find("PushExampleVid").GetComponent<Animator>().Play("PushAnim");
        squeeze.interactable = false;
        push.interactable = false;
        shield.interactable = false;
    }
}
