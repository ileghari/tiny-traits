using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitUpdateWall : MonoBehaviour
{
    private string[] traitList;
    private GameObject player;
    public string trait;
    public GameObject imageK;
    public GameObject imageL;
    public GameObject charIcon;
    public Sprite traitIcon;
    public Sprite characterIcon;
    private Animator anim;
    private string[] newDirections;
    private string[] newStatic;
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GameObject.Find("Bunny Sprite").GetComponent<Animator>();

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {


            int firstEmpty = player.GetComponent<CharacterInfo>().FirstEmpty();
            Destroy(gameObject);
            if (firstEmpty == 1)
            {
                imageK.GetComponent<Image>().sprite = traitIcon;
                charIcon.GetComponent<Image>().sprite = characterIcon;
                player.GetComponent<CharacterInfo>().AddTrait(trait);
                string[] newStatic = { "CellStatic N", "CellStatic NW", "CellStatic W", "CellStatic SW", "CellStatic S", "CellStatic SE", "CellStatic E", "CellStatic NE" };
                string[] newDirections = { "Cell N", "Cell NW", "Cell W", "Cell SW", "Cell S", "Cell SE", "Cell E", "Cell NE" };//change animations back
                GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().staticDirections = newStatic;
                GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().runDirections = newDirections;
            }
            if (firstEmpty == 2) // K trait full
            {
                imageL.GetComponent<Image>().sprite = traitIcon;
                charIcon.GetComponent<Image>().sprite = characterIcon;
                player.GetComponent<CharacterInfo>().AddTrait(trait);
                string[] newStatic = { "CellStatic N", "CellStatic NW", "CellStatic W", "CellStatic SW", "CellStatic S", "CellStatic SE", "CellStatic E", "CellStatic NE" };
                string[] newDirections = { "Cell N", "Cell NW", "Cell W", "Cell SW", "Cell S", "Cell SE", "Cell E", "Cell NE" };//change animations back
                GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().staticDirections = newStatic;
                GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().runDirections = newDirections;

            }
        }
    }
}


// figure out what animations are - if they are for push, then add if statement, if trait == "Push", do these animations, else do cell wall animations

