using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMech : MonoBehaviour {
    private float OGCount;
    // Use this for initialization
    void Start() {
        OGCount = 0;
        foreach (Transform t in transform)
        {
            OGCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float count = 0;
        foreach (Transform t in transform)
        {
            count++;
        }
        if (count < OGCount)
        {
            for (int i = 1; i < 5; i++)
            {
                GameObject fraggedStuff = Instantiate(GameObject.Find("EnemyFraggedText"));
                fraggedStuff.transform.position = new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y, transform.position.z + Random.Range(-3, 3));
                fraggedStuff.transform.localScale *= 3;
                fraggedStuff.SetActive(false);
                fraggedStuff.SetActive(true);
                Destroy(fraggedStuff, 0.5f);
            }
            Destroy(gameObject);
        }
    }
}
