using UnityEngine;
using VRTK;
using System;

public class CylinderEventThrower : MonoBehaviour
{
    private GameObject UsedObject;
    LineRenderer lineRenderer;
    private void FixedUpdate()
    {
        if (UsedObject != null)
        {
            Vector3 CurrentPosition = UsedObject.transform.position;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount -1 , CurrentPosition);
        }
    }

    private void Start()
    {
        
    }


    void OnEnable()
    {
        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += ObjectUsed;
        GetComponent<VRTK_InteractableObject>().InteractableObjectUnused += ObjectUnUsed;
    }


    private void ObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        
        GameObject gameObj = new GameObject();
        lineRenderer = gameObj.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.color = Color.white;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.positionCount = 0;

        UsedObject = e.interactingObject;
        
    }

    private void ObjectUnUsed(object sender, InteractableObjectEventArgs e)
    {
        
        UsedObject = null;
    }



}
