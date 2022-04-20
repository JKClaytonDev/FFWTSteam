using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingRobot : MonoBehaviour
{
    public GameObject enemy; float time;   public LayerMask layers;
    public ParticleSystem ZparticleSystem;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void FixedUpdate()
    {

        if (enemy.GetComponent<enemyHealth>() != null)
        {
            ZparticleSystem.transform.position = enemy.transform.position + new Vector3(0, 3.8f, 0);
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, enemy.transform.position);
        }
        else
        {
                float distance = 1000;
                enemyHealth[] enemies = FindObjectsOfType<enemyHealth>();
                foreach (enemyHealth e in enemies)
                    {
                        if (Vector3.Distance(e.transform.position, transform.position) < distance)
                        {
                        enemy = e.gameObject;
                        distance = Vector3.Distance(e.transform.position, transform.position);
                        
                        }
                    }
        }
    }
}
