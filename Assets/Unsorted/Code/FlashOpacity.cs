using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlashOpacity : MonoBehaviour
{
    void Start()
    {
        Color color = GetComponent<Image>().color;
        color.a = 0;
        GetComponent<Image>().color = color;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Color color = GetComponent<Image>().color;
        color.a /= 1.01f;
        GetComponent<Image>().color = color;
    }
}
