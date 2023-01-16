using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTedyBear : Enemy
{
    //Patrol variables
    private float distanceToPatrolPoint;
    private Vector3 startingPos;
    bool patrol = true;
    bool patrolSwitch = true;

    GameObject[] patrolPoints;
    GameObject patrolPoint;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;

        //Setup patrol points 

        //Get a random patrol point
        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");
        patrolPoint = patrolPoints[Random.Range(0, patrolPoints.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.State == GameState.Play)
        {
            patrol = LookingAtPlayer();

            if (patrol) Patrol();
            else Chase();
        }
    }

    public void Patrol()
    {


        //Calculate distance
        if (patrolSwitch)
        {
            distanceToPatrolPoint = Vector3.Distance(transform.position, patrolPoint.transform.position);
            agent.destination = patrolPoint.transform.position;
            if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = false;
        }
        else
        {
            distanceToPatrolPoint = Vector3.Distance(transform.position, startingPos);
            agent.destination = startingPos;
            if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = true;
        }

    }
}
