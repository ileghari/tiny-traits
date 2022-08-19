// Eric Sakkas - 2/28/2022
// Script for moving 2D sprite in 3D Isometric Space
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMovement3D : MonoBehaviour
{
    private Rigidbody rb;
    private float moveH, moveV;
    [SerializeField] public float moveSpeed = 1.0f;
    public bool squeezing; //turns off speed if moving
    public bool pushX;
    public bool pushZ;
    private GameObject playerSprite;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        squeezing = false;
        playerSprite = GameObject.Find("Bunny Sprite");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (squeezing == false)
        {
            moveH = Input.GetAxis("Horizontal") * moveSpeed;
            moveV = Input.GetAxis("Vertical") * moveSpeed;
            rb.velocity = new Vector3(moveH, 0, moveV);
            rb.velocity = Quaternion.AngleAxis(45, Vector3.up) * rb.velocity;

            Vector3 direction = new Vector3(moveH, 0, moveV);
            playerSprite.GetComponent<IsometricAnimation3D>().SetDirection(direction);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
