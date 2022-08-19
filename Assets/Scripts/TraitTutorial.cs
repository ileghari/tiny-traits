using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitTutorial : MonoBehaviour
{
    private string[] traitList;
    private GameObject player;
    public string trait;
    [SerializeField] private GameObject imageK;
    [SerializeField] private GameObject imageL;
    [SerializeField] private GameObject charIcon;
    public Sprite traitIcon;
    public Sprite characterIcon;
    private Animator anim;
    private string[] newDirections;
    private string[] newStatic;
    private GameObject raise;
    private Animator hexAnim;
    private Animator squeezeAnim;
    private Animator arrowAnim;
    private Animator traitIconAnim;
    public ParticleSystem newTrait;

    public AudioSource traitPickup;

    void Start()
    {
        traitIconAnim = GameObject.Find("JTrait/TraitImage").GetComponent<Animator>();
        player = GameObject.Find("Player");
        anim = GameObject.Find("Bunny Sprite").GetComponent<Animator>();
        raise = GameObject.Find("RaiseFolder");
        hexAnim = GameObject.Find("HexText").GetComponent<Animator>();
        squeezeAnim = GameObject.Find("SqueezeText").GetComponent<Animator>();
        arrowAnim = GameObject.Find("Arrow").GetComponent<Animator>();
        newTrait.Stop();
    }


    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        traitIconAnim.Play("NewTrait");
        newTrait.Play();
        traitPickup.Play();

        raise.GetComponent<Animator>().Play("TutorialRaise");
        hexAnim.Play("Check");
        hexAnim.Play("HexDown");
        squeezeAnim.Play("SqueezeUp");
        arrowAnim.Play("Close");
    }
}


// image.GetComponent<Image>() --> gets image component that we have to change