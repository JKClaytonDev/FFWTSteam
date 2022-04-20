using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandIntro : MonoBehaviour
{
    Vector3 start;
    float distance;
    float scale;
    GameObject player;
Collider[] hitColliders;
/*
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
        scale = 1   ;
        start = transform.position;
        player = GameObject.Find("PlayerSpawn");
        Vector3 playerpos = player.transform.position;
        playerpos.y = transform.position.y;
        //if (Vector3.Distance(transform.position, playerpos) > 30){
        {Vector3 pos = transform.position;
        
        distance = Vector3.Distance(transform.position, playerpos);
        //distance *= distance * distance;
        pos.y-=distance;
        hitColliders = (Physics.OverlapSphere(transform.position, 155));
        foreach (Collider col in hitColliders)
        {
            //Vector3 offset = col.gameObject.transform.position - transform.position;
            //col.gameObject.transform.position = pos+offset;
            if (!col.gameObject.GetComponent<IslandIntro>() && !col.gameObject.transform.parent.GetComponent<IslandIntro>() && (col.gameObject.GetComponent<MeshFilter>() || col.gameObject.GetComponent<MeshRenderer>() || col.gameObject.GetComponent<SkinnedMeshRenderer>()))
            col.gameObject.AddComponent<IslandIntro>();
        }
        transform.position = pos;
        }
    }
        
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos += ((start-pos)/(3+(scale*(150/distance))))*Time.fixedDeltaTime;
        transform.position = pos;
        transform.position = pos;
        if (pos == start)
        this.enabled = false;
    }
    */
}
