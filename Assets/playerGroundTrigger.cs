using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGroundTrigger : MonoBehaviour
{
    public Movement m;
    public boxColliders b;
    public float triggered;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (m.GetComponent<Rigidbody>().velocity.y < 2)
        {
            triggered = Time.realtimeSinceStartup;
            m.jumps = 0;
        }
    }
}
