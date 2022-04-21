using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class automoveandrotate : MonoBehaviour
{
    public Vector3 rotateDegreesPerSecond;
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(rotateDegreesPerSecond * Time.deltaTime);
    }
}
