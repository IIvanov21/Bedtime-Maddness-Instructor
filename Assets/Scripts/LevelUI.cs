using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class LevelUI : MonoBehaviour
{
    //UI Elements
    [SerializeField]
    Slider playerHealthSlider;

    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    GameObject pauseMenu;
    
    bool isPaused = false;

    public  delegate void OnScoreUpdate();
    public static OnScoreUpdate onScoreUpdate;
    public delegate void OnLifeUpdate();
    public static OnLifeUpdate onLifeUpdate;

    private void Start()
    {
        onScoreUpdate = ScoreSystem;
        onLifeUpdate = LifeSystemTracker;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void LifeSystemTracker()
    {
        if (GameManager.playerHealth < 100)//Simulate we have been hit
        {
            Debug.Log("Player's current suffocation is:" + GameManager.playerHealth + "%!");
            playerHealthSlider.value = GameManager.playerHealth;
        }
        else//Simulate we die
        {
            Debug.Log("Player's current suffocation is:" + GameManager.playerHealth + "%! We are dead!");
            playerHealthSlider.value = GameManager.playerHealth;
            GetComponent<ScenesManager>().GameOver();

        }

    }

    public void ScoreSystem()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetComponent<ScoreManager>().PlayerScore;
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        Debug.Log("Game is paused: " + isPaused);

        pauseMenu.SetActive(isPaused);

        if (isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;

        CursorManager.cursorDelegate?.Invoke(isPaused);
    }
}
