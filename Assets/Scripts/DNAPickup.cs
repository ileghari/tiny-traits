using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DNAPickup : MonoBehaviour
{

    private int numOfCDna;
    private int numOfTDna;
    private int numOfGDna;
    private int numOfADna;

    private Animator animA;
    private Animator animT;
    private Animator animC;
    private Animator animG;
    private Animator animArrow;

    public TextMeshProUGUI cCounter;
    public TextMeshProUGUI tCounter;
    public TextMeshProUGUI gCounter;
    public TextMeshProUGUI aCounter;

    public GameObject cDnaSlot;
    public GameObject gDnaSlot;
    public GameObject tDnaSlot;
    public GameObject aDnaSlot;

    public GameObject cSlot;
    public GameObject gSlot;
    public GameObject tSlot;
    public GameObject aSlot;

    private RectTransform cRectTransform;
    private RectTransform gRectTransform;
    private RectTransform tRectTransform;
    private RectTransform aRectTransform;

    private GameObject player;

    public AudioSource dnaPickup;

    void Start()
    {
        numOfCDna = PlayerPrefs.GetInt("cValue", 0);
        numOfGDna = PlayerPrefs.GetInt("gValue", 0);
        numOfTDna = PlayerPrefs.GetInt("tValue", 0);
        numOfADna = PlayerPrefs.GetInt("aValue", 0);
        cCounter.text = numOfCDna.ToString();
        gCounter.text = numOfGDna.ToString();
        tCounter.text = numOfTDna.ToString();
        aCounter.text = numOfADna.ToString();

        player = GameObject.Find("Player");
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CDna")
        {
            dnaPickup.Play();
            animC = GameObject.Find("C_Collected").GetComponent<Animator>(); // animation only plays once for some reason
            animC.Play("cCollected", -1, 0f);
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("cValue", PlayerPrefs.GetInt("cValue", 0) + 1);
            cCounter.text = PlayerPrefs.GetInt("cValue", 0).ToString();
            GameObject c = GameObject.Instantiate(cDnaSlot);
            cRectTransform = cSlot.GetComponent<RectTransform>();
            c.transform.SetParent(cRectTransform);
            c.transform.position = cRectTransform.position;
            c.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (other.tag == "TDna")
        {
            dnaPickup.Play();
            animT = GameObject.Find("T_Collected").GetComponent<Animator>();
            animT.Play("tCollected", -1, 0f);
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("tValue", PlayerPrefs.GetInt("tValue", 0) + 1);
            tCounter.text = PlayerPrefs.GetInt("tValue", 0).ToString();
            GameObject t = GameObject.Instantiate(tDnaSlot);
            tRectTransform = tSlot.GetComponent<RectTransform>();
            t.transform.SetParent(tRectTransform);
            t.transform.position = tRectTransform.position;
            t.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (other.tag == "GDna")
        {
            dnaPickup.Play();
            animG = GameObject.Find("G_Collected").GetComponent<Animator>();
            animG.Play("gCollected", -1, 0f);
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("gValue", PlayerPrefs.GetInt("gValue", 0) + 1);
            gCounter.text = PlayerPrefs.GetInt("gValue", 0).ToString();
            GameObject g = GameObject.Instantiate(gDnaSlot);
            gRectTransform = gSlot.GetComponent<RectTransform>();
            g.transform.SetParent(gRectTransform);
            g.transform.position = gRectTransform.position;
            g.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (other.tag == "ADna")
        {
            dnaPickup.Play();
            animA = GameObject.Find("A_Collected").GetComponent<Animator>();
            animA.Play("C Collected", -1, 0f);
            Destroy(other.gameObject);
            PlayerPrefs.SetInt("aValue", PlayerPrefs.GetInt("aValue", 0) + 1);
            aCounter.text = PlayerPrefs.GetInt("aValue", 0).ToString();
            GameObject a = GameObject.Instantiate(aDnaSlot);
            aRectTransform = aSlot.GetComponent<RectTransform>();
            a.transform.SetParent(aRectTransform);
            a.transform.position = aRectTransform.position;
            a.transform.localScale = new Vector3(1, 1, 1);
        }

        if (other.name == "emptyCollider")
        {
            animArrow = GameObject.Find("Arrow").GetComponent<Animator>();
            animArrow.Play("OpenCC");
            Destroy(other.gameObject);
        }

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
