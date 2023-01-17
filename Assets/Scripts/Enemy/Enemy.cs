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
    [SerializeField]protected NavMeshAgent agent;

    
    //Chase variables
    private float distanceToPlayer;

    //Facing values
    Vector3 directionToPlayer;
    float angel;
    [SerializeField]
    private float minDistanceToPlayer = 2.0f;

    protected GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActorStats(SOActorModel actorModel)
    {
        health = actorModel.health;
        speed = actorModel.speed;
        hitPower = actorModel.hitPower;
        score=actorModel.score;
        actorType = actorModel.actorType;
        bullet = actorModel.actorBullets;
    }

    public void Die()
    {
        Destroy(gameObject);
        
        if (actorType == SOActorModel.ActorType.BossTeddyBear)
        {
            GameManager.Instance.GetComponent<ScenesManager>().GameOver(); 
        }
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
            //Debug.Log("Player's Score: " + GameManager.Instance.GetComponent<ScoreManager>().PlayerScore);
            LevelUI.onScoreUpdate?.Invoke();
        }
    }

    public bool LookingAtPlayer()
    {
        directionToPlayer = transform.position - GameManager.playerPosition;
        angel = Vector3.Angle(transform.forward, directionToPlayer);
        //Debug.Log("Angle: " + angel);
        distanceToPlayer = Vector3.Distance(transform.position, GameManager.playerPosition) ;

        if (distanceToPlayer < minDistanceToPlayer && FacingPlayer())
        {
            return false;
        }
        else return true;
    }

    bool FacingPlayer()
    {
        if (Mathf.Abs(angel) > 90.0f && Mathf.Abs(angel) < 270.0f) return true;
        else return false;
    }

    

    public void Chase()
    {
        //Debug.Log(agent);
        agent.destination = GameManager.playerPosition;

        distanceToPlayer = Vector3.Distance(transform.position, GameManager.playerPosition);

       
        if (distanceToPlayer < minDistanceToPlayer)
        {
            agent.destination = GameManager.playerPosition;
            distanceToPlayer = Vector3.Distance(transform.position, GameManager.playerPosition);
        }
    }

    
}
