using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour {

    GameObject camFollow;

    public float offSetCamY;
    public float offSetCamZ;

    public float smoothTime;

    Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {

        camFollow = GameObject.FindGameObjectWithTag("camFollow");
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 moveToo = camFollow.transform.TransformPoint(new Vector3(0, offSetCamY, offSetCamZ));
        transform.position = Vector3.SmoothDamp(transform.position, moveToo, ref velocity, smoothTime);

    }
}
