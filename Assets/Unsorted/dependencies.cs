using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dependencies : MonoBehaviour
{
    public GameObject grunt;
    public GameObject balloon;
    public GameObject attach;
    Vector3 localPos;
    // Start is called before the first frame update
    void Start()
    {
        
        grunt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        localPos = grunt.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().speed = Random.Range(0.8f, 1.2f);
        balloon.transform.position = attach.transform.position + Vector3.up * 20;
        grunt.transform.localPosition = localPos;
        if (!grunt)
            Destroy(balloon);
        else if (!grunt.GetComponent<enemyHealth>())
            Destroy(balloon);
        else if (grunt.GetComponent<enemyHealth>().Currenthealth < 1)
            Destroy(balloon);
        if (!balloon || balloon.GetComponent<enemyHealth>().Currenthealth < 1)
        {
            grunt.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            grunt.transform.parent = null;
            Destroy(gameObject);
        }
    }
}
