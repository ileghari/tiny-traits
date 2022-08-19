using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InventoryScript : MonoBehaviour, IHasChanged
{

    [SerializeField] Transform slots;
    [SerializeField] Text inventoryText;

    private GameObject playerSprite;
    private SpriteRenderer sprite;

    private Image imageSprite;

    private Image colorOneSprite;
    private Image colorTwoSprite;
    private Image colorThreeSprite;

    private Animator textTwoAnimator;
    private Animator textThreeAnimator;
    private Animator backgroundTwoAnimator;
    private Animator backgroundThreeAnimator;

    private Scene currentScene;

    private Image applyButtonImage;

    public AudioSource applyChanges;

    void Start()
    {
        HasChanged();
        playerSprite = GameObject.Find("Bunny Sprite");
        sprite = playerSprite.GetComponent<SpriteRenderer>();
        imageSprite = GameObject.Find("ColorSelector").GetComponent<Image>();
        colorOneSprite = GameObject.Find("colorOneBorder").GetComponent<Image>();
        colorTwoSprite = GameObject.Find("colorTwoBorder").GetComponent<Image>();
        colorThreeSprite = GameObject.Find("colorThreeBorder").GetComponent<Image>();

        currentScene = SceneManager.GetActiveScene();

        GetColor();
    }

    void GetColor()
    {
        int currentColor = PlayerPrefs.GetInt("color");
        if (currentColor == 0)
        {
            playerSprite.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            imageSprite.color = new Color(255, 255, 255, 255);
            colorOneSprite.enabled = true;
            colorTwoSprite.enabled = false;
            colorThreeSprite.enabled = false;
        }
        else if (currentColor == 1)
        {
            playerSprite.GetComponent<SpriteRenderer>().color = new Color(0, 191, 255, 255);
            imageSprite.color = new Color(0, 191, 255, 255);
            colorOneSprite.enabled = false;
            colorTwoSprite.enabled = false;
            colorThreeSprite.enabled = true;
        }
        else if (currentColor == 2)
        {
            playerSprite.GetComponent<SpriteRenderer>().color = new Color(255, 0, 250, 255);
            imageSprite.color = new Color(255, 0, 250, 255);
            colorOneSprite.enabled = false;
            colorTwoSprite.enabled = true;
            colorThreeSprite.enabled = false;
        }


    }

    public string HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" ");
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<SlotScript>().item;
            if (item)
            {
                builder.Append(item.name.Substring(0, 1));
                builder.Append(" ");
            }
        }
        //inventoryText.text = builder.ToString();
        //Debug.Log(inventoryText.text);

        applyButtonImage = GameObject.Find("ConfirmChanges").GetComponent<Image>();
        applyButtonImage.color = Color.grey; // greyed out

        if (builder.ToString() == " A C T G " | builder.ToString() == " A A A T " | builder.ToString() == " C C C G ")
        {

            applyButtonImage.color = new Color(255, 255, 255, 255); // normal green

            if (currentScene.name == "Level 1 Map (Ismail)")
            {
                textTwoAnimator = GameObject.Find("InstructionsTwo").GetComponent<Animator>();
                textTwoAnimator.Play("FadeTextTwoOut");
                backgroundTwoAnimator = GameObject.Find("InstructionsTwoBackground").GetComponent<Animator>();
                backgroundTwoAnimator.Play("FadeBackgroundTwoOut");

                textThreeAnimator = GameObject.Find("InstructionsThree").GetComponent<Animator>();
                textThreeAnimator.Play("FadeTextThreeIn");
                backgroundThreeAnimator = GameObject.Find("InstructionsThreeBackground").GetComponent<Animator>();
                backgroundThreeAnimator.Play("FadeBackgroundThreeIn");

            }

            return builder.ToString();

        }

        return "has not changed";

    }


    public void ConfirmChanges()
    {
        if (currentScene.name == "Level 1 Map (Ismail)")
        {
            textThreeAnimator = GameObject.Find("InstructionsThree").GetComponent<Animator>();
            textThreeAnimator.Play("FadeTextThreeOut");
            backgroundThreeAnimator = GameObject.Find("InstructionsThreeBackground").GetComponent<Animator>();
            backgroundThreeAnimator.Play("FadeBackgroundThreeOut");
        }

        string colorCode = HasChanged();

        // changes color of player based on colorCode (copy code from if statements)
        if (colorCode == " A C T G ")
        {
            applyChanges.Play();
            playerSprite.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            PlayerPrefs.SetInt("color", 0);
            imageSprite.color = new Color(255, 255, 255, 255);
            colorOneSprite.enabled = true;
            colorTwoSprite.enabled = false;
            colorThreeSprite.enabled = false;
        }
        else if (colorCode == " A A A T ")
        {
            applyChanges.Play();
            playerSprite.GetComponent<SpriteRenderer>().color = new Color(0, 191, 255, 255);
            PlayerPrefs.SetInt("color", 1);
            imageSprite.color = new Color(0, 191, 255, 255);
            colorOneSprite.enabled = false;
            colorTwoSprite.enabled = false;
            colorThreeSprite.enabled = true;
        }
        else if (colorCode == " C C C G ")
        {
            applyChanges.Play();
            playerSprite.GetComponent<SpriteRenderer>().color = new Color(255, 0, 250, 255);
            PlayerPrefs.SetInt("color", 2);
            imageSprite.color = new Color(255, 0, 250, 255);
            colorOneSprite.enabled = false;
            colorTwoSprite.enabled = true;
            colorThreeSprite.enabled = false;
        }
    }


}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        string HasChanged();
    }
}


// yellow --> (255, 213, 0, 255)
// green --> (0, 191, 255, 255)
// red --> (255, 0, 250, 255)



