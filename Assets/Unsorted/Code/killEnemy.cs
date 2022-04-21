using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killEnemy : MonoBehaviour {
    private bool justDied;
    private bool canFade;
         private Color alphaColor;
         private float timeToFade = 1.0f;
    private float originalChildren;
    string originalTag;
    Vector3 oldTransPos;

    // Use this for initialization
    void Start() {
        if (GetComponent<BulletExplodeBarrelCar>())
        {
            this.gameObject.layer = 1;
            this.gameObject.tag = "Untagged";
            GetComponent<killEnemy>().enabled = false;
            this.enabled = false;
        }
    }
    /*
        gameObject.tag = "";
        originalTag = gameObject.tag;
        originalChildren = 0;
        oldTransPos = transform.position;
        originalChildren = transform.childCount;
        justDied = (gameObject.tag == "dead");
        if (!justDied)
        {

            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour c in comps)
            {
                if (c != GetComponent<killEnemy>() && c != GetComponent<Renderer>() && c != GetComponent<Material>())
                    c.enabled = false;
            }
            foreach (Transform t in transform)
            {
                t.gameObject.tag = "dead";
                if (t.GetComponent<Animator>() != null)
                    t.GetComponent<Animator>().enabled = false;
            }
            gameObject.name = "Dead";
            gameObject.layer = 13;
            if (GetComponent<BoxCollider>() == null)
            {
                gameObject.AddComponent<BoxCollider>();
            }
            if (GetComponent<Rigidbody>() == null)
            {
                gameObject.AddComponent<Rigidbody>();
            }
            GetComponent<Rigidbody>().velocity /= 3;
            if (originalTag == "Enemy")
                Destroy(gameObject, 1);
            else
                Destroy(gameObject, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "dead" && originalTag == "Explodabale")
        {
            Vector3 vel = GetComponent<Rigidbody>().velocity;
                vel.x /= 113;
                vel.z /= 113;
           GetComponent<Rigidbody>().velocity = vel;
            Vector3 pos = transform.position;
            pos.x = oldTransPos.x;
            pos.z = oldTransPos.z;
            transform.position = pos;
            if (GetComponent<Animator>() != null)
                GetComponent<Animator>().enabled = false;
        }
        if (gameObject.tag != "dead" && (gameObject.tag == "Enemy" || gameObject.tag == "Explodable"))
        {
            float currentChildren = 0;
            currentChildren = transform.childCount;
            if (currentChildren < originalChildren)
            {
                foreach (Transform t in transform)
                {
                    t.gameObject.tag = "dead";
                }
                gameObject.tag = "dead";
            }
        }
        if (gameObject.tag == "dead")
        {
            justDied = (gameObject.tag == "dead");
        }
        
    }
    */
}
