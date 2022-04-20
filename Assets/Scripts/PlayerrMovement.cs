using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerrMovement : MonoBehaviour
{
    public bool move;
    Rigidbody rb;
    public GameObject camBob;
    public GameObject Vertical;
    float yrot;
    float speed;
    float fw;
    float right;
    bool moved;
    public bool onGround;
    public ArmsAnimation arms;
    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (move)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
            yrot -= Input.GetAxis("Mouse Y");
            
            speed = 15;
            if ((Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && onGround) || Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.S))
                speed *= 2;
            moved = false;
            fw = Input.GetAxis("Vertical");
            right = Input.GetAxis("Horizontal");

            onGround = Physics.Raycast(transform.position, Vector3.down, 7.8f);
            if (onGround)
            {
                if (Input.GetKey(KeyCode.Space) && arms.canJump)
                {
                    rb.velocity += Vector3.up * 10;
                    arms.anim.Play("StartJump", 3);
                }
            }
            if (Physics.Raycast(transform.position, Vector3.down, 12.6f))
            {
                rb.velocity = ((transform.right * right + transform.forward * fw) * speed) + Vector3.up * rb.velocity.y;
            }
        }
        
        Quaternion rot = new Quaternion();
       

        {
            Vertical.transform.localEulerAngles = new Vector3(yrot, 0, 0);
            camBob.transform.localRotation = rot;
            camBob.transform.Rotate(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0);
            GetComponent<CapsuleCollider>().center = Vector3.MoveTowards(GetComponent<CapsuleCollider>().center, new Vector3(0, -2.46f, 0), Time.deltaTime * 12);
            camBob.transform.localPosition = Vector3.MoveTowards(camBob.transform.localPosition, -rb.velocity / 75, Time.deltaTime * 5);
        }
        
    }
}
