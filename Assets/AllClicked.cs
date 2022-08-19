using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllClicked : MonoBehaviour
{
    public GameObject toDelete;
    private bool wClicked;
    private bool aClicked;
    private bool sClicked;
    private bool dClicked;
    private GameObject wButton;
    private GameObject aButton;
    private GameObject sButton;
    private GameObject dButton;
    private bool on;
    private Animator anim;
    private Animator anim2;
    private Animator anim3;
    private Animator anim4;
    private Animator arrowAnim;
    public Image greenFrame;
    public Animator hexAnim;


    // Start is called before the first frame update
    void Start()
    {
        on = false;
        wClicked = false;
        aClicked = false;
        sClicked = false;
        dClicked = false;
        wButton = GameObject.Find("WFrame");
        aButton = GameObject.Find("AFrame");
        sButton = GameObject.Find("SFrame");
        dButton = GameObject.Find("DFrame");
        anim = GameObject.Find("WASDbackground").GetComponent<Animator>();
        anim2 = GameObject.Find("DNAHex 1").GetComponent<Animator>();
        anim3 = GameObject.Find("NameAssurance").GetComponent<Animator>();
        anim4 = GameObject.Find("NamePrompt").GetComponent<Animator>();
        arrowAnim = GameObject.Find("Arrow").GetComponent<Animator>();
        hexAnim = GameObject.Find("HexText").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on == true)
        {
            if (Input.GetAxis("Vertical")>0.1)
            {
                wClicked = true;
                Image newImage = Instantiate(greenFrame, Vector3.zero, Quaternion.identity);
                newImage.transform.SetParent(GameObject.Find("UI").transform, false);
                newImage.rectTransform.anchoredPosition = new Vector3(-121,-248,0); 
            }
            if (Input.GetAxis("Horizontal") < -0.1)
            {
                aClicked = true;
                Image newImage = Instantiate(greenFrame, Vector3.zero, Quaternion.identity);
                newImage.transform.SetParent(GameObject.Find("UI").transform, false);
                newImage.rectTransform.anchoredPosition = new Vector3(-324, -446, 0);

            }
            if (Input.GetAxis("Vertical") < -0.1)
            {
                sClicked = true;
                Image newImage = Instantiate(greenFrame, Vector3.zero, Quaternion.identity);
                newImage.transform.SetParent(GameObject.Find("UI").transform, false);
                newImage.rectTransform.anchoredPosition = new Vector3(-115, -451, 0);
            }
            if (Input.GetAxis("Horizontal") >0.1)
            {
                dClicked = true;
                Image newImage = Instantiate(greenFrame, Vector3.zero, Quaternion.identity);
                newImage.transform.SetParent(GameObject.Find("UI").transform, false);
                newImage.rectTransform.anchoredPosition = new Vector3(93, -446, 0);
            }
            if (wClicked == true && aClicked == true && sClicked == true && dClicked == true)
            {
                anim.Play("Check");
                anim.Play("BringDown");
                GameObject[] toDelete = GameObject.FindGameObjectsWithTag("GreenFrame");
                foreach (GameObject delete in toDelete)
                    GameObject.Destroy(delete);
                // Play a well done animation
                Destroy(GameObject.Find("HexBlock"));
                anim2.Play("TutorialRaise");
                hexAnim.Play("HexUp");
                arrowAnim.Play("Hex");
                // wait for animation above to finish
                // Play animation prompting the user to go up to DNA trait and get ability.
                on = false;
            }
        }
        
    }
    public void OnScript()
    {
        anim4.Play("NameCheck");
        anim3.Play("NameDown");
        anim.Play("BringUp");
        arrowAnim.Play("WASD");
        GameObject.Find("NameInput").GetComponent<InputField>().interactable = false;
        on = true;
    }
}
