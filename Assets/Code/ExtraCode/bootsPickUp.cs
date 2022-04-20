using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bootsPickUp : MonoBehaviour {
    public float SpeedMultiplier = 1;
	// Use this for initialization
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Player"){
            /*
			GameObject.Find("Player").GetComponent<Movement>().SuperBoots = true;	
			
            GameObject.Find("AbilityGUI").GetComponent<TextMeshProUGUI>().text = "You got the super boots! You can now double jump";
    */
            GameObject.Find("Player").GetComponent<Movement>().speedBoost = 1.2f * SpeedMultiplier;
            Destroy(gameObject);
        }
	}
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
