using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class weaponNames : MonoBehaviour
{
    public string[] names;
    public Text[] text;
    public Text mainWeapon;
    public int offset;
    double checkTime;
    public string[] s;
    Movement player;
    Animator playerAnim;
    public int weapon;
    int lastwep;
    bool mode = false;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = text[0].GetComponent<RectTransform>().position;
        checkTime = 0;
        player = FindObjectOfType<Movement>();
        playerAnim = player.gameObject.GetComponent<Animator>();
        for (int i = 0; i<names.Length; i++)
        {
            if (names[i] == "")
                player.equippedWeapons[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup > checkTime)
        {
            foreach (Text t in text)
                t.gameObject.GetComponent<RectTransform>().position += Vector3.right*12;
        }

        mainWeapon.text = "Weapon:  " + names[playerAnim.GetInteger("WeaponNum") - 1];
        if (mode)
        {
            s = new string[0];

            for (int i = 0; i < player.equippedWeapons.Length && i < names.Length; i++)
            {
                if (player.equippedWeapons[i])
                {

                    string[] s2 = new string[s.Length + 1];
                    for (int f = 0; f < s.Length; f++)
                        s2[f] = s[f];

                    s2[s.Length] = (names[i-1]);
                    s = s2;
                }
            }

            Debug.Log("GOT HERE");

            int num = playerAnim.GetInteger("WeaponNum") - 1;
            
            for (int i = -2; i < 3; i++)
            {
                if (num + i >= 0 && s.Length > num + i )
                    text[i + 2].text = s[num + i];
                else
                    text[i + 2].text = " " + num + i;
            }

        }
        else
        {
            int num = playerAnim.GetInteger("WeaponNum") - 1;
            if (weapon != num)
            {
                checkTime = Time.realtimeSinceStartup + 2;
                foreach (Text t in text)
                {
                    Vector3 pos = t.gameObject.GetComponent<RectTransform>().position;
                    pos.x = startPos.x;
                    t.gameObject.GetComponent<RectTransform>().position = pos;
                }
                
            }

            weapon = num;
            
            for (int i = -2; i < 3; i++)
            {
                if (num + i >= 0 &&  num + i < names.Length && player.equippedWeapons[num+i+1+offset])
                    text[i + 2].text = names[num + i];
                else
                    text[i + 2].text = " ";
            }
           
           
            
        }
    }
}
