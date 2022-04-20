using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textLookat : MonoBehaviour {
    private bool isParent;
    public bool stayStill;
    public bool onlyForBeginning;
	// Use this for initialization
	void Start () {
        transform.LookAt(GameObject.Find("Player").transform);
        transform.localScale = new Vector3(1, 1, 1);
        isParent = (!gameObject.name.Contains("(Clone)"));
        if (!isParent)
            Destroy(gameObject, 3);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        if (!stayStill)
        pos.y+=0.1f;
        transform.position = pos;
        if (!onlyForBeginning)
        {
            transform.LookAt(GameObject.Find("Player").transform);

        }
	}
}
