using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerRobot : MonoBehaviour
{
    public Animator anim;
    Vector3 lastAngle;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -100)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        rb.velocity = transform.forward * Input.GetAxis("Vertical") * 50 + Vector3.up * rb.velocity.y;
        transform.localEulerAngles = lastAngle + new Vector3(0, 50 * (Input.GetAxis("Mouse X")+ Input.GetAxis("Horizontal")*3) * Time.deltaTime, 0);
        lastAngle = transform.localEulerAngles;
        anim.SetBool("Walking", Input.GetAxis("Vertical") > 0);
        
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("Fire");
        }
    }
}
