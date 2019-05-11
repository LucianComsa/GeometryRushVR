using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameMode Mode = GameMode.rush;
    public static event Action OnLoseLife = delegate {};
    public static event Action OnIncrementScore = delegate {};
    public static event Action OnAddBonusTime = delegate {};
    public static event Action OnDecreaseTime = delegate {};
    public static event Action OnSpawnNextShape = delegate {};
    public GameObject endGamePanel;
    public GameObject lineRenderer;
    void Awake()
    {
        SetupObjects();
    }
    void OnDestroy()
    {
        OnLoseLife = delegate {};
        OnIncrementScore = delegate {};
        OnAddBonusTime = delegate {};
        OnDecreaseTime = delegate {};
        OnSpawnNextShape = delegate {};
    }
    private void SetupObjects()
    {
        endGamePanel.SetActive(false);

        LivesKeeper.OnLose += Lose;
        TimeKeeper.OnLose += Lose;

        if(Mode == GameMode.arcade) {
            shapeColliderValidator.OnShapeCollidedIsCorrectHit += respondToShapeCollision;
        } else {
            shapeColliderValidator.OnShapeCollidedIsCorrectHit += respondToShapeCollisionRush;
        }
    }
    void Start()
    {
        OnSpawnNextShape();
    }
    private void respondToShapeCollision(bool isCorrectShapeHit)
    {
        if(isCorrectShapeHit)
        {
            OnIncrementScore();
            OnSpawnNextShape();
        } else
        {
            OnLoseLife();
            OnSpawnNextShape();
        }
    }
    private void respondToShapeCollisionRush(bool isCorrectShapeHit)
    {
        if(isCorrectShapeHit)
        {
            OnAddBonusTime();
            OnIncrementScore();
            OnSpawnNextShape();
        } else
        {
            OnDecreaseTime();
            OnSpawnNextShape();
        }
    }
    private void Lose()
    {
        shapeSpawner.DestroyShape();
        endGamePanel.SetActive(true);
        lineRenderer.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
