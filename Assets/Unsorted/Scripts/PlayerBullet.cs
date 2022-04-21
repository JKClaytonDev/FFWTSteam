using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Vector3 target;
    public LayerMask layers;
    float extraspeed;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        extraspeed = 0;
        Transform cam = FindObjectOfType<Camera>().transform;
        Ray r = new Ray(cam.position, cam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.transform.forward, out hit, Mathf.Infinity, layers))
        {
            target = hit.point;
        }
        GetComponent<Rigidbody>().velocity = (Vector3.MoveTowards(transform.position, target, 80) - transform.position) * (5 + extraspeed);
    }
    
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Cancelled after hit " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<EnemyAnimator>())
        {
            collision.collider.enabled = false;
            Destroy(collision.gameObject.GetComponent<Rigidbody>());
            Destroy(collision.gameObject.GetComponent<EnemyAnimator>());
            Debug.Log((Mathf.Round(transform.position.x) + ""));
            if (Mathf.Round(transform.position.x) % 2 == 0)
            {
                collision.gameObject.GetComponent<Animator>().Play("Die2");
                
            }
            else
                collision.gameObject.GetComponent<Animator>().Play("Die");
            collision.gameObject.GetComponent<Animator>().SetLayerWeight(2, 0);
            foreach (Object g in collision.gameObject.GetComponent<EnemyAnimator>().destroyOnDeath)
            {
                if (g)
                    Destroy(g);
            }
        }
        else if (collision.gameObject.GetComponent<runatplayer>())
        {
            collision.collider.enabled = false;

            Destroy(collision.gameObject.GetComponent<runatplayer>().parent.GetComponent<Rigidbody>());
            Destroy(collision.gameObject.GetComponent<runatplayer>().parent.GetComponent<EnemyAnimator>());
            Debug.Log((Mathf.Round(transform.position.x) + ""));
            if (Mathf.Round(transform.position.x) % 2 == 0)
            {
                collision.gameObject.GetComponent<runatplayer>().parent.GetComponent<Animator>().Play("Die2");

            }
            else
                collision.gameObject.GetComponent<runatplayer>().parent.GetComponent<Animator>().Play("Die");
            collision.gameObject.GetComponent<runatplayer>().parent.GetComponent<Animator>().SetLayerWeight(2, 0);
            foreach (Object g in collision.gameObject.GetComponent<runatplayer>().parent.GetComponent<EnemyAnimator>().destroyOnDeath)
            {
                if (g)
                    Destroy(g);
            }
        }
        
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position == lastPos)
            Destroy(gameObject);
        lastPos = transform.position;
        extraspeed += Time.deltaTime * 27;
        transform.position = Vector3.MoveTowards(transform.position, target, 30*Time.deltaTime* (5 + extraspeed));
    }
}
