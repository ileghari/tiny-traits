using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelCompleteScript : MonoBehaviour
{
    private int nextscene;

    public AudioSource hitFlag;

    void Start()
    {
        nextscene = SceneManager.GetActiveScene().buildIndex + 1;

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Player")
        {
            hitFlag.Play();
            if (nextscene == 12)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(nextscene);
            }
        }

    }
}
