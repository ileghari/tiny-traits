using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TraitUpdate : MonoBehaviour
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

    private Scene currentScene;

    private Animator bookOpenArrow;

    public AudioSource traitPickup;


    void Start()
    {
        player = GameObject.Find("Player");
        anim = GameObject.Find("Bunny Sprite").GetComponent<Animator>();
        currentScene = SceneManager.GetActiveScene();

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            traitPickup.Play();

            int firstEmpty = player.GetComponent<CharacterInfo>().FirstEmpty();
            Destroy(gameObject);

            //Player has neither trait
            if (!player.GetComponent<CharacterInfo>().HasTrait("CellWall") && !player.GetComponent<CharacterInfo>().HasTrait("Push"))
            {
                if (trait == "CellWall")
                {

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
                if (trait == "Push")
                {
                    if (currentScene.name == "Level 1 Map (Ismail)")
                    {
                        bookOpenArrow = GameObject.Find("BookOpenArrow").GetComponent<Animator>();
                        bookOpenArrow.Play("BookOpenArrowBounce");
                    }

                    if (firstEmpty == 1)
                    {
                        imageK.GetComponent<Image>().sprite = traitIcon;
                        charIcon.GetComponent<Image>().sprite = characterIcon;
                        player.GetComponent<CharacterInfo>().AddTrait(trait);
                        string[] newStatic = { "StaticPush N", "StaticPush NW", "StaticPush W", "StaticPush SW", "StaticPush S", "StaticPush SE", "StaticPush E", "StaticPush NE" };
                        string[] newDirections = { "Push N", "Push NW", "Push W", "Push SW", "Push S", "Push SE", "Push E", "Push NE" };//change animations back
                        GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().staticDirections = newStatic;
                        GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().runDirections = newDirections;
                    }
                    if (firstEmpty == 2) // K trait full
                    {
                        imageL.GetComponent<Image>().sprite = traitIcon;
                        charIcon.GetComponent<Image>().sprite = characterIcon;
                        player.GetComponent<CharacterInfo>().AddTrait(trait);
                        string[] newStatic = { "StaticPush N", "StaticPush NW", "StaticPush W", "StaticPush SW", "StaticPush S", "StaticPush SE", "StaticPush E", "StaticPush NE" };
                        string[] newDirections = { "Push N", "Push NW", "Push W", "Push SW", "Push S", "Push SE", "Push E", "Push NE" };//change animations back
                        GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().staticDirections = newStatic;
                        GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().runDirections = newDirections;
                    }
                }
            }
            else // Run hybrid animation w/ Cell Wall and Pili
            {
                if (firstEmpty == 1)
                {
                    imageK.GetComponent<Image>().sprite = traitIcon;
                    charIcon.GetComponent<Image>().sprite = characterIcon;
                    player.GetComponent<CharacterInfo>().AddTrait(trait);
                    string[] newStatic = { "CellPushStatic N", "CellPushStatic NW", "CellPushStatic W", "CellPushStatic SW", "CellPushStatic S", "CellPushStatic SE", "CellPushStatic E", "CellPushStatic NE" };
                    string[] newDirections = { "CellPush N", "CellPush NW", "CellPush W", "CellPush SW", "CellPush S", "CellPush SE", "CellPush E", "CellPush NE" };//change animations back
                    GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().staticDirections = newStatic;
                    GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().runDirections = newDirections;
                }
                if (firstEmpty == 2) // K trait full
                {
                    imageL.GetComponent<Image>().sprite = traitIcon;
                    charIcon.GetComponent<Image>().sprite = characterIcon;
                    player.GetComponent<CharacterInfo>().AddTrait(trait);
                    string[] newStatic = { "CellPushStatic N", "CellPushStatic NW", "CellPushStatic W", "CellPushStatic SW", "CellPushStatic S", "CellPushStatic SE", "CellPushStatic E", "CellPushStatic NE" };
                    string[] newDirections = { "CellPush N", "CellPush NW", "CellPush W", "CellPush SW", "CellPush S", "CellPush SE", "CellPush E", "CellPush NE" };//change animations back
                    GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().staticDirections = newStatic;
                    GameObject.Find("Bunny Sprite").GetComponent<IsometricAnimation3D>().runDirections = newDirections;
                }
            }



        }
    }
}

