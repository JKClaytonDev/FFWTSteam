using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleSettings : MonoBehaviour
{
    public GameObject child;
    public GameObject Pan1;
    public GameObject Pan2;
    public GameObject Pan3;
    public GameObject Pan4;
    // Start is called before the first frame update
    void Start()
    {
        child.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pan1.SetActive(true);
            Pan2.SetActive(false);
            Pan3.SetActive(false);
            Pan4.SetActive(false);
        }
        if (Pan1.activeInHierarchy == false && Pan2.activeInHierarchy == false && Pan3.activeInHierarchy == false && (Pan4 == null || Pan4.activeInHierarchy == false))
            Pan1.SetActive(true);
        if (Pan1.activeInHierarchy && Pan2.activeInHierarchy)
            Pan1.SetActive(false);
        if (Pan1.activeInHierarchy && Pan3.activeInHierarchy)
            Pan1.SetActive(false);
        if (Pan1.activeInHierarchy && Pan4.activeInHierarchy)
            Pan1.SetActive(false);
        if (Time.realtimeSinceStartup < 3)
            child.SetActive(false);
        if (child.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            child.SetActive(!child.activeInHierarchy);
            if (!child.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
        }
    }
}
