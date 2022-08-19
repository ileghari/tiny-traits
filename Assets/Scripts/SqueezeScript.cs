using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueezeScript : MonoBehaviour
{
    // audio
    public AudioSource whoosh;

    public GameObject prefab; //to create key prompt
    private bool hasSqueezeTrait = true;
    private bool keyPressed;
    private bool promptExists;
    private bool canSqueeze;
    [SerializeField] private float speed;
    private float step;
    private Vector3 newPosition; // = new Vector3(10f, 2.0f, 0f);
    private BoxCollider playerCollider;
    private Vector3 startSize;
    private GameObject playerSprite;
    private string moveDirection;
    private Animator anim;

    private GameObject player; //used for player collider object attached on player
    private GameObject playerObject;
    private string[] startStatic;
    private string[] startRun;




    void Start()
    {
        player = GameObject.Find("Player Collider");

        step = speed * Time.deltaTime;
        playerObject = GameObject.Find("Player");
        playerSprite = GameObject.Find("Bunny Sprite");
        playerCollider = player.GetComponent<BoxCollider>();
        startSize = playerCollider.size;
        anim = playerSprite.GetComponent<Animator>();

        keyPressed = false; // indicates if player has accepted "Press K" prompt 
        promptExists = false; // indicates if the prompt is present somewhere on the scene
        canSqueeze = false;
        startStatic = playerSprite.GetComponent<IsometricAnimation3D>().staticDirections;
        startRun = playerSprite.GetComponent<IsometricAnimation3D>().runDirections;
    }


    void Update()
    {

        if (canSqueeze)
        {
            playerObject.GetComponent<IsometricMovement3D>().squeezing = true;
            SetDirection(moveDirection);
            playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, newPosition, step * 2);
        }
        playerObject.GetComponent<CharacterInfo>().squeezing = playerObject.GetComponent<IsometricMovement3D>().squeezing;
        if (playerObject.GetComponent<CharacterInfo>().squeezing == false)
        {
            startStatic = playerSprite.GetComponent<IsometricAnimation3D>().staticDirections;
            startRun = playerSprite.GetComponent<IsometricAnimation3D>().runDirections;
        }


    }


    void OnTriggerStay(Collider other)
    {
        // disable squeeze trait if player has cell wall trait
        if (!playerObject.GetComponent<CharacterInfo>().HasTrait("CellWall"))
        {
            // Create Key Prompt
            if (other.gameObject == player && promptExists == false)
            {
                //create "Press J" Prompt
                Instantiate(prefab, transform.position + new Vector3(-4.1f, 0, 0.9f), Quaternion.identity);
                promptExists = true; // we use prompt exists so it doesn't create a prompt every frame we're in the collider
            }

            // squeezing from bottom left direction toward top right
            if (other.GetComponent<Collider>().name == "Player Collider" && player.transform.position.x < transform.position.x &&
                Mathf.Abs(player.transform.position.z - transform.position.z) < 1f)
            {
                if (hasSqueezeTrait && Input.GetButton("Fire1"))
                {
                    whoosh.Play();
                    // Delete Key Prompt
                    GameObject prompt = GameObject.FindWithTag("JKeyPrompt");
                    Destroy(prompt);

                    // snap player position to axis
                    Vector3 axisSnap = new Vector3(transform.position.x - 0.4f, playerObject.transform.position.y, transform.position.z);
                    playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, axisSnap, 1000 * Time.deltaTime);

                    //get position of where we have to move towards
                    newPosition = new Vector3(
                                        gameObject.GetComponent<Collider>().bounds.center.x + gameObject.GetComponent<Collider>().bounds.extents.x + 0.4f,
                                        playerObject.transform.position.y,
                                        playerObject.transform.position.z
                                    );

                    //shrinking player collider
                    playerCollider.size = new Vector3(0.2f, 1.0f, 0.2f);

                    canSqueeze = true;

                    moveDirection = "SqueezeRight";
                    player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                }
            }

            // squeezing from top right towards bottom left
            if (other.GetComponent<Collider>().name == "Player Collider" && transform.position.x < player.transform.position.x &&
                Mathf.Abs(player.transform.position.z - transform.position.z) < 1f)
            {
                if (hasSqueezeTrait && Input.GetButton("Fire1"))
                {
                    whoosh.Play();
                    // Delete Key Prompt
                    GameObject prompt = GameObject.FindWithTag("JKeyPrompt");
                    Destroy(prompt);

                    // snap player position to axis
                    Vector3 axisSnap = new Vector3(transform.position.x + 0.4f, playerObject.transform.position.y, transform.position.z);
                    playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, axisSnap, 1000 * Time.deltaTime);

                    //get position of where we have to move towards
                    newPosition = new Vector3(
                        gameObject.GetComponent<Collider>().bounds.center.x - gameObject.GetComponent<Collider>().bounds.extents.x - 0.4f,
                        playerObject.transform.position.y,
                        playerObject.transform.position.z
                    );

                    //shrinking player collider
                    playerCollider.size = new Vector3(0.2f, 1.0f, 0.2f);

                    canSqueeze = true;
                    moveDirection = "SqueezeToLeft";
                    player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                }
            }



            // squeezing from bottom right towards top left
            if (other.GetComponent<Collider>().name == "Player Collider" && player.transform.position.z < transform.position.z &&
                Mathf.Abs(player.transform.position.x - transform.position.x) < 1f)
            {
                if (hasSqueezeTrait && Input.GetButton("Fire1"))
                {
                    whoosh.Play();
                    // Delete Key Prompt
                    GameObject prompt = GameObject.FindWithTag("JKeyPrompt");
                    Destroy(prompt);

                    // snap player position to axis
                    playerObject.transform.position = new Vector3(transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z);

                    //get position of where we have to move towards
                    newPosition = new Vector3(
                        playerObject.transform.position.x,
                        playerObject.transform.position.y,
                        gameObject.GetComponent<Collider>().bounds.center.z + gameObject.GetComponent<Collider>().bounds.extents.z + 0.4f
                    );

                    //shrinking player collider
                    playerCollider = player.GetComponent<BoxCollider>();
                    playerCollider.size = new Vector3(0.2f, 1.0f, 0.2f);

                    canSqueeze = true;
                    moveDirection = "SqueezeLeft";
                    player.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                }
            }



            // squeezing from top left towards bottom right 
            if (other.GetComponent<Collider>().name == "Player Collider" && transform.position.z < player.transform.position.z &&
                Mathf.Abs(player.transform.position.x - transform.position.x) < 1f)
            {
                if (hasSqueezeTrait && Input.GetButton("Fire1"))
                {
                    whoosh.Play();
                    // Delete Key Prompt
                    GameObject prompt = GameObject.FindWithTag("JKeyPrompt");
                    Destroy(prompt);

                    // snap player position to axis
                    playerObject.transform.position = new Vector3(transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z);

                    //get position of where we have to move towards
                    newPosition = new Vector3(
                        playerObject.transform.position.x,
                        playerObject.transform.position.y,
                        gameObject.GetComponent<Collider>().bounds.center.z - gameObject.GetComponent<Collider>().bounds.extents.z - 0.4f
                    );

                    //shrinking player collider
                    playerCollider = player.GetComponent<BoxCollider>();
                    playerCollider.size = new Vector3(0.2f, 1.0f, 0.2f);

                    canSqueeze = true;
                    moveDirection = "SqueezeToRight";
                    player.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                }
            }
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player Collider")
        {
            other.GetComponent<Collider>().GetComponent<BoxCollider>().size = startSize;
        }

        canSqueeze = false;
        playerObject.GetComponent<IsometricMovement3D>().squeezing = false;

        playerSprite.GetComponent<IsometricAnimation3D>().staticDirections = startStatic;

        playerSprite.GetComponent<IsometricAnimation3D>().runDirections = startRun;

        // Delete Key Prompt
        GameObject prompt = GameObject.FindWithTag("JKeyPrompt");
        Destroy(prompt);
        promptExists = false;

        // if (other.GetComponent<Collider>().name == "Player Collider")
        // {
        //     // wait for 3 seconds to return collider back to regular value
        //     RunDelayed(3f, () =>
        //     {
        //         playerCollider = other.GetComponent<Collider>().GetComponent<BoxCollider>();
        //         playerCollider.size = new Vector3(1.0f, 1.0f, 1.0f);
        //     });
        // }

    }

    private void SetDirection(string direction)
    {
        string[] newStatic = { direction, direction, direction, direction, direction, direction, direction, direction };
        playerSprite.GetComponent<IsometricAnimation3D>().staticDirections = newStatic;
        string[] newRun = { direction, direction, direction, direction, direction, direction, direction, direction };
        playerSprite.GetComponent<IsometricAnimation3D>().runDirections = newRun;

        anim.Play(direction);
    }

    // code for waiting for x seconds
    protected IEnumerator DelayedCoroutine(float delay, System.Action a)
    {
        yield return new WaitForSeconds(delay);
        a();
    }

    protected Coroutine RunDelayed(float delay, System.Action a)
    {
        return StartCoroutine(DelayedCoroutine(delay, a));
    }


}
