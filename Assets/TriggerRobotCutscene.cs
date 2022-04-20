using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRobotCutscene : MonoBehaviour
{
    public Animator anim;
    public string animname;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>())
        {
            anim.Play(animname);
            Destroy(gameObject);
        }
    }
}
