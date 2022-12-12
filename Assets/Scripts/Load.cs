using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class Load : MonoBehaviour
{
    string jsonString;
    SaveStructure loadStructure;

    private void Start()
    {
        if (GameManager.loadLevel)
        {
            GameManager.State = GameState.Play;
            Time.timeScale = 1;
            Player player = GameObject.FindObjectOfType<Player>();
            player.Health = loadStructure.health;
            player.gameObject.transform.localPosition = GameManager.loadPosition;
            player.gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            GameManager.loadLevel = false;

        }
    }

    public void LoadGame()
    {
        jsonString = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");

        loadStructure = JsonUtility.FromJson<SaveStructure>(jsonString);
        GameManager.Instance.GetComponent<ScoreManager>().PlayerScore = loadStructure.score;

        GameManager.currentScene = loadStructure.level;
        GameManager.playerHealth = loadStructure.health;
        GameManager.loadPosition = new Vector3(loadStructure.x, loadStructure.y, loadStructure.z);
        //Player variables
        SceneManager.LoadScene(loadStructure.level);
       
        GameManager.loadLevel = true;
    }
    

}
