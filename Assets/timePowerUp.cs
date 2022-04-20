using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class timePowerUp : MonoBehaviour
{
    bool activated;
    float StartTime;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {
            GetComponent<Volume>().enabled = true;
            transform.position += transform.right * 900;
            Time.timeScale = 0.5f;
            StartTime = Time.realtimeSinceStartup;
            activated = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        GetComponent<Volume>().enabled = false;
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > StartTime + 10 && activated)
        {
            if (Time.timeScale == 1)
                Destroy(gameObject);
            else
            {
                Time.timeScale += Time.deltaTime;
                if (Time.timeScale > 1)
                    Time.timeScale = 1;
            }
        }
        else if (activated)
            Time.timeScale = 0.5f;
    }
}
