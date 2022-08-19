using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    private Vector3 axisSnap;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Sprite");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            axisSnap = new Vector3(player.transform.position.x + 10, player.transform.position.y, player.transform.position.z);
            player.transform.position = Vector3.MoveTowards(player.transform.position, axisSnap, 100);//snap player in line 
        }
    }
}
