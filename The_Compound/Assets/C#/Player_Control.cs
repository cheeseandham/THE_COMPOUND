using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {

    Rigidbody rb;
    public Rigidbody myBullet;

    public float movementSpeed;
    public float rotSpeed;
    public float firedDelay;

    public bool underControl = true;

    Transform bulletSpawn;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        bulletSpawn = transform.GetChild(0).transform;
    }

    float fireTimer;

    void Update () {

        //movement
        if (underControl)
        {
            Player_Movement();
            Player_Rotation();
        }

        //fire
        if (Input.GetAxis("Fire") > 0.5)
        {
            fireTimer -= 1 * Time.deltaTime;
            if (fireTimer < 0)
            {
                Rigidbody newBullet = (Rigidbody)Instantiate(myBullet, bulletSpawn.position, bulletSpawn.rotation);
                fireTimer = firedDelay;
            }
        }
    }

    void Player_Movement()
    {
        Vector3 playerPos = transform.localPosition;
        
        playerPos -= Vector3.forward * Input.GetAxis("VerticalL") * movementSpeed * Time.deltaTime;
        playerPos -= Vector3.left * Input.GetAxis("HorizontalL") * movementSpeed * Time.deltaTime;

        rb.MovePosition(playerPos);
    }

    void Player_Rotation()
    {
        float step = rotSpeed * Time.deltaTime;
        Vector3 playerRot = transform.localPosition;

        playerRot -= Vector3.forward * Input.GetAxis("HorizontalR");
        playerRot -= Vector3.left * Input.GetAxis("VerticalR");
        
        Vector3 targetDir = playerRot - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);

        transform.rotation = Quaternion.LookRotation(newDir);

    }
}
