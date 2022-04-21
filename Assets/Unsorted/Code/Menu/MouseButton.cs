using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseButton : MonoBehaviour
{
    public bool MouseOver;
    private Vector3 LocalScale;
    public bool noSize;

    void OnMouseOver()
    {
        MouseOver = true;
    }
    void OnMouseExit()
    {
        MouseOver = false;
    }
    // Use this for initialization
    void Start()
    {
        MouseOver = false;
        LocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!noSize)
        {
            if (MouseOver)
                transform.localScale = LocalScale * 1.2f;
            else
                transform.localScale = LocalScale;
        }
    }
}
