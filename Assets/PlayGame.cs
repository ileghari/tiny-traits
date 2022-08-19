using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayGame : MonoBehaviour
{
    private int nextscene;
    private Animator fade;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("FadeToBlack").GetComponent<Animator>();
        anim = GameObject.Find("Burst").GetComponent<Animator>();
        nextscene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public IEnumerator Fade()
    {
        anim.Play("Burst");
        fade.Play("FadeToBlack");
        yield return new WaitForSeconds(1.8f);
        SceneManager.LoadScene(nextscene);
    }

    public void PlayGameButton()
    {
        StartCoroutine(Fade());
    }
}
