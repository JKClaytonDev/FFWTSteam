using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMovement : MonoBehaviour
{
    //Variable Declarations:
    //local
    private float rotationX; private float rotationY;
    private float speed; private Vector3 vel;
    private float jumps; private float jumpTime;

    //public
    float stopspeed = 100;
    float maxspeed = 320;
    float accelerate = 10;
    float airAccelerate = 0.7f;
    float friction = 6;
    float moveSpeed = 7;
    float runAcceleration = 14;
    float runDeacceleration = 10;
    float airDeacceleration = 2;
    float airControl = 0.3f;
    float sideStrafeAcceleration = 50;
    float sideStrafeSpeed = 1;
    float jumpSpeed = 8;
    Vector3 moveDirectionNorm;
    bool wishJump;

    public Camera Cam; private Rigidbody pmove;
    //Public Stats
    public float RunSpeed = 20; public float MaxAcceleration = 20; public float jumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        moveDirectionNorm = new Vector3();
        pmove = GetComponent<Rigidbody>();
        vel = new Vector3();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX += Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * 35;
        rotationY += Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * 35;
        transform.eulerAngles = new Vector3(0, rotationX, 0);
        Cam.gameObject.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);

        if (jumps != 0)
        {
            if (Physics.Raycast(transform.position, Vector3.down, 4.1f))
                jumps = 0;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().velocity = transform.up * jumpHeight;
                jumps++;
            }
        }
        Debug.Log(jumps);
    }

    void GroundMove()
    {
        Vector3 wishdir = new Vector3();
        Vector3 wishvel = new Vector3();

        if (!wishJump)
            ApplyFriction(1);
        else
            ApplyFriction(0);

        SetMovementDir();

        wishdir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        wishdir = transform.TransformDirection(wishdir);

        Vector3 start = new Vector3(), dest = new Vector3(), original = new Vector3(), originalvel = new Vector3(), down = new Vector3(), up = new Vector3(), downvel = new Vector3();
        Vector3 vel = pmove.velocity;
        vel[1] = 0;
        pmove.velocity = vel;

        dest[0] = pmove.position[0] + pmove.velocity[0] * Time.fixedDeltaTime;
        dest[2] = pmove.position[2] + pmove.velocity[2] * Time.fixedDeltaTime;
        dest[1] = pmove.position[1];
    }

    void SetMovementDir()
    {

    }

    void ApplyFriction(float num)
    {

    }
    void airMove()
    {
        Vector3 wishvel = new Vector3();
        Vector3 wishdir = new Vector3();
        float wishspeed = 0;

        Vector3 fmove = Input.GetAxis("Vertical") * transform.forward;
        Vector3 smove = Input.GetAxis("Horizontal") * transform.right;
        wishvel.x = fmove.x + smove.x;
        wishvel.z = fmove.z + smove.z;
        Vector3 ws = Vector3.Normalize(wishdir);
        wishspeed = Max(Vector3.Normalize(wishdir));
        if (wishspeed > maxspeed)
            wishspeed = maxspeed;
        if (jumps == 0)
        {
            Vector3 vel = pmove.velocity;
            vel[1] = 0;
            player_accelerate(wishdir, wishspeed, accelerate);
            vel -= Physics.gravity * Time.fixedDeltaTime;
        }
        else
        {

        }

    }
    public void player_accelerate(Vector3 wishdir, float wishspeed, float accel)
    {
        int i;
        float addspeed, accelspeed, currentspeed;

        currentspeed = Vector3.Dot(pmove.velocity, wishdir);
        addspeed = wishspeed - currentspeed;
        if (addspeed <= 0)
            return;
        accelspeed = min(accel * Time.deltaTime * wishspeed, addspeed);
        Vector3 vel = pmove.velocity;
        for (i = 0; i < 3; i++)
            vel[i] = accelspeed * wishdir[i];

    }
    public void player_airaccelerate(Vector3 wishdir, float wishspeed)
    {
        float zspeed;
        float speed;
        float dot;
        float k;
        float i;

        if (Input.GetAxis("Vertical") > 0)
            return;

        zspeed = pmove.velocity.y;
        pmove.velocity.Set(pmove.velocity.x, 0, pmove.velocity.z);
        speed = pmove.velocity.magnitude;
        pmove.velocity.Normalize();

        dot = Vector3.Dot(pmove.velocity, wishdir);
        k = 32;
        k *= airControl * dot * dot;
        Vector3 vel = pmove.velocity;
        if (dot > 0)
        {
            for (int x = 0; x < 3; x++)
                vel[x] = vel[x] * speed + wishdir[x] * k;
            pmove.velocity.Normalize();
            moveDirectionNorm = pmove.velocity;
        }
        vel *= speed;
        vel.y = zspeed;
        pmove.velocity = vel;

    }

    public float Max(float a, float b)
    {
        if (a < b)
            return b;
        return a;
    }

    public float min(float a, float b)
    {
        if (a > b)
            return b;
        return a;
    }

    public float Max(Vector3 v)
    {
        float max = v[0];
        for (int i = 0; i <= 3; i++)
        {
            if (max < v[i])
                max = v[i];
        }
        return max;
    }
}
