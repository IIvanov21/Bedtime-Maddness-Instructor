using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IActorTemplate
{
    int speed;
    int health;
    int hitPower;
    GameObject actor;
    GameObject fire;

    [SerializeField]
    GameObject shootPoint;


    //Particle System
    [SerializeField]
    ParticleSystem particleSystem;
    bool playParticles = false;
    //Provide access to our health and fire object 
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public GameObject Fire
    {
        get { return fire; }
        set { fire = value; }
    }

    GameObject _Player;

    Rigidbody rb;
    [SerializeField,Range(0,20)]
    float jumpFactor;
    //Capture movement inputs
    float horizontalInput;
    float verticalInput;

    void Start()
    {
        _Player = GameObject.Find("_Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.State == GameState.Play)
        {
            //Keep track of player position
            PlayerPositionUpdate();
            //Movement
            Move();
            ControlParticleSystems();
            //Attack
            Attack();
            //Simple Jump - needs checks for multiple presses
            Jump();
        }
    }

    void PlayerPositionUpdate()
    {
        GameManager.playerPosition = transform.position;
    }

    public void ActorStats(SOActorModel actorModel)
    {
        speed=actorModel.speed;
        health=actorModel.health;
        GameManager.playerHealth = actorModel.health;
        hitPower = actorModel.hitPower;
        fire = actorModel.actorBullets;
    }

    void OnTriggerEnter(Collider collider)
    {
        //If we collide with Enemy
        if (collider.CompareTag("Enemy"))
        {
            //if our health is above 0
            if (health < 100)//Reduce health based on damage from the actor
            {
                health += collider.GetComponent<IActorTemplate>().SendDamage();
                GameManager.playerHealth = health;
                //GameManager.Instance.LifeSystemTracker();
                LevelUI.onLifeUpdate?.Invoke();
            }
            //If health reaches zero after the hit we die
            if (health >= 100) Die();
        }
    }

    public void Die()
    {
        //We will implement behaviour for a GameOver screen in Game Manager
        //for now just destroy player here
        Destroy(gameObject);
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health-=incomingDamage;
    }

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //There are 3 different ways which you can move a character 
        //1.Using simple translate method: 
        //2.Using rigidBody.Move()
        //3.Character controller which allows us precise collision and controls
        //Lets go with number 1 for simplcity
        //Forwards/backwards movement
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        //Left/Right Movement
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Simply create a new bullet at the player's position with given position and rotation
            GameObject bullet = GameObject.Instantiate(fire, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
            bullet.transform.SetParent(_Player.transform);
        }
    }

    void ControlParticleSystems()
    {
        if(horizontalInput == 0 && verticalInput == 0) particleSystem.Stop();
        else if(!particleSystem.isPlaying)  particleSystem.Play();
    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpFactor, ForceMode.Impulse);
        }
    }
}
