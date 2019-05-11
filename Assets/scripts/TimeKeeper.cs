using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    private float startingTime = 20F;
    private float currentTime = 0F;
    private readonly float timeAdder = 5F;
    private readonly float timeSubtracter = 5F;
    public TMPro.TMP_Text uiTime;

    public static event Action OnLose = delegate {};
    void Awake()
    {
        //setup events with lambda methods
        GameManager.OnAddBonusTime += () => {
            currentTime += timeAdder;
        };
        GameManager.OnDecreaseTime += () => {
            currentTime -= timeSubtracter;
            if(currentTime <= 0) OnLose();
        };
    }
    void OnDestroy()
    {
        OnLose = delegate {};
    }
    void Start()
    {
        currentTime = startingTime;
    }
    private void UpdateTimer ()
    {
        currentTime -= 1 * Time.deltaTime;
        DisplayTimer();
    }
    private void DisplayTimer()
    {
        uiTime.text = currentTime.ToString("0");
    }
    void Update()
    {
        UpdateTimer();
        if(currentTime <= 0) OnLose();
    }
}
