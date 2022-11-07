using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour, IActorTemplate
{
    //Normal actor values
    GameObject actor;
    int health;
    int hitPower;
    int speed;

    //Custom actor properties
    [SerializeField]
    SOActorModel bulletModel;

    void Awake()
    {
        ActorStats(bulletModel);
    }

    void Update()
    {
        transform.position += transform.forward*speed * Time.deltaTime;  
    }

    public void ActorStats(SOActorModel actorModel)
    {
        health=actorModel.health;
        hitPower=actorModel.hitPower;
        speed=actorModel.speed;
        actor=actorModel.actor;
    }

    public void Die()
    {
        Destroy(this.gameObject);
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
        if (collider.CompareTag("Enemy"))
        {
            //Check if enemy object contains an Actor interface
            //if it doesn't it's most likely an obstacle
            if (collider.GetComponent<IActorTemplate>() != null)
            {
                //We dont destroy the bullet straight away as we might have upgrades applied.
                if (health >= 1) health -= collider.GetComponent<IActorTemplate>().SendDamage();

                if (health <= 0) Die();
            }
        }
    }

    //When the bullet is not visable we want to destroy it
    //Unity has a handy function for this
    void OnBecameInvisible()
    {
        Die();
    }
}
