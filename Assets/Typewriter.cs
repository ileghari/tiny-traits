using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Typewriter : MonoBehaviour
{
    private Text txt;
    string story;
    private Animator anim;
    private Animator fadeAnim;
    public bool open;
    public int order;
    private bool played;
    private string[] introOrder = { "Intro1", "Intro2", "Intro3", "Intro4", "Intro5", "Intro6", "Intro7", "Intro8", "Intro9", "Intro10" };

    // Start is called before the first frame update
    void Start()
    {
        played = false;
        fadeAnim = GameObject.Find("FadeToBlack").GetComponent<Animator>();
        anim = GetComponentInParent<Animator>();
        txt = GetComponent<Text>();
        story = txt.text;
        txt.text = "";
    }

    void Update()
    {
        if (open && played == false)
        {
            //Debug.Log("In" + order);
            anim.Play("FadeIn");
            open = false;
            OpenIntro();
            played = true;
        }
        if (Input.anyKeyDown && played == true)
        {
            played = false;
            //Debug.Log("Out"+order);
            if (order == 9) fadeAnim.Play("FadeOut");
            anim.Play("IntroDone");
            StopCoroutine("PlayText");
            GameObject.Find(introOrder[order + 1] + "/Text").GetComponent<Typewriter>().open = true;
        }
    }

    // Update is called once per frame
    public void OpenIntro()
    {
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            yield return new WaitForSeconds(0.03f);
            txt.text += c;
        }
    }
}
