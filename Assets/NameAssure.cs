using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameAssure : MonoBehaviour
{
    private string input;
    private string output;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        input = GetComponent<Text>().text;
        PlayerPrefs.SetString("playerName", input);
        GameObject.Find("NameAssuranceText").GetComponent<Text>().text = "So, your name is . . . \n" + input + " ?";
    }
}
