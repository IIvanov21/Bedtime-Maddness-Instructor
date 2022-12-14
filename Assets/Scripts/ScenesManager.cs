using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    //Create a custom enumrator for each of our scene
    public enum Scenes
    {
        bootUp, //Loading up the scene
        title, //This is where we are going to have our title and start menu
        waveOne,//General level reference
        waveTwo,
        waveThree,
        waveBoss,
        gameOver// If we die go to game over scene
    }

    //Reset method when we die and respawn
    //As part of Bedtime Maddness we won't have a need for reset method but
    //its one of those good to know methods.
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //When we die we want to have a custom scene to manage GameOver beahavior
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    //As we develop we will have a test level therefore for now by default
    //lets load our test level
    public void BeginGame()
    {
        SceneManager.LoadScene((int)Scenes.waveOne);
        GameManager.State = GameState.Play;
    }

    public void MainScene()
    {
        SceneManager.LoadScene((int)Scenes.title);
    }

    //Quit Game Method
    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        switch (GameManager.currentScene)
        {
            case 2: case 3: case 4:
            case 5:
                {
                    SceneManager.LoadScene(GameManager.currentScene + 1);
                    break;
                }
        }
    }
}
