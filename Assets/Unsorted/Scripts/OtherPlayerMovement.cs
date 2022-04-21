using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayerMovement : MonoBehaviour
{
    //Variable Declarations:
        //local
        private float rotationX; private float rotationY;
        private float speed;    private Vector3 vel;
        private float jumps; private float jumpTime;
    public bool onGround;
    //public
    public float Gravity = 1;
    public float maxLandSpeed = 320;
    public float maxAirSpeed = 320;
    public float stopSpeed = 100;
    public float groundAccelerate = 10;
    public float airAccelerate = 0.7f;
    public float friction = 6;
    public float airControl = 0.3f;
    public float jumpSpeed = 8;
    public bool jumpPressed;

    public GameObject groundPos;

    public Camera Cam; private Rigidbody pmove;
    //Public Stats
    public float RunSpeed = 20;    public float MaxAcceleration = 20; public float jumpHeight;
    //During Runtime
    Vector3 accelDir;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= Gravity;
        pmove = GetComponent<Rigidbody>();
        vel = new Vector3();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        jumpPressed = false;
        onGround = Physics.Raycast(transform.position, Vector3.down, 4.1f);
        transform.eulerAngles += new Vector3(0, Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * 55, 0);
        Cam.gameObject.transform.localEulerAngles -= new Vector3(Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * 55, 0, 0);
        accelDir = Vector3.Normalize(transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical"));
        if (onGround && Input.GetKey(KeyCode.Space))
            jumpPressed = true;
         pmove.velocity = new Vector3() + Physics.gravity * Time.deltaTime + OneifTrue(jumpPressed)*(transform.up * jumpHeight) + OneifTrue(onGround) *GroundMove() + OneifTrue(!onGround) * AirMove();
    }

    Vector3 GroundMove()
    {
        float speed = pmove.velocity.magnitude;
        float drop = 0;
        if (speed != 0 && onGround)
            drop = speed * friction * Time.deltaTime;
        pmove.velocity *= Mathf.Max(speed - drop, 0) / speed;
        return Accelerate(accelDir, maxLandSpeed, groundAccelerate);
    }

    Vector3 AirMove()
    {
        Vector3 v = Accelerate(accelDir, maxAirSpeed, airAccelerate);
        v.y = pmove.velocity.y;
        return v;
    }
    private Vector3 Accelerate(Vector3 dir, float maxVel, float accelerateIn)
    {
        float pV = Vector3.Dot(pmove.velocity, dir);
        float aV = accelerateIn;
        if (pV + aV > maxVel)
            aV = maxVel - pV;
        return pmove.velocity + (dir * aV);
    }
    public int OneifTrue (bool check)
    {
        if (check)
            return 1;
        return 0;
    }
    public float Max(Vector3 v)
    {
        float max = v[0];
        for (int i = 0; i<=3; i++)
        {
            if (max < v[i])
                max = v[i];
        }
        return max;
    }
}
