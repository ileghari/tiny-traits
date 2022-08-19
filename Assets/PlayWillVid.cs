using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;

public class PlayWillVid : MonoBehaviour
{
    private GameObject willVid;
    private Animator WillVidAnim;
    private AudioSource GameMusic;
    public AudioSource WillVidMusic;
    private float volume;

    // Start is called before the first frame update
    void Start()
    {
        GameMusic = GameObject.FindWithTag("gameMusic").GetComponent<AudioSource>();
        WillVidAnim = GameObject.Find("WillVideo").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        WillVidMusic.Play();
        WillVidAnim.Play("WillVidUp");
        //StartCoroutine(LowerMusic());
        LowerMusic();
    }

    // IEnumerator LowerMusic()
    // {
    //     GameMusic.Pause();
    //     // GameMusic.volume = 0.1f;
    //     // yield return new WaitForSeconds(20f);
    //     // GameMusic.volume = 1f;
    // }

    void LowerMusic()
    {
        GameMusic.Pause();
    }
}
