using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPos : MonoBehaviour {
    public GameObject standing;
    private GameObject walking;
    public GameObject jumping;
    public GameObject defaultLeg;
	// Use this for initialization
	void Start () {
        walking = GameObject.Find("Walking");
	}

    // Update is called once per frame
    void Update()
    {

        transform.position = GameObject.Find("Player").transform.position;
        Quaternion rotation;
        rotation = GameObject.Find("Player").transform.rotation;
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = rotation;
        /*
        walking = GameObject.Find("Walking");
        if (walking)
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
            {
                if (Mathf.Abs(GameObject.Find("Player").GetComponent<Rigidbody>().velocity.y) > 1)
                {
                    jumping.transform.position = defaultLeg.transform.position;
                    jumping.transform.rotation = defaultLeg.transform.rotation;
                    standing.transform.position = new Vector3(10000, 1000, 1000);
                    walking.transform.position = new Vector3(10000, 1000, 1000);
                }
                else if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
                {
                    walking.transform.position = defaultLeg.transform.position;
                    walking.transform.rotation = defaultLeg.transform.rotation;
                    standing.transform.position = new Vector3(10000, 1000, 1000);
                    jumping.transform.position = new Vector3(10000, 1000, 1000);
                }
                else
                {
                    standing.transform.position = defaultLeg.transform.position;
                    standing.transform.rotation = defaultLeg.transform.rotation;
                    walking.transform.position = new Vector3(10000, 1000, 1000);
                    jumping.transform.position = new Vector3(10000, 1000, 1000);
                }

                transform.position = GameObject.Find("Player").transform.position;
                transform.rotation = GameObject.Find("Player").transform.rotation;
                Quaternion rot = transform.rotation;
                rot.x = 0;
                rot.z = 0;
                transform.rotation = rot;
            }
            
        }
        else
        {
            transform.position = GameObject.Find("Player").transform.position;
            transform.rotation = GameObject.Find("Player").transform.rotation;
            Quaternion rot = transform.rotation;
            rot.x = 0;
            rot.z = 0;
            transform.rotation = rot;
        }
        gameObject.layer = 2;
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.layer = LayerMask.NameToLayer("TransparentFX");  // add any layer you want. 
        }
        */
    }
}
