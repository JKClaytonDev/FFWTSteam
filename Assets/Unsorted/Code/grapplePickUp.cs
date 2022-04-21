using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grapplePickUp : MonoBehaviour
{
    
    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("Player").GetComponent<Movement>().GrappleHook = true;
            Destroy(gameObject);
            //GameObject.Find("AbilityGUI").GetComponent<TextMeshProUGUI>().text = "You got the grappling hook! Right click to use it";
        }
    }



}
