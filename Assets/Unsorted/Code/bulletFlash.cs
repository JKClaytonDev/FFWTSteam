using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bulletFlash : MonoBehaviour
{
    GameObject player;
    public bool retro;
    public LayerMask layers;
    public Vector3 bulletTarget;
    public float speed;
    public Vector3 vel;
    public bool activated;
    public LayerMask bulletLayers;
    Quaternion startRot;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<breakableglass>())
        {
            if (!(collision.gameObject.GetComponent<breakableglass>().time > Time.realtimeSinceStartup))
            {
                collision.gameObject.GetComponent<breakableglass>().time = Time.realtimeSinceStartup + 1;
                collision.gameObject.GetComponent<breakableglass>().health--;
                if (collision.gameObject.GetComponent<breakableglass>().health <= 0)
                    Destroy(collision.gameObject);
            }
        }
            
        bulletCheck();
        if (collision.gameObject.GetComponent<Collider>().isTrigger || collision.gameObject.GetComponent<BoxCollider>().isTrigger || collision.gameObject.GetComponent<SphereCollider>().isTrigger)
            return;
        if (collision.gameObject.GetComponent<bulletFlash>())
            return;
        if (collision.gameObject == player || Vector3.Distance(transform.position, player.transform.position) < 10)
            return;
        if (retro)
            return;
        if (!collision.GetComponent<enemyHealth>())
        {

            Destroy(this.gameObject);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<breakableglass>())
        {
            if (!(collision.gameObject.GetComponent<breakableglass>().time > Time.realtimeSinceStartup))
            {
                collision.gameObject.GetComponent<breakableglass>().time = Time.realtimeSinceStartup + 0.3f;
                collision.gameObject.GetComponent<breakableglass>().health--;
                if (collision.gameObject.GetComponent<breakableglass>().health <= 0)
                    Destroy(collision.gameObject);
            }
        }
        bulletCheck();
        if (collision.gameObject.GetComponent<BoxCollider>())
        {
            if (collision.gameObject.GetComponent<BoxCollider>().isTrigger)
                return;
        }
        if (collision.gameObject.GetComponent<SphereCollider>())
        {
            if (collision.gameObject.GetComponent<SphereCollider>().isTrigger)
                return;
        }
        if (collision.gameObject.GetComponent<MeshCollider>())
        {
            if (collision.gameObject.GetComponent<MeshCollider>().isTrigger)
                return;
        }
        if (collision.gameObject.GetComponent<Collider>())
        {
            if (collision.gameObject.GetComponent<Collider>().isTrigger)
                return;
        }
        if (collision.gameObject.GetComponent<bulletFlash>())
            return;
        if (collision.gameObject == player || Vector3.Distance(transform.position, player.transform.position) < 10)
            return;
        if (retro)
            return;
        if (!collision.gameObject.GetComponent<enemyHealth>())
        {
           
            Destroy(this.gameObject);
        }
    }
    public void setPlayer(GameObject p)
    {
        player = p;
    }
    void Start()
    {
        GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);
        player = FindObjectOfType<Movement>().gameObject;
        if (GetComponent<SphereCollider>())
        GetComponent<SphereCollider>().enabled = true;
        this.gameObject.AddComponent<BoxCollider>();
        GetComponent<BoxCollider>().isTrigger = true;
        startRot = transform.rotation;
        
    }
    void bulletCheck()
    {
        bool found = false;
        RaycastHit hit;
        bool hitit = false ;
        Vector3 pt = new Vector3();
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit))
        {
            pt = hit.point;
            hitit = true;
                
        }
        foreach (enemyHealth e in FindObjectsOfType<enemyHealth>())
        {
            if (Vector3.Distance(transform.position, e.transform.position) < 5)
            {
                player.transform.LookAt(e.transform);
                transform.position = e.transform.position;
                player.GetComponent<Movement>().KillEnemy(e.gameObject, true);
                found = true;
            }
            if (hitit)
            {
                if (Vector3.Distance(pt, e.transform.position) < 5)
                {
                    player.transform.LookAt(e.transform);
                    transform.position = e.transform.position;
                    player.GetComponent<Movement>().KillEnemy(e.gameObject, true);
                    found = true;
                }
            }
        }
        if (found)
        {
            
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        transform.rotation = startRot;
        GetComponent<Rigidbody>().velocity = vel;
        foreach (Collider c in Physics.OverlapSphere(transform.position, 10))
        {
            if (c.GetComponent<enemyHealth>())
            {
                player.GetComponent<Movement>().KillEnemy(c.gameObject, true);
                Destroy(this.gameObject);
            }
        }
    }
    public void setVel()
    {
        GetComponent<Rigidbody>().velocity = 60 * (Vector3.MoveTowards(transform.position, bulletTarget, 5) - transform.position) * speed * Time.fixedDeltaTime * 60;
        player = Object.FindObjectOfType<Movement>().gameObject;
        var system = GetComponent<ParticleSystem>();
        var emission = system.emission;
        emission.rateOverDistance = 0.2f / speed;
        transform.localScale *= 5 / speed;
        vel = GetComponent<Rigidbody>().velocity;
    }

}
