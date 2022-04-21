using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemyHealer : MonoBehaviour
{
    GameObject enemy;   float time;
    public float extraRadius;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        float time = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            if (FindObjectOfType<Movement>())
            player = FindObjectOfType<Movement>().gameObject;
        }
        if (player)
        {
            if (Mathf.Abs(transform.position.y - player.transform.position.y) < 600)
                Destroy(gameObject);
        }
        if (enemy != null || Time.realtimeSinceStartup - 3 < time) {
            Vector3 center = transform.position;
            float radius = 100 * (extraRadius+1);
            float distance = 1000;
            GameObject enemy = null;
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);
            {
                foreach (Collider col in hitColliders)
                {
                    if (col.gameObject.GetComponent<enemyHealth>() && Vector3.Distance(col.transform.position, transform.position) < distance)
                    {
                        enemy = col.gameObject;
                        distance = Vector3.Distance(col.transform.position, transform.position);
                    }
                }

            }
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, enemy.transform.position);
            float time = Time.realtimeSinceStartup;

        }
    }
}
