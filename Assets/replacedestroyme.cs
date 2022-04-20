using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replacedestroyme : MonoBehaviour
{
    public GameObject replace;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == replace.name)
            return;
        if (!replace)
            return;
        GameObject f = Instantiate(replace);
        f.transform.position = transform.position;
        f.transform.parent = transform.parent;
        f.transform.rotation = transform.rotation;
        Destroy(gameObject);
    }

}
