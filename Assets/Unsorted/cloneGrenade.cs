using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneGrenade : MonoBehaviour
{
    public GameObject nade;
    public AnimationEvent evt;
    public GameObject OGnade;
    // Start is called before the first frame update
    void Start()
    {
        evt.functionName = "ThrowGrenade";
    }

    public void ThrowGrenade()
    {
        GameObject nadee = Instantiate(nade);
        nadee.transform.parent = transform.parent;
        nadee.transform.position = transform.position+(transform.forward-transform.right)*5;//OGnade.transform.position+transform.forward*23;
        nadee.GetComponent<Rigidbody>().velocity = transform.forward * 335 + Vector3.down*100;
    }
}
