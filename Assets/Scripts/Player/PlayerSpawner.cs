using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    SOActorModel actorModel;
    GameObject playerObject;
    [SerializeField]
    string selectedPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlayer()
    {
        //Define the default of our player
        //Create player using the scriptable object information
        actorModel = Object.Instantiate(Resources.Load(selectedPlayerName)) as SOActorModel;//Load all the information
        playerObject = GameObject.Instantiate(actorModel.actor) as GameObject;//Create the actual player GameObject

        //Set the player properties i.e. start position, name, position
        playerObject.transform.SetParent(this.transform);//Make the Player spawner parent object
        playerObject.name = "Player";//By default we want our player name to be "Player"

        //Find the scene starting position and set that as the player's starting position
        GameObject startingPosition = GameObject.Find("Starting Position");
        playerObject.transform.position = startingPosition.transform.position;
        playerObject.transform.rotation=Quaternion.Euler(0f, 0f, 0f);
        playerObject.GetComponent<IActorTemplate>().ActorStats(actorModel);
    }
}
