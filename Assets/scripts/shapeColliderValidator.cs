using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeColliderValidator : MonoBehaviour
{
    public string tagToCheckFor;
    public static event Action<bool> OnShapeCollidedIsCorrectHit = delegate {};
    void OnDestroy()
    {
        OnShapeCollidedIsCorrectHit = delegate {};
    }
    void OnTriggerEnter (Collider col)
    {
        if(ShapeInfo.getShapeTags().Contains(col.gameObject.tag))
        {
            string tag = col.gameObject.tag;
            shapeSpawner.DestroyShape();
            Debug.Log("destroyed shape, now calling event");
            OnShapeCollidedIsCorrectHit(tag.Equals(tagToCheckFor));
        }
    }
}
