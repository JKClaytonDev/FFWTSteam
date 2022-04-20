using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class workshop : MonoBehaviour
{
    public GameObject loading;
    public GameObject inputField;
    public GameObject confirmButton;
    

    // Use this for initialization
    void Start()
    {
        inputField.SetActive(false);
        confirmButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<MouseButton>().MouseOver && (Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0) || confirmButton.GetComponent<MouseButton>().MouseOver)
        {
            inputField.SetActive(true);
            confirmButton.SetActive(true);
            
        }
        else if ((Input.GetMouseButton(0) || Input.GetAxis("Fire1") > 0))
        {
            inputField.SetActive(false);
            confirmButton.SetActive(false);
        }
    }
}
