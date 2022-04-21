using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplodeBarrelCar : MonoBehaviour {
    public Material explodedMaterial;
    // Use this for initialization

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<bulletFlash>()) {
            if (!other.gameObject.GetComponent<Movement>() && !other.gameObject.GetComponent<boxColliders>())
            {
                tag = "dead";
                Debug.Log("HIT!!");

                SkinnedMeshRenderer[] mats = transform.GetComponentsInChildren<SkinnedMeshRenderer>();
                foreach (SkinnedMeshRenderer rend in mats)
                {
                    rend.material = explodedMaterial;
                }
                for (int i = 1; i < 3; i++)
                {
                    GameObject force = Instantiate(GameObject.Find("Player").GetComponent<Movement>().ForceExample);
                    force.SetActive(false);
                    force.SetActive(true);
                    force.transform.position = transform.position;
                    GetComponent<Rigidbody>().AddExplosionForce(0.8f, transform.position, 0.2f, 20.0F, ForceMode.Impulse);
                    force.transform.position += new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
                    Destroy(force, 3);
                }
                if (GetComponent<BoxCollider>() != null)
                    GetComponent<BoxCollider>().enabled = false;
                if (GetComponent<MeshCollider>() != null)
                    GetComponent<MeshCollider>().enabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<bulletFlash>())
        {
            if (!other.gameObject.GetComponent<Movement>() && !other.gameObject.GetComponent<boxColliders>())
        {
        tag = "dead";
            Debug.Log("HIT!!");

            SkinnedMeshRenderer[] mats = transform.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (SkinnedMeshRenderer rend in mats)
            {
                rend.material = explodedMaterial;
            }
        for (int i = 1; i < 3; i++)
        {
            GameObject force = Instantiate(GameObject.Find("Player").GetComponent<Movement>().ForceExample);
            force.SetActive(false);
            force.SetActive(true);
            force.transform.position = transform.position;
            GetComponent<Rigidbody>().AddExplosionForce(0.8f, transform.position, 0.2f, 20.0F, ForceMode.Impulse);
            force.transform.position += new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
            Destroy(force, 3);
        }
        if (GetComponent<BoxCollider>() != null)
            GetComponent<BoxCollider>().enabled = false;
        if (GetComponent<MeshCollider>() != null)
            GetComponent<MeshCollider>().enabled = false;
    }}
    }
    void Start()
    {
        this.gameObject.layer = 1;
        this.gameObject.tag = "Untagged";
        GetComponent<BulletExplodeBarrelCar>().enabled = false;
    }
}
