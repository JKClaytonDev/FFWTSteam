using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class boxColliders : MonoBehaviour {
    private BoxCollider _bc;    public AudioSource source;
    public BoxCollider main;    public GameObject player;
    public LayerMask ignore;    public AudioClip[] landClips;
    public bool OnGround;   private Movement playerMovement;
    private float ogScaley;
    public LayerMask mask;  public AudioClip[] pickUpClips;
    private float lastTouched;  public AudioSource pickUpPlayer;
    bool touchingGround;    public bool PTouchingGround;
    Ray ray; string scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name == "Ground1")
        {
            
            for (int i = 0; i<15; i++)
            {
                PlayerPrefs.SetInt("PickedUp" + i, 1);
                
            }
            PlayerPrefs.Save();
        }
        PTouchingGround = false;
        player = transform.parent.gameObject;
        lastTouched = Time.realtimeSinceStartup;
        if (!player)
        player = GameObject.Find("Player");
        ray = new Ray(); 
        ogScaley = transform.localScale.y;
        ray.direction = Vector3.down;
        playerMovement = player.GetComponent<Movement>();
    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.layer == mask)
        player.GetComponent<Movement>().jumps = 0;
        if (other.GetComponent<pickUpGun>())
        {
            

            pickUpPlayer.PlayOneShot(pickUpClips[Random.Range(0, pickUpClips.Length - 1)]);
            int weaponNum = other.GetComponent<pickUpGun>().weaponNum;
            other.transform.position = new Vector3(900, 900, 900);
            player.GetComponent<Movement>().weaponAmmo[weaponNum - 1] = player.GetComponent<Movement>().PlayerOriginalAmmo[weaponNum - 1];
            if (!player.GetComponent<Movement>().equippedWeapons[weaponNum])
            {
                //if ((PlayerPrefs.GetInt("PickedUp") != 1))
                {
                    
                //GameObject.Find("AbilityGUI").GetComponent<TextMeshProUGUI>().text = message;
                PlayerPrefs.SetInt(weaponNum + "", 1);
                player.GetComponent<Movement>().equippedWeapons[weaponNum] = true;
                player.GetComponent<Movement>().nextWeapon = weaponNum;
                player.GetComponent<Movement>().animController.SetInteger("WeaponNum", weaponNum);
                    player.GetComponent<Movement>().tryEquipWeapon();
                    Animator animController = player.GetComponent<Animator>();
                    if (scene == "Ground1")
                    {
                        if (animController.GetInteger("WeaponNum") == 3)
                            animController.Play("uziVidEquip");
                        else if (animController.GetInteger("WeaponNum") == 1)
                            animController.Play("flipGat");
                        else if (animController.GetInteger("WeaponNum") == 10)
                            animController.Play("chaingunInpect");
                        else if (animController.GetInteger("WeaponNum") == 6)
                        {
                            if (UnityEngine.Random.Range(1, 10) != 6)
                                animController.Play("InspectShotgun");
                            else
                                animController.Play("RareInspect");
                        }
                        else if (animController.GetInteger("WeaponNum") == 7)
                        {
                            animController.Play("ARInspect");
                        }
                        else if (animController.GetInteger("WeaponNum") == 4)
                        {
                            if (UnityEngine.Random.Range(1, 2) == 3)
                                animController.Play("csgoPistolInspect");
                            else
                                animController.Play("csgodefaultInspect");
                        }
                        else if (animController.GetInteger("WeaponNum") == 9)
                        {
                            animController.Play("DoubleBarrelFlip");
                        }
                        else
                            animController.Play("weaponInspect", 4);
                    }
                PlayerPrefs.SetInt("PickedUp" + animController.GetInteger("WeaponNum"), 1);
                PlayerPrefs.Save();
            }
            }
            Destroy(other);

            
        }
    }
        void Update()
    {
        Ray r = new Ray(transform.position, Vector3Int.down);
        float distance = (((GetComponent<BoxCollider>().bounds.extents.y - GetComponent<BoxCollider>().center.y))) + 3f;
        if (touchingGround)
        {
            if (!Physics.Raycast(transform.position, Vector3Int.down, distance, mask))
            {
                touchingGround = false;
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, Vector3Int.down, distance, mask))
            {
                touchingGround = true;
                playerMovement.jumps = 0;
                source.PlayOneShot(landClips[Random.Range(0, landClips.Length - 1)]);
            }
        }
        if (!player)
        {
            player = FindObjectOfType<Movement>().gameObject;
            playerMovement = FindObjectOfType<Movement>();
        }
            if (!playerMovement)
            playerMovement = player.GetComponent<Movement>();
        

        
    }
   
}
