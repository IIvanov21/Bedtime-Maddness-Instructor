using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallTeddyBear : MonoBehaviour, IActorTemplate
{
    int health;
    int speed;
    int hitPower;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (collider.CompareTag("Player"))
        {
            if (health >= 1) health -= collider.GetComponent<IActorTemplate>().SendDamage();
            if (health <= 0) Die();

            GameManager.Instance.GetComponent<ScoreManager>().SetScore(score);
            Debug.Log("Player's Score: " + GameManager.Instance.GetComponent<ScoreManager>().PlayerScore);
        }
    }
}
