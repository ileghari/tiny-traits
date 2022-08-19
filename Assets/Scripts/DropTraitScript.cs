using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropTraitScript : MonoBehaviour
{

    [SerializeField] private Sprite defaultImage;
    private GameObject player;
    private GameObject sprite;

    public GameObject pushDnaHexPrefab;
    public GameObject cellWallDnaHexPrefab;

    public GameObject characterIcon;
    public GameObject imageK;
    public GameObject imageL;

    public Vector3 initialPushHexPosition;
    public Vector3 initialCellWallHexPosition;

    private Scene currentScene;

    private Animator instructionsB;
    private Animator arrowTwo;
    private Animator bookOpenArrow;

    // List of static and moving animations for Push Trait and CellWall+Push Trait
    private string[] pushStatic = { "StaticPush N", "StaticPush NW", "StaticPush W", "StaticPush SW", "StaticPush S", "StaticPush SE", "StaticPush E", "StaticPush NE" };
    private string[] pushRun = { "Push N", "Push NW", "Push W", "Push SW", "Push S", "Push SE", "Push E", "Push NE" };
    private string[] cellStatic = { "CellPushStatic N", "CellPushStatic NW", "CellPushStatic W", "CellPushStatic SW", "CellPushStatic S", "CellPushStatic SE", "CellPushStatic E", "CellPushStatic NE" };
    private string[] cellRun = { "CellPush N", "CellPush NW", "CellPush W", "CellPush SW", "CellPush S", "CellPush SE", "CellPush E", "CellPush NE" };
    private string[] squeezeStatic = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    private string[] squeezeRun = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };
    private string[] cStatic = { "CellStatic N", "CellStatic NW", "CellStatic W", "CellStatic SW", "CellStatic S", "CellStatic SE", "CellStatic E", "CellStatic NE" };
    private string[] cRun = { "Cell N", "Cell NW", "Cell W", "Cell SW", "Cell S", "Cell SE", "Cell E", "Cell NE" };

    public AudioSource dropTrait;

    public AudioSource traitPickup;



    void Start()
    {
        player = GameObject.Find("Player");
        sprite = GameObject.Find("Bunny Sprite");
        currentScene = SceneManager.GetActiveScene();
    }


    public void DropTrait()
    {
        string trait = gameObject.transform.parent.GetChild(0).GetComponent<Image>().sprite.name;

        if (currentScene.name == "Level 4 Map (Ismail)")
        {
            instructionsB = GameObject.Find("InstructionsB").GetComponent<Animator>();
            instructionsB.Play("instructionsBFadeOut");

            arrowTwo = GameObject.Find("ArrowTwo").GetComponent<Animator>();
            arrowTwo.Play("arrowTwoFadeOut");

            bookOpenArrow = GameObject.Find("BookOpenArrow").GetComponent<Animator>();
            bookOpenArrow.Play("BookOpenArrowBounce");

        }

        // if a trait is equipped in that slot
        if (trait != "Blank")
        {
            dropTrait.Play();
            player.GetComponent<CharacterInfo>().DeleteTrait(trait);

            if (trait == "cellWall")
            {
                // instantiate object with corresponding fields
                GameObject cellWallDnaHex = Instantiate(cellWallDnaHexPrefab, initialCellWallHexPosition, Quaternion.identity);
                TraitUpdate cellWallFields = cellWallDnaHex.GetComponent<TraitUpdate>();
                cellWallFields.charIcon = characterIcon;
                cellWallFields.imageK = imageK;
                cellWallFields.imageL = imageL;
                cellWallFields.traitPickup = traitPickup;
                StopPushingAnim();
            }
            else if (trait == "BlockPushIcon")
            {
                // instantiate object with corresponding fields
                GameObject pushDnaHex = Instantiate(pushDnaHexPrefab, initialPushHexPosition, Quaternion.identity);
                TraitUpdate pushFields = pushDnaHex.GetComponent<TraitUpdate>();
                pushFields.charIcon = characterIcon;
                pushFields.imageK = imageK;
                pushFields.imageL = imageL;
                pushFields.traitPickup = traitPickup;
                StopPushingAnim();
            }
        }

        gameObject.transform.parent.GetChild(0).GetComponent<Image>().sprite = defaultImage;


    }

    private void StopPushingAnim()
    {
        // Player has only Push trait
        if (!player.GetComponent<CharacterInfo>().HasTrait("CellWall") && player.GetComponent<CharacterInfo>().HasTrait("Push"))
        {
            sprite.GetComponent<IsometricAnimation3D>().staticDirections = pushStatic;
            sprite.GetComponent<IsometricAnimation3D>().runDirections = pushRun;
        }
        // Player has both push and cell wall trait
        else if (player.GetComponent<CharacterInfo>().HasTrait("CellWall") && player.GetComponent<CharacterInfo>().HasTrait("Push"))
        {
            sprite.GetComponent<IsometricAnimation3D>().staticDirections = cellStatic;
            sprite.GetComponent<IsometricAnimation3D>().runDirections = cellRun;
        }
        else if (player.GetComponent<CharacterInfo>().HasTrait("CellWall") && !player.GetComponent<CharacterInfo>().HasTrait("Push"))
        {
            sprite.GetComponent<IsometricAnimation3D>().staticDirections = cStatic;
            sprite.GetComponent<IsometricAnimation3D>().runDirections = cRun;
        }
        else
        {
            sprite.GetComponent<IsometricAnimation3D>().staticDirections = squeezeStatic;
            sprite.GetComponent<IsometricAnimation3D>().runDirections = squeezeRun;
        }
    }

}
