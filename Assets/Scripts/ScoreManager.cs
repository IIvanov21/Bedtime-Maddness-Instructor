using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static int playerScore;
    public int PlayerScore
    {
        get { return playerScore; }
        private set { playerScore = value; }
    }


    public void SetScore(int incomingScore)
    {
        playerScore += incomingScore;
    }

    public void ResetScore()
    {
        playerScore = 0;
    }
}
