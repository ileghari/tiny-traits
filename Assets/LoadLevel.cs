using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    private GameObject player;
    public string levelName;

    void Start()
    {
        player = GameObject.Find("Player Sprite");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Vector4(255, 246, 189, 255);
        Debug.Log("Colliding");
        if (collision.gameObject == player && Input.GetButton("Submit"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = new Vector4(255, 255, 255, 255);
    }

}
