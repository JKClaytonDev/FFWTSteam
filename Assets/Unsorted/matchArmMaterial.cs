using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchArmMaterial : MonoBehaviour
{

        public SkinnedMeshRenderer mat;

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().material = mat.material;
    }
}
