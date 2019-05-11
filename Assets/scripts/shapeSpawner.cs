using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeSpawner : MonoBehaviour
{
    public static GameObject currentShape = null;
    public Transform spawnAnchor;
    public List<GameObject> shapes;
    // Start is called before the first frame update
    void Awake()
    {
        currentShape = null;
        GameManager.OnSpawnNextShape += spawnShape;
    }
    public void spawnShape()
    {
        if(currentShape == null)
        {
            currentShape = Instantiate(shapes[Random.Range(0, shapes.Count)],spawnAnchor.position,Quaternion.identity);
        }
    }

    public static void DestroyShape()
    {
        Destroy(currentShape);
        currentShape = null;
    }
}
