using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableAnimator : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<Animator>().enabled = false;
    }
}
