using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationDNA : MonoBehaviour
{



    public float degreesPerSecond = 20;
    private Animator anim;

    void Start()
    {
        anim = GameObject.Find("A_Collected").GetComponent<Animator>();
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime * 6);
    }


    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.name == "Player Collider")
    //     {
    //         anim.Play("C Collected");
    //         Destroy(gameObject);
    //         numOfDNACollected++;
    //         Debug.Log(numOfDNACollected);
    //     }
    // }
}
