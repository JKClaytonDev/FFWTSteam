using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSway : MonoBehaviour {
	private Vector3 PlayerPos;
	void Start(){
		PlayerPos = GameObject.Find("Player").transform.position;
	}
	void Update(){
	if (GameObject.Find("Player").transform.position != PlayerPos && GameObject.Find("PlayerCollider").GetComponent<boxColliders>().OnGround){
	PlayerPos = GameObject.Find("Player").transform.position;
	GetComponent<Animator>().SetBool("isMoving", true);
	}
	else
		GetComponent<Animator>().SetBool("isMoving", false);
	}
}
