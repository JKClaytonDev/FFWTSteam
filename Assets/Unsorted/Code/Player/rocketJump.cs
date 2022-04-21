using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rocketJump : MonoBehaviour
{
    public float radius;
    public float power;
    private float moveTime;
    public bool mouse1;
    // Use this for initialization
    void Start()
    {
        mouse1 = false;
        moveTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
            mouse1 = true;
        Collider[] hitColliders = (Physics.OverlapSphere(transform.position, 15));
        {
            foreach (Collider col in hitColliders)
            {
                if (col.GetComponent<enemyHealth>())
                    GameObject.Find("Player").GetComponent<Movement>().gibEnemy(col.gameObject.transform);
                else if (col.GetComponent<Rigidbody>()){
                    Vector3 vel = transform.position - col.transform.position;
                    vel.x/=Mathf.Abs(vel.x);
                    vel.y=1;
                    vel.z/=Mathf.Abs(vel.z);
                    vel*=25;
                    vel/=Vector3.Distance(transform.position, col.transform.position);
                    vel = Vector3.Min(vel, new Vector3(15, 15, 15));
                    if (col.GetComponent<Movement>())
                    {
                        col.GetComponent<Movement>().PlayerHealth--;
                        col.GetComponent<Movement>().playerHealth--;
                    }
                    vel *= -1;
                    vel.y *= -1;
                        if (!(col.GetComponent<Movement>() && mouse1))
                    col.GetComponent<Rigidbody>().velocity += vel;
                }
            }

        }
    }
}