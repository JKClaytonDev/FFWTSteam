using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour {
    public GameObject lookObject;
	public bool restrictX;
	public bool restrictY;
	public bool restrictZ;
	public bool restrictW;
    public bool findPlayer;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (findPlayer)
        {
            if (!lookObject)
            {
                if (FindObjectOfType<Movement>())
                    lookObject = FindObjectOfType<Movement>().gameObject;
            }
            if (!lookObject)
                return;

            transform.parent = null;
            transform.position += Time.deltaTime * 30 * (Mathf.Sin(Time.realtimeSinceStartup) * Vector3.right + Mathf.Cos(Time.realtimeSinceStartup) * Vector3.forward);
            if (Vector3.Distance(transform.position, lookObject.transform.position) < 200 || Time.realtimeSinceStartup % 2 == 0)
            {
                Vector3 lastEulerAngles = transform.localEulerAngles;
                Vector3 lookAtPos = lookObject.transform.position;
                lookAtPos += 1 * (Vector3.forward * Mathf.Sin(Time.realtimeSinceStartup / 3) + Vector3.right * Mathf.Cos(Time.realtimeSinceStartup / 3));
                transform.LookAt(lookAtPos);
                transform.Rotate(0, 90, 0);
                
                if (Vector3.Distance(transform.position, lookObject.transform.position) < 100)
                {
                    transform.position = Vector3.MoveTowards(transform.position, lookObject.transform.position, Time.deltaTime * Vector3.Distance(transform.position, lookObject.transform.position) / 3);
                    
                }
                
            }
                return;
        }
        transform.position = transform.parent.transform.position;
		Quaternion rot = transform.rotation;
        if (lookObject != null)
        {
            rot = lookObject.transform.rotation;
            Quaternion rotInput = rot;
            if (!restrictX)
                rotInput.x = lookObject.transform.rotation.x;
            if (!restrictY)
                rotInput.y = lookObject.transform.rotation.y;
            if (!restrictZ)
                rotInput.z = lookObject.transform.rotation.z;
            if (!restrictW)
                rotInput.w = lookObject.transform.rotation.w;

            transform.localRotation = rotInput;
        }
	}
}
