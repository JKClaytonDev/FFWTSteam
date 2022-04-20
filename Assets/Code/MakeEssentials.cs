using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeEssentials : MonoBehaviour
{
    public GameObject essentials;
    public GameObject creator;
    // Start is called before the first frame update
    void Start()
    {
     //   Destroy(creator);
        Instantiate(essentials);
        essentials.SetActive(true);
        Destroy(gameObject);
    }

}
