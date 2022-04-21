using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heavyrecoil : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Application.OpenURL("https://store.steampowered.com/app/933030/Heavy_Recoil/");
        Application.Quit();
    }
}
