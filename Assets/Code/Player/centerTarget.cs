using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerTarget : MonoBehaviour {
    public GameObject player;
    public GameObject bullet;
    public GameObject muzzle;
    public Camera fpsCam;
    private LineRenderer laserLine;
    public float weaponRange = 150f;
    public Transform gunEnd;
    public bool FireNow;
    public int gunDamage;
    public float hitForce;
    public Vector3 hitPoint;
    public GameObject bulletwall;


}
