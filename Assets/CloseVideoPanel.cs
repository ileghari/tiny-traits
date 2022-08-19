using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseVideoPanel : MonoBehaviour
{
    private GameObject willVid;
    private Animator WillVidAnim;
    private AudioSource GameMusic;

    private AudioSource willVidAudio;

    // Start is called before the first frame update
    void Start()
    {
        WillVidAnim = GameObject.Find("WillVideo").GetComponent<Animator>();
        willVid = GameObject.Find("WillVidVideo");
        GameMusic = GameObject.FindWithTag("gameMusic").GetComponent<AudioSource>();
        willVidAudio = GameObject.Find("NucleotideAudio").GetComponent<AudioSource>();
    }

    public void CloseVid()
    {
        WillVidAnim.Play("WIllVidDown");
        GameMusic.Play();
        willVidAudio.Pause();
    }
}
