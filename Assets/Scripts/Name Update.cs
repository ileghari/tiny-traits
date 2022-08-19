using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelNameUpdate : MonoBehaviour
{
    public int scene;
    public string text = "";
    public TextMeshPro mText; 
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        text = "Level " + scene.ToString();
        mText = gameObject.GetComponent<TextMeshPro>();
        mText.text = text;



        
    }

}
