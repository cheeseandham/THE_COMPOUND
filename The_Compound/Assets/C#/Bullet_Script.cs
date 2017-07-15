using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour {

    Rigidbody rb;

    public float bulletSpeed;
    public float zeroVeloTimer;
    float veloTimer;

    public float removebulletTimer;
    float removeTimer;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();

        veloTimer = zeroVeloTimer;
        removeTimer = removebulletTimer;
	}

    void Update () {

        rb.AddForce(transform.forward * bulletSpeed * Time.deltaTime, ForceMode.VelocityChange);

        Vector3 velo = rb.velocity;
        
        if (velo == Vector3.zero)
        {
            veloTimer -= 1 * Time.deltaTime;
            if (veloTimer < 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            veloTimer = zeroVeloTimer;

            removeTimer -= 1 * Time.deltaTime;
            if (removeTimer < 0)
            {
                Destroy(gameObject);
            }
        }
	}
}
