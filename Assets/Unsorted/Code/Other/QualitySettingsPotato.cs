using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QualitySettingsPotato : MonoBehaviour {
    public int qualityLevel;
    Animator m_Animator;
    string m_ClipName;
    AnimatorClipInfo[] m_AnimatorClipInfo;
    public Camera cameraP;
    float m_CurrentClipLength;

    void Update()
    {
        qualityLevel = QualitySettings.GetQualityLevel();
        //GetComponent<VolumeProfile>().enabled = (qualityLevel != 0);
    }

   /*
    void Start()
    {
     
        if (qualityLevel == 0)
        {
            if (GameObject.Find("PlayerCamera") != null)
            {
                GameObject.Find("PlayerCamera").GetComponent<Camera>().allowHDR = false;
                GameObject.Find("PlayerCamera").GetComponent<Camera>().allowMSAA = false;
            }
            else
            {
                cameraP.allowHDR = false;
                cameraP.allowMSAA = false;
            }
            QualitySettings.masterTextureLimit = 10;
            GameObject[] imStuff = FindObjectsOfType(typeof(GameObject)) as GameObject[];

            foreach (GameObject item in imStuff)
            {
                if (item != gameObject)
                {
                    if (item.GetComponent<Light>() != null)
                    {
                        item.GetComponent<Light>().enabled = false;
                    }
                    if (item.GetComponent<ParticleSystem>() != null)
                    {
                        Destroy(item.GetComponent<ParticleSystem>());
                    }
                    if (item.GetComponent<ReflectionProbe>() != null)
                    {
                        Destroy(item.GetComponent<ReflectionProbe>());
                    }
                    if (item.GetComponent<Renderer>() != null)
                    {
                        Material mat = item.GetComponent<Renderer>().material;
                        Material mat2 = mat;
                        if (!mat.name.Contains("Sky"))
                        {
                            if (mat.mainTexture != null)
                                mat2.shader = Shader.Find("Unlit/Texture");
                            else if (mat.color != null)
                                mat2.shader = Shader.Find("Unlit/Color");
                            mat.mainTextureScale = new Vector2(0.01f, 0.01f);
                        }
                    }
                    if (item.GetComponent<MeshRenderer>() != null)
                    {
                        Material mat = item.GetComponent<MeshRenderer>().material;
                        Material mat2 = mat;
                        if (!mat.name.Contains("Sky"))
                        {
                            if (mat.mainTexture != null)
                                mat2.shader = Shader.Find("Unlit/Texture");
                            else if (mat.color != null)
                                mat2.shader = Shader.Find("Unlit/Color");
                            mat.mainTextureScale = new Vector2(0.01f, 0.01f);
                        }
                    }
                    if (item.GetComponent<SkinnedMeshRenderer>() != null)
                    {
                        Material mat = item.GetComponent<SkinnedMeshRenderer>().material;
                        Material mat2 = mat;
                        if (!mat.name.Contains("Sky"))
                        {
                            if (mat.mainTexture != null)
                                mat2.shader = Shader.Find("Unlit/Texture");
                            else if (mat.color != null)
                                mat2.shader = Shader.Find("Unlit/Color");
                            mat.mainTextureScale = new Vector2(0.01f, 0.01f);
                        }
                    }
                }
            }
            Destroy(gameObject);
        }
        if (qualityLevel == 0)
        {
            Destroy(gameObject);
        }
    }
*/
}
