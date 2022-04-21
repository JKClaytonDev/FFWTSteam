using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerHitBox : MonoBehaviour {
    public bool pushes;
    public float extraDamage;
	// Use this for initialization

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Movement>() || collision.gameObject.name.Equals("Player"))
        {
            collision.gameObject.GetComponent<Movement>().PlayerHealth-=20 + extraDamage;
        }
    }

}
