using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Add the scirptable object as part of our Assets Create Menu
[CreateAssetMenu(fileName ="Create Actor",menuName ="Create Actor")]
public class SOActorModel : ScriptableObject
{
    //Give our actor a name
    public string actorName;

    //List all of the Actors we will have for our game
    public enum ActorType
    {
        Player,
        SmallTeddyBear,
        BigTeddyBear,
        Bullet,
        BossTeddyBear,
    }
    public ActorType actorType;//Value to store the type

    public string description;//Additional information we can use for our actor
    //Default values that the actor contains
    public int health;
    public int speed;
    public int hitPower;
    public int score;
    public GameObject actor;
    public GameObject actorBullets;
}
