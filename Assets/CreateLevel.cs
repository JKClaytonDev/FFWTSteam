using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    GameObject player;
    GameObject realPlayer;
    float distance;
    Vector3 startPos;
    float posTime = 0;
    Vector3 defaultScale;
    float speed = 255;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        startPos = transform.position;
        player = GameObject.Find("PlayerSpawn");
        
        if (!player)
            return;
        if (GetComponent<enemyHealth>())
        {
            Vector3 newPos = transform.position + Vector3.down * Mathf.Sqrt(Vector3.Distance(transform.position, player.transform.position)) * 15;
            posTime = Time.realtimeSinceStartup +  Vector3.Distance(transform.position, newPos) / speed;

            
        }
        else if (Vector3.Distance(transform.position, player.transform.position) < 150)
            return;
        else
            transform.position += Vector3.down * Mathf.Sqrt(Vector3.Distance(transform.position, player.transform.position)) * 15;

    }

    // Update is called once per frame
    void Update()
    {
        if (!realPlayer)
        {
            if (!FindObjectOfType<Movement>())
                return;
            realPlayer = FindObjectOfType<Movement>().gameObject;
        }
        if (!realPlayer)
            return;
        if (GetComponent<enemyHealth>() && Time.realtimeSinceStartup < posTime)
        {
            transform.position = startPos;
            transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, defaultScale, Time.deltaTime*10);
        }
        if (Vector3.Distance(startPos, realPlayer.transform.position) < 250)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * speed);
        }
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(1);

        gameObject.SetActive(true);
        //Do Function here...
    }

}
