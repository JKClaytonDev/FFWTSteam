using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCutscene : MonoBehaviour
{
    public Animator roboAnim;
    public GameObject player;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            roboAnim.enabled = true;
            roboAnim.Play("hack");
            Destroy(player);
        }
    }
}
