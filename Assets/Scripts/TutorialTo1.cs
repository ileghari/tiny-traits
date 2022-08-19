using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialTo1 : MonoBehaviour
{
    void Start()
    {
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Player")
        {
            SceneManager.LoadScene("Level 1 Map");
        }
    }
}
