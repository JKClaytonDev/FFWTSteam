using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRoomCamera : MonoBehaviour
{
    float rotationX;
    float rotationY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotationY += Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * 15 * PlayerPrefs.GetFloat("Mouse");
        rotationX += Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * 15 * PlayerPrefs.GetFloat("Mouse");
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

    }
}
