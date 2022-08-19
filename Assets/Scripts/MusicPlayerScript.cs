using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{

    private AudioSource audioSource;
    private GameObject objectMusic;

    public Slider volumeSlider;

    private float musicVolume = 0.3f;

    void Start()
    {
        objectMusic = GameObject.FindWithTag("gameMusic");
        audioSource = objectMusic.GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("volume", 0.3f);
        audioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    void Update()
    {
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }
}
