using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusWarning : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        int showText = PlayerPrefs.GetInt("showWarning", 1);
        if (showText == 1)
        {
            anim = GameObject.Find("VirusWarning").GetComponent<Animator>();
            anim.Play("virusWarningFadeIn");
        }

    }


}
