using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public Vector3 bulletdirection;
    public GameObject player;
	// Use this for initialization
	void Start () {
        SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        bulletdirection = transform.forward*35;

	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody>()!=null)
        GetComponent<Rigidbody>().velocity = bulletdirection/100;
        else
        transform.position += bulletdirection / 100; ;
    }
}
