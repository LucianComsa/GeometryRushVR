using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePositionResetter : MonoBehaviour
{
    public Transform resetTo;
    
    void OnTriggerEnter (Collider col) {
        if(ShapeInfo.getShapeTags().Contains(col.gameObject.tag))
        {
            col.gameObject.transform.position = resetTo.position;
        }
    }
}
