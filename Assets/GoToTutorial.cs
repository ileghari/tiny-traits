using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToTutorial : MonoBehaviour
{
    private int nextscene;
    // public int scene;
    void Start()
    {
        nextscene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Update()
    {
        StartCoroutine(WaitForAnim());
    }

    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(17.5f);
        SceneManager.LoadScene(nextscene);
    }
}
