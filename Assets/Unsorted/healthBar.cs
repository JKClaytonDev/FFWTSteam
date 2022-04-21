using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    public Text healthText;


    // Update is called once per frame
    void Update()
    {
        int health = int.Parse(healthText.text);
        Vector3 scale = transform.localScale;
        scale.x = 15 * health / 100;
        transform.localScale = scale;
    }
}
