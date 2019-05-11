using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject score, lives, time;
    public TMPro.TMP_Text mode;
    void Awake()
    {
        if(GameManager.Mode == GameMode.arcade) SetupStatsForArcade();
        else SetupStatsForRush();
    }
    private void SetupGeneral()
    {
        score.SetActive(true);
        mode.text = GameManager.Mode == GameMode.arcade ? "Arcade" : "Rush";
    }
    private void SetupStatsForRush()
    {
        SetupGeneral();
        lives.SetActive(false);
        time.SetActive(true);
    }
    private void SetupStatsForArcade()
    {
        SetupGeneral();
        lives.SetActive(true);
        time.SetActive(false);
    }
}
