using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class monoChrome : MonoBehaviour
{
   GameObject[] used;
    float lastChecked;
    public Shader old;
    public Shader middle;
    public Texture plain;
    public Material matt;
    public Shader RedShader;
    // Start is called before the first frame update
    void Start()
    {
        monoGameObjects();
        lastChecked = -1;
     }
    void Update()
    {
        if (lastChecked < Time.realtimeSinceStartup)
        {
            
            lastChecked = Mathf.Abs(lastChecked);
            lastChecked += 1;
        }
    }
    public void monoGameObjects()
    {
        Debug.Log("Rerender");
        GameObject[] imStuff = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
        foreach (GameObject item in imStuff)
        {
            if (item.name.Equals("RightArm"))
                Debug.Log("Found Arm");
            if (item.GetComponent<Renderer>() != null)
            {
                item.GetComponent<Renderer>().materials = blackwhites(item.GetComponent<Renderer>().materials);
            }
            if (item.GetComponent<MeshRenderer>() != null)
            {
                item.GetComponent<MeshRenderer>().materials = blackwhites(item.GetComponent<MeshRenderer>().materials);
            }
            if (item.GetComponent<SkinnedMeshRenderer>() != null)
            {
                item.GetComponent<SkinnedMeshRenderer>().materials = blackwhites(item.GetComponent<SkinnedMeshRenderer>().materials);
            }
        }
    }

    public Material[] blackwhites(Material[] matz)
    {
        //ren.material.shader = RedShader;
        for (int i = 0; i<matz.Length; i++)
        {
            Material mat = matz[i];
            if (mat != null)
            {
                if (mat.shader == old)
                {
                    Color baseColor = mat.color;
                    Color c;
                    if (mat.HasProperty("_BaseColor"))
                    {
                        c = mat.GetColor("_BaseColor");
                    }
                    else if (mat.HasProperty("_Color"))
                    {
                        c = mat.GetColor("_Color");
                    }
                    else
                        c = mat.color;
                    Color d = mat.color;
                    Debug.Log("D1 - " + mat.color);
                    Texture t = null;
                    if (mat.GetTexture("_BaseColorMap"))
                        t = mat.GetTexture("_BaseColorMap");
                    /*
                    float grey = (d.r + d.g + d.b);
                    d.g = grey;
                    d.b = d.g;
                    d.r = d.g;
                    */
                    //mat.shader = middle;
                    mat.color = d;
                    //mat.SetColor("_UnlitColor", d);
                    mat.shader = RedShader;
                    mat.color = Color.red;
                    // mat.SetTexture("_UnlitColorMap", t);
                    /*
                    if (mat.HasProperty("_EmissiveColor")){
                        if (mat.GetColor("_EmissiveColor") != null) {
                            Color f = mat.GetColor("_EmissiveColor");
                            f.g = 0;
                            f.b = 0;
                            f.r = 0;
                            f.a = 0;
                            mat.SetColor("_EmissiveColor", f);
                        }
                    }
                    */
                    mat.SetColor("BaseColor", d);
                    mat.SetColor("_UnlitColor", d);
                    Debug.Log("D2 - " + mat.GetColor("_UnlitColor"));
                     
                    mat.name = "Jeff";
                    matz[i] = mat;
                }
            }
        }
        return matz;
    }
}
