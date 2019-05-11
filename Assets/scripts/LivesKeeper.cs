using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesKeeper : MonoBehaviour
{
    public List<GameObject> hearts;
    public static event Action OnLose = delegate {};
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.OnLoseLife += LoseLife;
    }
    void OnDestroy()
    {
        OnLose = delegate {};
    }
    private void LoseLife()
    {
        int index = hearts.Count-1;
        Destroy(hearts[index]);
        hearts.RemoveAt(index);
        if(hearts.Count == 0)
        {
            OnLose();
        }
    }
}
