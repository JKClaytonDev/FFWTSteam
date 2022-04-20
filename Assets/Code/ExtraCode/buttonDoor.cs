using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonDoor : MonoBehaviour {
    public GameObject door;
    public Vector3 doorDir;
    public bool activated;
    private Vector3 startPos;
    public bool temporary;
    private void OnCollisionEnter(Collision collision)
    {
        if (temporary){
            
        }
        else{

        if (collision.gameObject.tag == "Player")
        {
            activated = true;
            Debug.Log("Opening Door...");
        }
        }
    }
    // Use this for initialization
    void Start () {
        startPos = door.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (temporary){
            activated = (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < 10);
            GetComponent<BoxCollider>().enabled = !activated;
        if (activated)
        {
            door.transform.position += ((startPos+doorDir)-transform.position)/10;
        }
        else
        {
            door.transform.position += (startPos-door.transform.position)/5;
        }
            
	}
    else if (activated)
    {
        transform.position+=doorDir/5;
        door.transform.position+=doorDir/5;
    }
    }

}
