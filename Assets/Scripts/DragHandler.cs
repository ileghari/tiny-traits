using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject itemBeingDragged;

    private Vector3 startPosition;

    // use this to check if object has been dragged into another slot
    private Transform startParent;

    public GameObject player;

    private Animator textOneAnimator;
    private Animator textTwoAnimator;
    private Animator backgroundOneAnimator;
    private Animator backgroundTwoAnimator;

    private Scene currentScene;

    void Start()
    {
        player = GameObject.Find("Player");

        currentScene = SceneManager.GetActiveScene();
    }


    // on begin drag, check which slot its from
    // if slot parent is "Panel", do nothing (able to drag)
    // if slot parent == "Panel (1)", same restrictions


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameObject.transform.parent.transform.parent.name == "Panel")
        {
            itemBeingDragged = gameObject;
            startPosition = transform.position;
            startParent = transform.parent;
            // allows us to pass events through the item being dragged to the items behind them
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else if (gameObject.transform.parent.transform.parent.name == "Panel (1)")
        {

            if (currentScene.name == "Level 1 Map (Ismail)")
            {
                textOneAnimator = GameObject.Find("InstructionsOne").GetComponent<Animator>();
                textOneAnimator.Play("FadeTextOneOut");
                backgroundOneAnimator = GameObject.Find("InstructionsOneBackground").GetComponent<Animator>();
                backgroundOneAnimator.Play("FadeBackgroundOneOut");

                textTwoAnimator = GameObject.Find("InstructionsTwo").GetComponent<Animator>();
                textTwoAnimator.Play("BringTextTwoUp");
                backgroundTwoAnimator = GameObject.Find("InstructionsTwoBackground").GetComponent<Animator>();
                backgroundTwoAnimator.Play("FadeBackgroundTwoIn");
            }

            if (gameObject.name.Substring(0, 1) == "C")
            {

                if (player.GetComponent<DNAPickup>().cCounter.text == "0")
                {
                    // not able to drag C
                    eventData.pointerDrag = null;
                }
                else
                {
                    //able to drag C
                    itemBeingDragged = gameObject;
                    startPosition = transform.position;
                    startParent = transform.parent;
                    // allows us to pass events through the item being dragged to the items behind them
                    GetComponent<CanvasGroup>().blocksRaycasts = false;
                }
            }

            if (gameObject.name.Substring(0, 1) == "A")
            {
                if (player.GetComponent<DNAPickup>().aCounter.text == "0")
                {
                    // not able to drag A
                    eventData.pointerDrag = null;
                }
                else
                {
                    //able to drag A
                    itemBeingDragged = gameObject;
                    startPosition = transform.position;
                    startParent = transform.parent;
                    // allows us to pass events through the item being dragged to the items behind them
                    GetComponent<CanvasGroup>().blocksRaycasts = false;
                }
            }

            if (gameObject.name.Substring(0, 1) == "T")
            {
                if (player.GetComponent<DNAPickup>().tCounter.text == "0")
                {
                    // not able to drag T
                    eventData.pointerDrag = null;
                }
                else
                {
                    //able to drag T
                    itemBeingDragged = gameObject;
                    startPosition = transform.position;
                    startParent = transform.parent;
                    // allows us to pass events through the item being dragged to the items behind them
                    GetComponent<CanvasGroup>().blocksRaycasts = false;
                }
            }

            if (gameObject.name.Substring(0, 1) == "G")
            {
                if (player.GetComponent<DNAPickup>().gCounter.text == "0")
                {
                    // not able to drag G
                    eventData.pointerDrag = null;
                }
                else
                {
                    //able to drag G
                    itemBeingDragged = gameObject;
                    startPosition = transform.position;
                    startParent = transform.parent;
                    // allows us to pass events through the item being dragged to the items behind them
                    GetComponent<CanvasGroup>().blocksRaycasts = false;
                }
            }
        }



    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent == startParent)
        {
            // if user drags out of bounds it goes back in place
            transform.position = startPosition;
        }

    }




}
