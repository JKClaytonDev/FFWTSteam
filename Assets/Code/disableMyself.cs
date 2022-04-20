using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableMyself : MonoBehaviour
{
    float disableTime;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (disableTime < Time.realtimeSinceStartup-0.5f)
        {
            disableTime = Time.realtimeSinceStartup + 0.3f;
        }
        if (Time.realtimeSinceStartup > disableTime)
        {
            gameObject.SetActive(false);
        }
    }
}
