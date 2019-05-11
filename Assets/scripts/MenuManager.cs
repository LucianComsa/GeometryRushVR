using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void playRush()
    {
        GameManager.Mode = GameMode.rush;
        startGameScene();
    }
    public void playArcade()
    {
        GameManager.Mode = GameMode.arcade;
        startGameScene();
    }
    private void startGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void quit()
    {
        Application.Quit();
    }
}
