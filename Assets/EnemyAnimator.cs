using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAnimator : MonoBehaviour
{
    public Animator anim;
    public Object[] destroyOnDeath;
    GameObject player;
    Vector3 pos;
    public GameObject cube;
    float startY;
    bool floating;
    AnimationEvent fire;
    public bool seePlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        GetComponent<Animator>().speed = Random.Range(0.75f, 1.25f);
        fire = new AnimationEvent();
        startY = transform.position.y;
        fire.functionName = "Fire";
        pos = player.transform.position;
        
    }
    public void Fire()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.MoveTowards(transform.position, player.transform.position, 1)-transform.position, out hit);
        if (hit.transform.gameObject == player)
            player.transform.position = pos;

    }
    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetKey(KeyCode.F))
        {
            
        }
        if (floating)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, startY, transform.position.z), 10 * Time.deltaTime);
        }
        //if (cube.activeInHierarchy)
        {
            anim.SetBool("SeePlayer", seePlayer);
        }
    }
}
