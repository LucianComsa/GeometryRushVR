using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTracker : MonoBehaviour
{
    public GameObject holdAnchor;
    private List<string> tagsToHoldTo;
    private GameObject currentlyTracked;
    void Start()
    {
        tagsToHoldTo = ShapeInfo.getShapeTags();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Raycast();
        }
        if(currentlyTracked != null)
        {
            if(Input.GetMouseButtonUp(0))
            {
                currentlyTracked.GetComponent<shapeHoldScript>().stopHold();
            }
        }
    }
    private void Raycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(tagsToHoldTo.Contains(hit.collider.gameObject.tag))
            {
                hit.collider.gameObject.GetComponent<shapeHoldScript>().startHold(holdAnchor.transform);
                currentlyTracked = hit.collider.gameObject;
            }
        }
    }
}
