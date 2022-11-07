using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    public static int currentScene = 0;
    public static int gameLevelScenes = 4;

    private bool died = false;
    public bool Died
    {
        get { return died; }
        set { died = value; }
    }

    public static int playerHealth=0;

    private void Awake()
    {
        CheckGamanager();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        LightSetup(currentScene);

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //Camera settings
    void CameraSetup()
    {
        //Get the camera game object first
        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //At this point for extra security we can access the player and make the camera a child
        //but since we know that the camera will be a child let's not do that to save performance.

        //Default view will start with first person camera
        gameCamera.transform.localPosition = new Vector3(0.0f, 0.5f, 0.3f);
        gameCamera.transform.eulerAngles = Vector3.zero;
        gameCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;

    }


    void LightSetup(int sceneIndex)
    {

        switch (sceneIndex)
        {
            //WaveOne,WaveTwo,WaveThree,WaveBoss
            case 3 : case 4 : case 5 : case 6 :
                {
                    //Set default light settings for our Game Levels only 
                    GameObject dirLight = GameObject.Find("Directional Light");
                    dirLight.transform.position = new Vector3(0.0f, 20.0f, -20.0f);
                    dirLight.transform.eulerAngles = new Vector3(25.0f, 0.0f, 15.0f);
                    dirLight.GetComponent<Light>().color = new Color32(85, 95, 100, 255);
                    break;
                }
        }
    }

    void CheckGamanager()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this.gameObject);
    }

    public void LifeSystemTracker()
    {
        if (playerHealth < 100)//Simulate we have been hit
        {
            Debug.Log("Player's current suffocation is:" + playerHealth + "%!");
        }
        else//Simulate we die
        {
            Debug.Log("Player's current suffocation is:" + playerHealth + "%! We are dead!");
            GetComponent<ScenesManager>().GameOver();

        }

    }
}
