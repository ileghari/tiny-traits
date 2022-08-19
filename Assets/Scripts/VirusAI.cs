using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class VirusAI : MonoBehaviour
{
    public float degreesPerSecond = 20;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask WhatisGround, WhatisPlayer;

    public TextMeshProUGUI virusWarningText;

    // Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Player")
        {

            bool cellwall = coll.gameObject.GetComponent<CharacterInfo>().HasTrait("CellWall");
            if (!cellwall)
            {
                PlayerPrefs.SetInt("showWarning", 0); // 0 - don't show warning
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);

            }

        }
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatisPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatisPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange) ChasePlayer();
        if (playerInAttackRange) AttackPlayer();
    }

    private void Patrolling()
    {

        transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime * 6);


    }

    private void setWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, WhatisGround))
        {
            walkPointSet = true;
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

    }
    private void AttackPlayer()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);


    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
