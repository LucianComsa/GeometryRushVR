using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeHoldScript : MonoBehaviour
{
    private Transform holdTo = null;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update() 
    {
        if(holdTo != null)
        {
            rb.MovePosition(holdTo.position);
        }
    }

    public void startHold(Transform transform)
    {
        holdTo = transform;
        rb.useGravity = false;
    }
    public void stopHold()
    {
        holdTo = null;
        rb.useGravity = true;
    }
}
