using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorPlayer : MonoBehaviour
{
    Movement player;
    Vector3 lastPlayerPos = new Vector3();
    Rigidbody rb;
    Animator anim;
    Vector3 start;
    public bool jumping;
    public BoxCollider col;
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = start;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
            GetComponent<BoxCollider>().size = col.size;
        }
        if (!player)
            player = FindObjectOfType<Movement>();
        if (!player)
            return;
        if (!rb)
            rb = GetComponent<Rigidbody>();
        if (!anim)
            anim = GetComponent<Animator>();
        jumping = transform.position.y > -24;
        anim.SetBool("jumping", jumping);
        if (lastPlayerPos != new Vector3())
        {
            transform.LookAt(player.transform);
            Vector3 reverseVel = (player.transform.position - lastPlayerPos);
            reverseVel.x *= -1;
            reverseVel.z *= -1;
            transform.position += reverseVel;

        }
        lastPlayerPos = player.transform.position;
        Vector3 pos = transform.position;
        pos.y = player.transform.position.y;
        if (pos.y < -33)
            pos.y = -33;
        transform.position = pos;
        transform.rotation = player.transform.rotation;
        transform.Rotate(0, 180, 0);
        

    }
}
