using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyScript : MonoBehaviour
{

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        int cCounter = PlayerPrefs.GetInt("cValue", 0);
        for (int i = 0; i < cCounter; i++)
        {
            GameObject c = GameObject.Instantiate(cDnaSlot);
            cRectTransform = cSlot.GetComponent<RectTransform>();
            c.transform.SetParent(cRectTransform);
            c.transform.position = cRectTransform.position;
            c.transform.localScale = new Vector3(1, 1, 1);
        }

        int tCounter = PlayerPrefs.GetInt("tValue", 0);
        for (int i = 0; i < tCounter; i++)
        {
            GameObject t = GameObject.Instantiate(tDnaSlot);
            tRectTransform = tSlot.GetComponent<RectTransform>();
            t.transform.SetParent(tRectTransform);
            t.transform.position = tRectTransform.position;
            t.transform.localScale = new Vector3(1, 1, 1);
        }

        int gCounter = PlayerPrefs.GetInt("gValue", 0);
        for (int i = 0; i < gCounter; i++)
        {
            GameObject g = GameObject.Instantiate(gDnaSlot);
            gRectTransform = gSlot.GetComponent<RectTransform>();
            g.transform.SetParent(gRectTransform);
            g.transform.position = gRectTransform.position;
            g.transform.localScale = new Vector3(1, 1, 1);
        }

        int aCounter = PlayerPrefs.GetInt("aValue", 0);
        for (int i = 0; i < aCounter; i++)
        {
            GameObject a = GameObject.Instantiate(aDnaSlot);
            aRectTransform = aSlot.GetComponent<RectTransform>();
            a.transform.SetParent(aRectTransform);
            a.transform.position = aRectTransform.position;
            a.transform.localScale = new Vector3(1, 1, 1);
        }
    }









}

// variable of how many spawned each Level
// if theres difference, iterate 

// increment upto how many u have