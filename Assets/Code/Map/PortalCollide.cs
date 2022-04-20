using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollide : MonoBehaviour {
    public GameObject exit;
    public GameObject portal;

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollsionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "playerCollider")
        {
            collision.gameObject.transform.position = portal.GetComponent<PortalCollide>().exit.transform.position;
        }
    }
    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < Vector3.Distance(transform.position, exit.transform.position))
        {
            GameObject.Find("Player").transform.position = portal.GetComponent<PortalCollide>().exit.transform.position + portal.GetComponent<PortalCollide>().exit.transform.forward;
            GameObject.Find("Player").transform.rotation= portal.GetComponent<PortalCollide>().exit.transform.rotation;
        }
	}
}
