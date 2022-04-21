using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollerCoaster : MonoBehaviour
{
    GameObject player;
    public GameObject text;
    bool togglePlayer;
    Vector3 lastAngles;
    // Start is called before the first frame update
    void Start()
    {
        togglePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            if (!FindObjectOfType<Movement>())
                return;
            player = FindObjectOfType<Movement>().gameObject;
        }
            text.SetActive((Vector3.Distance(transform.position, player.transform.position) < 40));
            if (Vector3.Distance(transform.position, player.transform.position) < 40)
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("TOGGLED");
                    togglePlayer = !togglePlayer;
                    if (togglePlayer)
                    {
                        player.transform.position = transform.position;
                        player.transform.rotation = transform.rotation;
                    }
                }
            }
            if (togglePlayer)
            {
                player.transform.position = transform.position + transform.up * 15;
                player.transform.rotation = transform.rotation;
            }
            lastAngles = transform.localEulerAngles;
        
    }
}
