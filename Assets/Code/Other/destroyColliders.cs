using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyColliders : MonoBehaviour {

    // Use this for initialization
    public Transform myObject;
    Collider[] childColliders;
    BoxCollider[] childColliders2;
    SphereCollider[] childColliders3;

    void Start()
    {
        if (myObject == null)
            myObject = GetComponent<Transform>();
        childColliders = myObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in childColliders)
        {
            DestroyImmediate(collider);
        }
        childColliders2 = myObject.GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider collider in childColliders2)
        {
            DestroyImmediate(collider);
        }
        childColliders3 = myObject.GetComponentsInChildren<SphereCollider>();
        foreach (SphereCollider collider in childColliders3)
        {
            DestroyImmediate(collider);
        }
        Destroy(this);
    }

}
