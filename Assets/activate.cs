using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    private void OnEnable()
    {
        g.SetActive(true);
    }
}
