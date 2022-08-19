using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyMusic : MonoBehaviour
{
    void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("gameMusic");

        if (musicObj.Length > 1)
        {
            Destroy(transform.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);

    }

}
