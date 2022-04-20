using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeBullets : MonoBehaviour {
    public AnimationEvent evt;
    public GameObject lookAt;
    public float damageReduced;
    public GameObject ebullet;
    public TurretCode t;
    // Use this for initialization
    void Start () {
        evt.functionName = "EnemyFire";
    }
	public void EnemyFire()
    {
        if (t)
        {
            t.Fire();
        }
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().enabled = false;
            GetComponent<AudioSource>().enabled = true;
        }
        GameObject newBullet = Instantiate(ebullet);
        newBullet.transform.rotation = lookAt.transform.rotation;
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<enemyBullet2>().enabled = true;
        newBullet.GetComponent<enemyBullet2>().extraDamage -= damageReduced;
        Destroy(newBullet, 2);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
