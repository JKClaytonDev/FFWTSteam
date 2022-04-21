using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpInfo : MonoBehaviour
{
    public Movement playerMovement;
    public boxColliders colliders;
    public Text text1;
    public Text text2;
    public Text text3;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        text1.text = "Jumps " + playerMovement.jumps;
        text2.text = "OnGround " + colliders.OnGround;
        text3.text = "Space Pressed" + Input.GetKey(KeyCode.Space);
    }
}
