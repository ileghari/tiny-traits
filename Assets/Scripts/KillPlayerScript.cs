using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayerScript : MonoBehaviour
{

    void Start()
    { }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Player")
        {
            SceneManager.LoadScene("Will_UI_Restart");
        }
    }
}
