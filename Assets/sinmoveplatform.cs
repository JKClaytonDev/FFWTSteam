using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinmoveplatform : MonoBehaviour
{
    public float speed = 1;
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool fw;
    public bool bw;
    void Start()
    {
        if (!GetComponent<Rigidbody>())
        this.gameObject.AddComponent<Rigidbody>();
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        this.GetComponent<Rigidbody>().mass = 500000;
        if (GetComponent<BoxCollider>())
        {
            PhysicMaterial p = new PhysicMaterial();
            p.dynamicFriction = 1;
            p.staticFriction = 1;
            GetComponent<BoxCollider>().material = p;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 lastPos = transform.position;
        if (down)
            transform.position -= speed * transform.up * Mathf.Sin(Time.realtimeSinceStartup);
        if (up)
            transform.position += speed * transform.up * Mathf.Sin(Time.realtimeSinceStartup);
        if (left)
            transform.position -= speed * transform.right * Mathf.Sin(Time.realtimeSinceStartup);
        if (right)
        transform.position += speed * transform.right * Mathf.Sin(Time.realtimeSinceStartup);
        if (fw)
            transform.position += speed * transform.forward * Mathf.Sin(Time.realtimeSinceStartup);
        if (bw)
            transform.position -= speed * transform.forward * Mathf.Sin(Time.realtimeSinceStartup);
        Vector3 vel = ((transform.position - lastPos) / Time.deltaTime) ;
        if (float.IsNaN(vel.x))
            return;
        if (float.IsNaN(vel.y))
            return;
        if (float.IsNaN(vel.z))
            return;

            GetComponent<Rigidbody>().velocity = (transform.position - lastPos) / Time.deltaTime;
        transform.position = lastPos;
    }
}
