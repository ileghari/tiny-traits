using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CellWallScript : MonoBehaviour
{

    private GameObject player;

    [SerializeField] private GameObject traitFrame;

    public AudioSource die;

    void Start()
    {
        //hasCellWallTrait = true;
        player = GameObject.Find("Player");

    }

    void Update()
    {
        if (player.GetComponent<CharacterInfo>().HasTrait("CellWall"))
        {
            traitFrame.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
        else
        {
            traitFrame.GetComponent<Image>().color = new Color(0, 255, 241, 255);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(collision.gameObject.name);
        if (!player.GetComponent<CharacterInfo>().HasTrait("CellWall") && other.name == "SpikeBlock")
        {
            die.Play();
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name); // die --> reload same scene
        }

    }

}
