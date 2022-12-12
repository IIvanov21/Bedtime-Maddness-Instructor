using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save : MonoBehaviour
{
    private string jSonString;
    private SaveStructure saveStructure;

   

    public void SaveGame()
    {
        //Populate save sturcture
        saveStructure = new SaveStructure();
        Player player = GameObject.FindObjectOfType<Player>();
        saveStructure.health = player.Health;
        saveStructure.score = GameManager.Instance.GetComponent<ScoreManager>().PlayerScore;
        saveStructure.level = GameManager.currentScene;

        saveStructure.x = player.gameObject.transform.localPosition.x;
        saveStructure.y = player.gameObject.transform.localPosition.y;
        saveStructure.z = player.gameObject.transform.localPosition.z;

      

        //Create the save file
        jSonString=JsonUtility.ToJson(saveStructure);


        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", jSonString);
    }
}
