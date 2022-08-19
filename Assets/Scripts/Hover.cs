using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{

    private GameObject pauseMenu;
    private OpenPause openPause;

    void Start()
    {
        pauseMenu = GameObject.Find("SettingsBotton");
        openPause = pauseMenu.GetComponent<OpenPause>();
    }
    void Update()
    {

        if (!openPause.paused)
        {
            this.transform.LookAt(Camera.main.transform);
            this.transform.position += Vector3.up * Mathf.Cos(3 * (Time.time)) / 100;
        }
    }
}
