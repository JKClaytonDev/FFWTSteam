using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killAfterGone : MonoBehaviour
{
    public GameObject[] objects;
    // Start is called before the first frame update
    public GameObject explosion;

    // Update is called once per frame
    void Update()
    {
        
        bool gone = false;
        
      foreach (GameObject o in objects)
        {
            if (o)
            {
                if (o.GetComponent<enemyHealth>())
                {
                    if (o.GetComponent<enemyHealth>().Currenthealth < 0.1f)
                        Destroy(o);
                    else
                        gone = true;
                }
            }
        }
        if (!gone)
        {
            Instantiate(explosion);
            Destroy(gameObject);
        }
    }
}
