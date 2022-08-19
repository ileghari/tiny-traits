using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Purpose: This script assigns the Player's name to the game UI
public class NameSelect : MonoBehaviour
{
    public Text userNameInputText; //text component of UI Element

    // Start is called before the first frame update
    void Start()
    {
        userNameInputText.text = PlayerPrefs.GetString("playerName");
    }
}
