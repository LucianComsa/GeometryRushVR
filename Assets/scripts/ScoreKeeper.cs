using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;
    public TMPro.TMP_Text uiScore;
    private readonly int scoreAdder = 5;
    void Awake()
    {
        GameManager.OnIncrementScore += addScore;
    }
    private void UpdateUIScore()
    {
        uiScore.text = score.ToString();
    }
    public void addScore()
    {
        score += scoreAdder;
        UpdateUIScore();
    }
}
