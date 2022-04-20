using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFirePoint : MonoBehaviour {
    public Vector3 hitPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameObject.Find("Player").GetComponent<Movement>().oldMovement)
        {
            if (GameObject.Find("Player").GetComponent<Movement>().SuperBoots)
                GetComponent<Camera>().fieldOfView += (122 - GetComponent<Camera>().fieldOfView) / 5;
            else if (Input.GetMouseButton(1))
                GetComponent<Camera>().fieldOfView += (90 - GetComponent<Camera>().fieldOfView) / 5;
            else
                GetComponent<Camera>().fieldOfView += (120 - GetComponent<Camera>().fieldOfView) / 5;
        }
        else
        {
            GetComponent<Camera>().fieldOfView = 122;
        }
        Ray ray = new Ray();
        RaycastHit hit;
        ray.origin = transform.position;
        ray.direction = transform.forward;
        if (Physics.Raycast(ray, out hit))
            if (hit.distance > 2)
        {
                hitPoint = hit.point;
        }

    }
}
