using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int rightScore;
    public int leftScore;
    public int maxScore;
    public Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddRightScore(int increment)
    {
        rightScore += increment;
        if (rightScore >= maxScore)
        {
            GameOver();
        }
        ball.ResetBall();
    }

    public void AddLeftScore(int increment)
    {
        leftScore += increment;
        if (leftScore >= maxScore)
        {
            GameOver();
        }
        ball.ResetBall();
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
