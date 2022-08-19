using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inhibitionExplanation : MonoBehaviour
{


    private Animator anim;

    private Animator instructionsA;

    private Animator instructionsB;

    private Animator arrowTwo;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CellWallDNAHex Variant")
        {
            anim = GameObject.Find("ArrowNew").GetComponent<Animator>();
            anim.Play("arrowBounce");

            instructionsA = GameObject.Find("instructionsA").GetComponent<Animator>();
            instructionsA.Play("instructionsFadeInOut");

            instructionsB = GameObject.Find("InstructionsB").GetComponent<Animator>();
            instructionsB.Play("instructionsBFadeInOut");

            arrowTwo = GameObject.Find("ArrowTwo").GetComponent<Animator>();
            arrowTwo.Play("arrowTwoBounce");
        }
    }

}