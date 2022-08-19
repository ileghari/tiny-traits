using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricAnimation3D : MonoBehaviour
{
    private Animator anim;
    private GameObject playerCollider;
    private GameObject player;
    public string[] staticDirections = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    public string[] runDirections = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };
    public float angle;
    int lastDirection;
    private bool squeezing;
    private bool pushing;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        playerCollider = GameObject.Find("Player Collider");
    }

    // Update is called once per frame
    public void SetDirection(Vector3 _direction)
    {
        string[] directionArray = null;

        if(_direction.magnitude < 0.01)
        {
            directionArray = staticDirections;
        }
        else
        {
            directionArray = runDirections;

            lastDirection = DirectionToIndex(_direction);
        }

        anim.Play(directionArray[lastDirection]);
        squeezing = player.GetComponent<CharacterInfo>().squeezing;
        pushing = player.GetComponent<CharacterInfo>().pushing;
        if (squeezing == false && pushing == false)
        {
            playerCollider.transform.rotation = Quaternion.Euler(0.0f, lastDirection * (-45.0f) - 45.0f, 0.0f);
        }
    }
    private int DirectionToIndex(Vector3 _direction)
    {
        Vector3 norDir = _direction.normalized;
        Vector3 forward = new Vector3(1, 0, 1);

        float step = 360 / 8;
        float offset = step / 2;

        angle = Vector3.SignedAngle(forward, norDir, Vector3.up);
        angle = -(angle + 45);

        angle += offset;
        if (angle < 0)
        {
            angle += 360;
        }
        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
}
