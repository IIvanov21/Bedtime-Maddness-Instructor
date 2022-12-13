using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour, IActorTemplate
{
    int health;
    int speed;
    int hitPower;
    int score;
    SOActorModel.ActorType actorType;
    NavMeshAgent agent;

    //Patrol variables
    private float distanceToPatrolPoint;
    private Vector3 startingPos;
    bool patrol=true;
    bool patrolSwitch = true;

    GameObject[] patrolPoints;
    GameObject patrolPoint;
    //Chase variables
    private float distanceToPlayer;

    //Facing values
    Vector3 directionToPlayer;
    float angel;
    [SerializeField]
    private float minDistanceToPlayer = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
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
            if (actorType == SOActorModel.ActorType.SmallTeddyBear)
            {
                agent.destination = GameManager.playerPosition;
            }
            else if (actorType == SOActorModel.ActorType.BigTeddyBear)
            {
                LookingAtPlayer();

                if (patrol) Patrol();
                else Chase();              
                
            }
        }
    }

    public void ActorStats(SOActorModel actorModel)
    {
        health = actorModel.health;
        speed = actorModel.speed;
        hitPower = actorModel.hitPower;
        score=actorModel.score;
        actorType = actorModel.actorType;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Bullet"))
        {
            if (health >= 1) health -= collider.GetComponent<IActorTemplate>().SendDamage();
            if (health <= 0) Die();

            GameManager.Instance.GetComponent<ScoreManager>().SetScore(score);
            Debug.Log("Player's Score: " + GameManager.Instance.GetComponent<ScoreManager>().PlayerScore);
            //GameManager.Instance.ScoreSystem();
            LevelUI.onScoreUpdate?.Invoke();
        }
    }

    void LookingAtPlayer()
    {
        directionToPlayer = transform.position - GameManager.playerPosition;
        angel = Vector3.Angle(transform.forward, directionToPlayer);
        Debug.Log("Angle: " + angel);
        distanceToPlayer = Vector3.Distance(transform.position, GameManager.playerPosition) ;

        if (distanceToPlayer < minDistanceToPlayer && FacingPlayer())
        {
            patrol = false;
        }
        else patrol = true;
    }

    bool FacingPlayer()
    {
        if (Mathf.Abs(angel) > 90.0f && Mathf.Abs(angel) < 270.0f) return true;
        else return false;
    }

    void Patrol()
    {
       

        //Calculate distance
        if (patrolSwitch)
        {
            distanceToPatrolPoint = Vector3.Distance(transform.position, patrolPoint.transform.position);
            agent.destination=patrolPoint.transform.position;
            if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = false;
        }
        else
        {
            distanceToPatrolPoint = Vector3.Distance(transform.position, startingPos);
            agent.destination = startingPos;
            if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = true;
        }
        
    }

    void Chase()
    {
        agent.destination = GameManager.playerPosition;

        distanceToPlayer = Vector3.Distance(transform.position, GameManager.playerPosition);

     
        if (distanceToPlayer < minDistanceToPlayer)
        {
            agent.destination = GameManager.playerPosition;
            distanceToPlayer = Vector3.Distance(transform.position, GameManager.playerPosition);
        }
    }
}
