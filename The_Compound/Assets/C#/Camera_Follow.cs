﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

    GameObject player;
    
	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 playerPos = player.transform.position;
        transform.position = playerPos;


	}
}
