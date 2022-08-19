using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPushing : MonoBehaviour
{
    private Rigidbody rigidbody; //rigidbody of the capsule
    private BoxCollider playerCol;
    private BoxCollider capsuleCol;
    public GameObject prefab; //to create key prompt
    private GameObject player; //player object
    private bool keyPressed; //test if key K has been pressed
    private bool promptExists; //test if key prompt exists
    private GameObject sprite;
    private float startSpeed;
    public bool pushing;
    public string pushAxis;
    private Vector3 oldSizeCapsule;
    private Vector3 oldSizeCenter;

    // List of static and moving animations for Push Trait and CellWall+Push Trait
    private string[] pushStatic = { "StaticPush N", "StaticPush NW", "StaticPush W", "StaticPush SW", "StaticPush S", "StaticPush SE", "StaticPush E", "StaticPush NE" };
    private string[] pushRun = { "Push N", "Push NW", "Push W", "Push SW", "Push S", "Push SE", "Push E", "Push NE" };
    private string[] cellStatic = { "CellPushStatic N", "CellPushStatic NW", "CellPushStatic W", "CellPushStatic SW", "CellPushStatic S", "CellPushStatic SE", "CellPushStatic E", "CellPushStatic NE" };
    private string[] cellRun = { "CellPush N", "CellPush NW", "CellPush W", "CellPush SW", "CellPush S", "CellPush SE", "CellPush E", "CellPush NE" };

    public AudioSource pilliClick;
    public AudioSource cantPush;



    void Start()
    {
        player = GameObject.Find("Player");
        playerCol = GameObject.Find("Player Collider").GetComponent<BoxCollider>();
        sprite = GameObject.Find("Bunny Sprite");
        rigidbody = GetComponent<Rigidbody>();
        capsuleCol = GetComponent<BoxCollider>();
        startSpeed = player.GetComponent<IsometricMovement3D>().moveSpeed;

        oldSizeCapsule = capsuleCol.size;
        oldSizeCenter = capsuleCol.center;

        pushing = false;      //indicates if player is pushing on that frame
        keyPressed = false;   // indicates if player has accepted "Press K" prompt 
        promptExists = false; // indicates if the prompt is present somewhere on the scene

        rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX |
       RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
       RigidbodyConstraints.FreezeRotationZ; // starts by making all capsules freeze completely, changed only if CAM attaches
    }

    void Update()
    {
        player.GetComponent<CharacterInfo>().pushing = pushing;

        // if prompt exists and player accepts prompt, delete the prompt
        if (promptExists && Input.GetButtonDown("Fire2"))
        {
            keyPressed = true;
            GameObject prompt = GameObject.FindWithTag("KKeyPrompt");
            Destroy(prompt);
        }

        if (pushing == true && Input.GetButtonDown("Fire2"))
        {
            keyPressed = false;

            StopPushingAnim();

            rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX |
            RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
            RigidbodyConstraints.FreezeRotationZ; // starts by making all capsules freeze completely, changed only if CAM attaches

            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY
                | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                    RigidbodyConstraints.FreezeRotationZ; //Unfreezes Z position of player
            Destroy(GetComponent<FixedJoint>());
            capsuleCol.center = oldSizeCenter;
            capsuleCol.size = oldSizeCapsule;
            playerCol.enabled = true;
            pushing = false;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject == player)
        {

            player.GetComponent<IsometricMovement3D>().moveSpeed = startSpeed; // reset move speed to default
            keyPressed = false;
            promptExists = false;
            rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX |
                RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ; //freeze all capsules again
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY
                | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                    RigidbodyConstraints.FreezeRotationZ; // returns to normal player movement

            // destroy "Press K" prompt because player has left collision area
            GameObject prompt = GameObject.FindWithTag("KKeyPrompt");
            Destroy(prompt);

            StopPushingAnim();

            pushing = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // if player is colliding with capsule in a spot where they can push it
        if (pushAxis == "X" && collision.gameObject == player && player.transform.position.x < transform.position.x &&
            Mathf.Abs(player.transform.position.z - transform.position.z) < 0.3f && player.GetComponent<CharacterInfo>().HasTrait("Push"))
        {
            if (promptExists == false)
            {
                //create "Press K" Prompt
                Instantiate(prefab, transform.position + new Vector3(-4.1f, 0, 0.9f), Quaternion.identity);
                promptExists = true;
            }

        }
        if (pushAxis == "Z" && collision.gameObject == player &&
            Mathf.Abs(player.transform.position.x - transform.position.x) < 0.3f && player.GetComponent<CharacterInfo>().HasTrait("Push"))
        {
            if (promptExists == false)
            {
                //create "Press K" Prompt
                Instantiate(prefab, transform.position + new Vector3(-4.1f, 0, 0.9f), Quaternion.identity);
                promptExists = true;
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (pushAxis == "X")
        {
            if (collision.gameObject == player && player.transform.position.x < transform.position.x &&
            Mathf.Abs(player.transform.position.z - transform.position.z) < 0.4f && player.GetComponent<CharacterInfo>().HasTrait("Push"))
            { // Pushiing from bottom left direction toward top right
                if (promptExists == false)
                {
                    // creates a prompt if player is already pushing against a block and slides to another block
                    // very rare case encountered in bug fixing, can ignore
                    Instantiate(prefab, transform.position + new Vector3(-4.1f, 0, 0.9f), Quaternion.identity);
                    promptExists = true;
                }
                //if player accepts prompt
                if (keyPressed == true && pushing == false)
                {
                    pilliClick.Play();
                    player.GetComponent<IsometricMovement3D>().moveSpeed = 3.5f;
                    Vector3 axisSnap = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
                    player.transform.position = Vector3.MoveTowards(player.transform.position, axisSnap, 1000 * Time.deltaTime);//snap player in line with capsule position

                    pushing = true;
                    FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                    joint.anchor = collision.contacts[0].point;
                    joint.connectedBody = collision.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
                    GameObject.Find("Player Collider").transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);

                    playerCol.enabled = false;
                    capsuleCol.center = new Vector3(0, 0, -0.638576865f);
                    capsuleCol.size = new Vector3(0.949999988f, 2, 2.22715378f);
                    rigidbody.velocity = 1.45f * player.GetComponent<Rigidbody>().velocity;

                    rigidbody.constraints = RigidbodyConstraints.FreezePositionY | ~RigidbodyConstraints.FreezePositionX |
                        RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                        RigidbodyConstraints.FreezeRotationZ; //Unfreezes Z position of capsule
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | ~RigidbodyConstraints.FreezePositionX |
                       RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                        RigidbodyConstraints.FreezeRotationZ; //Unfreezes Z position of player

                    if (player.GetComponent<CharacterInfo>().HasTrait("CellWall"))
                    {
                        string[] newRun = { "CellPushRight", "CellPushRight", "CellPushRight", "CellPushRight", "CellPushRight", "CellPushRight", "CellPushRight", "CellPushRight" }; //change animation to CAM
                        sprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;
                        sprite.GetComponent<IsometricAnimation3D>().staticDirections = newRun;
                    }
                    else
                    {
                        string[] newRun = { "PushRight", "PushRight", "PushRight", "PushRight", "PushRight", "PushRight", "PushRight", "PushRight" }; //change animation to CAM
                        sprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;
                        sprite.GetComponent<IsometricAnimation3D>().staticDirections = newRun;
                    }

                }

            }
            if (collision.gameObject == player && player.transform.position.x < transform.position.x &&
            Mathf.Abs(player.transform.position.z - transform.position.z) < 0.4f && !player.GetComponent<CharacterInfo>().HasTrait("Push") &&
            Input.GetButtonDown("Fire2") && pushing == false)
            {
                StartCoroutine("CantPush", "NE");
            }
            if (collision.gameObject == player && player.transform.position.x > transform.position.x &&
        Mathf.Abs(player.transform.position.z - transform.position.z) < 0.4f && player.GetComponent<CharacterInfo>().HasTrait("Push"))
            { // Pushiing from top right to bottom left
                if (promptExists == false)
                {
                    // creates a prompt if player is already pushing against a block and slides to another block
                    // very rare case encountered in bug fixing, can ignore
                    Instantiate(prefab, transform.position + new Vector3(-4.1f, 0, 0.9f), Quaternion.identity);
                    promptExists = true;
                }
                //if player accepts prompt
                if (keyPressed == true && pushing == false)
                {
                    pilliClick.Play();
                    player.GetComponent<IsometricMovement3D>().moveSpeed = 3.5f;
                    Vector3 axisSnap = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y, transform.position.z);
                    player.transform.position = Vector3.MoveTowards(player.transform.position, axisSnap, 1000 * Time.deltaTime);//snap player in line with capsule position

                    pushing = true;
                    FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                    joint.anchor = collision.contacts[0].point;
                    joint.connectedBody = collision.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
                    GameObject.Find("Player Collider").transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);

                    playerCol.enabled = false;
                    capsuleCol.center = new Vector3(0, 0, 0.617944837f);
                    capsuleCol.size = new Vector3(0.949999988f, 2, 2.53097963f);
                    rigidbody.velocity = 1.45f * player.GetComponent<Rigidbody>().velocity;

                    rigidbody.constraints = RigidbodyConstraints.FreezePositionY | ~RigidbodyConstraints.FreezePositionX |
                        RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                        RigidbodyConstraints.FreezeRotationZ; //Unfreezes Z position of capsule
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | ~RigidbodyConstraints.FreezePositionX |
                       RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                        RigidbodyConstraints.FreezeRotationZ; //Unfreezes Z position of player

                    if (player.GetComponent<CharacterInfo>().HasTrait("CellWall"))
                    {
                        string[] newRun = { "BackCellRight", "BackCellRight", "BackCellRight", "BackCellRight", "BackCellRight", "BackCellRight", "BackCellRight", "BackCellRight" }; //change animation to CAM
                        sprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;
                        sprite.GetComponent<IsometricAnimation3D>().staticDirections = newRun;
                    }
                    else
                    {
                        string[] newRun = { "BackRight", "BackRight", "BackRight", "BackRight", "BackRight", "BackRight", "BackRight", "BackRight" }; //change animation to CAM
                        sprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;
                        sprite.GetComponent<IsometricAnimation3D>().staticDirections = newRun;
                    }

                }

            }
            if (collision.gameObject == player && player.transform.position.x > transform.position.x &&
        Mathf.Abs(player.transform.position.z - transform.position.z) < 0.4f && !player.GetComponent<CharacterInfo>().HasTrait("Push") &&
            Input.GetButtonDown("Fire2") && pushing == false)
            {
                StartCoroutine("CantPush", "SW");
            }
        }

        if (pushAxis == "Z")
        {
            if (collision.gameObject == player && player.transform.position.z < transform.position.z &&
            Mathf.Abs(player.transform.position.x - transform.position.x) < 0.4f && player.GetComponent<CharacterInfo>().HasTrait("Push"))
            { // Pushiing from bottom right direction toward top left
                if (promptExists == false)
                {
                    // creates a prompt if player is already pushing against a block and slides to another block
                    // very rare case encountered in bug fixing, can ignore
                    Instantiate(prefab, transform.position + new Vector3(-4.1f, 0, 0.9f), Quaternion.identity);
                    promptExists = true;
                }
                //if player accepts prompt
                if (keyPressed == true && pushing == false)
                {
                    pilliClick.Play();
                    player.GetComponent<IsometricMovement3D>().moveSpeed = 3.5f; //decrease movement speed when pushing capsule
                    Vector3 axisSnap = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z + 0.01f);
                    player.transform.position = Vector3.MoveTowards(player.transform.position, axisSnap, 1000 * Time.deltaTime);//snap player in line with capsule position

                    pushing = true;
                    FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                    joint.anchor = collision.contacts[0].point;
                    joint.connectedBody = collision.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
                    GameObject.Find("Player Collider").transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);

                    playerCol.enabled = false;
                    capsuleCol.center = new Vector3(0, 0, -0.802034736f);
                    capsuleCol.size = new Vector3(0.949999988f, 2, 2.55406976f);
                    rigidbody.velocity = 1.45f * player.GetComponent<Rigidbody>().velocity;

                    rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX |
                        ~RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                        RigidbodyConstraints.FreezeRotationZ; //Unfreezes Z position of capsule
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX |
                        ~RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                        RigidbodyConstraints.FreezeRotationZ; //Unfreezes Z position of player

                    if (player.GetComponent<CharacterInfo>().HasTrait("CellWall"))
                    {
                        string[] newRun = { "CellPushLeft", "CellPushLeft", "CellPushLeft", "CellPushLeft", "CellPushLeft", "CellPushLeft", "CellPushLeft", "CellPushLeft" }; //change animation to CAM
                        sprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;
                        sprite.GetComponent<IsometricAnimation3D>().staticDirections = newRun;
                    }
                    else
                    {
                        string[] newRun = { "PushLeft", "PushLeft", "PushLeft", "PushLeft", "PullRight", "PullRight", "PullRight", "PullRight" }; //change animation to CAM
                        sprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;
                        sprite.GetComponent<IsometricAnimation3D>().staticDirections = newRun;
                    }
                }
            }
            if (collision.gameObject == player && player.transform.position.z < transform.position.z &&
            Mathf.Abs(player.transform.position.x - transform.position.x) < 0.4f && !player.GetComponent<CharacterInfo>().HasTrait("Push") &&
            Input.GetButtonDown("Fire2") && pushing == false)
            {
                StartCoroutine("CantPush", "NW");
            }
            if (collision.gameObject == player && player.transform.position.z > transform.position.z &&
        Mathf.Abs(player.transform.position.x - transform.position.x) < 0.4f && player.GetComponent<CharacterInfo>().HasTrait("Push"))
            { // Pushiing from bottom right direction toward top left
                if (promptExists == false)
                {
                    // creates a prompt if player is already pushing against a block and slides to another block
                    // very rare case encountered in bug fixing, can ignore
                    Instantiate(prefab, transform.position + new Vector3(-4.1f, 0, 0.9f), Quaternion.identity);
                    promptExists = true;
                }
                //if player accepts prompt
                if (keyPressed == true && pushing == false)
                {
                    pilliClick.Play();
                    player.GetComponent<IsometricMovement3D>().moveSpeed = 3.5f; //decrease movement speed when pushing capsule
                    Vector3 axisSnap = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z - 0.5f);
                    player.transform.position = Vector3.MoveTowards(player.transform.position, axisSnap, 1000 * Time.deltaTime);//snap player in line with capsule position

                    pushing = true;
                    FixedJoint joint = gameObject.AddComponent<FixedJoint>();
                    joint.anchor = collision.contacts[0].point;
                    joint.connectedBody = collision.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
                    GameObject.Find("Player Collider").transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);

                    playerCol.enabled = false;
                    capsuleCol.center = new Vector3(0, 0, 0.614319563f);
                    capsuleCol.size = new Vector3(0.949999988f, 2, 2.52372885f);
                    rigidbody.velocity = 1.45f * player.GetComponent<Rigidbody>().velocity;

                    rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX |
                        ~RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                        RigidbodyConstraints.FreezeRotationZ; //Unfreezes Z position of capsule
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX |
                        ~RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY |
                        RigidbodyConstraints.FreezeRotationZ; //Unfreezes Z position of player
                    if (player.GetComponent<CharacterInfo>().HasTrait("CellWall"))
                    {
                        string[] newRun = { "BackCellLeft", "BackCellLeft", "BackCellLeft", "BackCellLeft", "BackCellLeft", "BackCellLeft", "BackCellLeft", "BackCellLeft" }; //change animation to CAM
                        sprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;
                        sprite.GetComponent<IsometricAnimation3D>().staticDirections = newRun;
                    }
                    else
                    {
                        string[] newRun = { "BackLeft", "BackLeft", "BackLeft", "BackLeft", "BackLeft", "BackLeft", "BackLeft", "BackLeft" }; //change animation to CAM
                        sprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;
                        sprite.GetComponent<IsometricAnimation3D>().staticDirections = newRun;
                    }
                }
            }
            if (collision.gameObject == player && player.transform.position.z > transform.position.z &&
        Mathf.Abs(player.transform.position.x - transform.position.x) < 0.4f && !player.GetComponent<CharacterInfo>().HasTrait("Push") &&
            Input.GetButtonDown("Fire2") && pushing == false)
            {
                StartCoroutine("CantPush", "SE");
            }
        }

    }

    IEnumerator CantPush(string direction)
    {
        cantPush.Play();
        player.GetComponent<IsometricMovement3D>().moveSpeed = 0;
        string[] oldStatic = sprite.GetComponent<IsometricAnimation3D>().staticDirections;
        string[] oldDirections = sprite.GetComponent<IsometricAnimation3D>().runDirections;
        string[] newRun = { "CantPush" + direction, "CantPush" + direction, "CantPush" + direction, "CantPush" + direction, "CantPush" + direction, "CantPush" + direction, "CantPush" + direction, "CantPush" + direction }; //change animation to CAM
        sprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;
        sprite.GetComponent<IsometricAnimation3D>().staticDirections = newRun;
        yield return new WaitForSeconds(0.75f);
        sprite.GetComponent<IsometricAnimation3D>().staticDirections = oldStatic;
        sprite.GetComponent<IsometricAnimation3D>().runDirections = oldDirections;
        player.GetComponent<IsometricMovement3D>().moveSpeed = startSpeed;
        StopCoroutine("CantPush");
    }

    private void StopPushingAnim()
    {
        // Player has only Push trait
        if (!player.GetComponent<CharacterInfo>().HasTrait("CellWall") && player.GetComponent<CharacterInfo>().HasTrait("Push"))
        {
            sprite.GetComponent<IsometricAnimation3D>().staticDirections = pushStatic;
            sprite.GetComponent<IsometricAnimation3D>().runDirections = pushRun;
        }
        // Player has both push and cell wall trait
        if (player.GetComponent<CharacterInfo>().HasTrait("CellWall") && player.GetComponent<CharacterInfo>().HasTrait("Push"))
        {
            sprite.GetComponent<IsometricAnimation3D>().staticDirections = cellStatic;
            sprite.GetComponent<IsometricAnimation3D>().runDirections = cellRun;
        }
    }
}
