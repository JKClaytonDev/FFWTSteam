using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBullets : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!gameObject.name.Contains("(Clone)"))
        {
            name = "TEMPORARY";
            if (GameObject.Find("EnemyBullet") != null)
            {
                while (GameObject.Find("EnemyBullet") != null)
                {
                    Destroy(GameObject.Find("EnemyBullet"));
                }
            }
            name = "EnemyBullet";
        }

    }
	
	// Update is called once per frame
	void Update () {

	}
}
