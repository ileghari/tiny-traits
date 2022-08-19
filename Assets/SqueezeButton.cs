using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SqueezeButton : MonoBehaviour
{
    private Animator anim;
    private Button squeeze;
    private Button push;
    private Button shield;
    private GameObject uiParent;
    private GameObject SqueezeVid;
    public GameObject prefab;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        uiParent = GameObject.Find("UI");
        squeeze = GameObject.Find("SqueezeButton").GetComponent<Button>();
        push = GameObject.Find("PushButton").GetComponent<Button>();
        shield = GameObject.Find("ShieldButton").GetComponent<Button>();
    }

    public void SqueezeBtn()
    {
        anim.Play("PushTrait");
        SqueezeVid = Instantiate(prefab, uiParent.transform);
        SqueezeVid.name = "SqueezeExampleVid";
        GameObject.Find("SqueezeExampleVid").GetComponent<Animator>().Play("SqueezeAnim");
        push.interactable = false;
        shield.interactable = false;
        squeeze.interactable = false;
    }
}
