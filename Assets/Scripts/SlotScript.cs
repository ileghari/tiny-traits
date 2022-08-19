using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

// drag handler goes onto to starting object, drop handler goes onto recieving object

public class SlotScript : MonoBehaviour, IDropHandler
{

    private GameObject player;
    private TextMeshProUGUI gNumber;
    private TextMeshProUGUI cNumber;
    private TextMeshProUGUI tNumber;
    private TextMeshProUGUI aNumber;

    private int gCounter;
    private int cCounter;
    private int tCounter;
    private int aCounter;


    void Start()
    {
        player = GameObject.Find("Player");
    }

    public GameObject item
    {
        get
        {
            // if it has a child
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    // if you drop on a slot that has parent of name "Panel"
    // if origin slot had parent of "Panel (1)", decrement corresponding <eventData.pointerDrag.name> by 1
    // if origin slot parent == "Panel", do not change counter (do nothing)

    // if you drop on a slot that has parent of name "Panel (1)" increment corresponding <eventData.pointerDrag.name> by 1
    // make sure that player can only drop on slot in "Panel (1)" where gameObject.name == eventData.pointerDrag.name (change slot name to G DNA slot etc)

    public void OnDrop(PointerEventData eventData)
    {
        // if we don't have item we want to accept new item

        if (transform.parent.name == "Panel")
        {
            if (!item)
            {

                if (DragHandler.itemBeingDragged.transform.parent.transform.parent.name == "Panel (1)")
                {
                    if (eventData.pointerDrag.name.Substring(0, 1) == "G")
                    {
                        // decrement G by 1
                        gNumber = GameObject.FindGameObjectWithTag("gCounter").GetComponent<TextMeshProUGUI>();
                        gCounter = int.Parse(gNumber.text);
                        gCounter--;
                        GameObject.FindGameObjectWithTag("gCounter").GetComponent<TextMeshProUGUI>().text = gCounter.ToString();

                        DragHandler.itemBeingDragged.transform.SetParent(transform);
                        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
                    }

                    if (eventData.pointerDrag.name.Substring(0, 1) == "C")

                    {

                        // decrement C by 1
                        cNumber = GameObject.FindGameObjectWithTag("cCounter").GetComponent<TextMeshProUGUI>();
                        cCounter = int.Parse(cNumber.text);
                        cCounter--;
                        GameObject.FindGameObjectWithTag("cCounter").GetComponent<TextMeshProUGUI>().text = cCounter.ToString();

                        DragHandler.itemBeingDragged.transform.SetParent(transform);
                        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
                    }

                    if (eventData.pointerDrag.name.Substring(0, 1) == "T")
                    {
                        // decrement T by 1
                        tNumber = GameObject.FindGameObjectWithTag("tCounter").GetComponent<TextMeshProUGUI>();
                        tCounter = int.Parse(tNumber.text);
                        tCounter--;
                        GameObject.FindGameObjectWithTag("tCounter").GetComponent<TextMeshProUGUI>().text = tCounter.ToString();

                        DragHandler.itemBeingDragged.transform.SetParent(transform);
                        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
                    }

                    if (eventData.pointerDrag.name.Substring(0, 1) == "A")
                    {
                        // decrement A by 1
                        aNumber = GameObject.FindGameObjectWithTag("aCounter").GetComponent<TextMeshProUGUI>();
                        aCounter = int.Parse(aNumber.text);
                        aCounter--;
                        GameObject.FindGameObjectWithTag("aCounter").GetComponent<TextMeshProUGUI>().text = aCounter.ToString();

                        DragHandler.itemBeingDragged.transform.SetParent(transform);
                        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
                    }

                }
                else if (DragHandler.itemBeingDragged.transform.parent.transform.parent.name == "Panel")
                {
                    DragHandler.itemBeingDragged.transform.SetParent(transform);
                    ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());
                }
            }
        }

        // if target panel is "Panel (1)"
        if (transform.parent.name == "Panel (1)")
        {
            // if its being dragged from "Panel"
            if (DragHandler.itemBeingDragged.transform.parent.transform.parent.name == "Panel")
            {
                if (eventData.pointerDrag.name.Substring(0, 1) == "G")
                {
                    if (transform.name == "Slot (2)") // Slot (2) == G slot
                    {
                        DragHandler.itemBeingDragged.transform.SetParent(transform);
                        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());

                        // increment g counter by 1
                        gNumber = GameObject.FindGameObjectWithTag("gCounter").GetComponent<TextMeshProUGUI>();
                        gCounter = int.Parse(gNumber.text);
                        gCounter++;
                        GameObject.FindGameObjectWithTag("gCounter").GetComponent<TextMeshProUGUI>().text = gCounter.ToString();
                    }
                }

                if (eventData.pointerDrag.name.Substring(0, 1) == "C")
                {
                    if (transform.name == "Slot (1)") // Slot (1) == C slot
                    {
                        DragHandler.itemBeingDragged.transform.SetParent(transform);
                        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());

                        // increment c counter by 1
                        cNumber = GameObject.FindGameObjectWithTag("cCounter").GetComponent<TextMeshProUGUI>();
                        cCounter = int.Parse(cNumber.text);
                        cCounter++;
                        GameObject.FindGameObjectWithTag("cCounter").GetComponent<TextMeshProUGUI>().text = cCounter.ToString();
                    }
                }

                if (eventData.pointerDrag.name.Substring(0, 1) == "T")
                {
                    if (transform.name == "Slot (3)") // Slot (3) == T slot
                    {
                        DragHandler.itemBeingDragged.transform.SetParent(transform);
                        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());

                        // increment t counter by 1
                        tNumber = GameObject.FindGameObjectWithTag("tCounter").GetComponent<TextMeshProUGUI>();
                        tCounter = int.Parse(tNumber.text);
                        tCounter++;
                        GameObject.FindGameObjectWithTag("tCounter").GetComponent<TextMeshProUGUI>().text = tCounter.ToString();
                    }
                }

                if (eventData.pointerDrag.name.Substring(0, 1) == "A")
                {
                    if (transform.name == "Slot") // Slot == A slot
                    {
                        DragHandler.itemBeingDragged.transform.SetParent(transform);
                        ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.HasChanged());

                        // increment a counter by 1
                        aNumber = GameObject.FindGameObjectWithTag("aCounter").GetComponent<TextMeshProUGUI>();
                        aCounter = int.Parse(aNumber.text);
                        aCounter++;
                        GameObject.FindGameObjectWithTag("aCounter").GetComponent<TextMeshProUGUI>().text = aCounter.ToString();
                    }
                }

            }

        }


    }


}

