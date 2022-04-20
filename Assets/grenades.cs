using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenades : MonoBehaviour
{
    public GameObject splosion;
    float startTime;
    Camera playerCam;
    // Start is called before the first frame update
    void Start()
    {
        playerCam = FindObjectOfType<CameraIntro>().GetComponent<Camera>();
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (Time.realtimeSinceStartup - 0.1f > startTime || Input.GetKey(KeyCode.F))
        {
            GameObject s = Instantiate(splosion);
            s.transform.position = transform.position;
            Destroy(gameObject);
            Destroy(s, 2);
        }
    }
    /*
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = playerCam.WorldToScreenPoint(transform.position);
            if (Mathf.Abs(pos.x) < 30 && Mathf.Abs(pos.y) < 30)
            {
                GameObject s = Instantiate(splosion);
                s.transform.position = transform.position;
                Destroy(gameObject);
            }
        }
        if (Time.realtimeSinceStartup - 5 > startTime || Input.GetKey(KeyCode.F))
        {
            GameObject s = Instantiate(splosion);
            s.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
    */
}
