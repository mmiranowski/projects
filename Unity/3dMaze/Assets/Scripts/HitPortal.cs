using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPortal : MonoBehaviour {

    public Transform portal1Object;
    public Transform portal2Object;

    public Transform cam;

    private CharacterController controller;

    Vector3 portal1pos;
    Vector3 portal2pos;
	
	// Update is called once per frame
	void Update () {
        portal1pos = portal1Object.transform.position;
        portal2pos = portal2Object.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Portal1Object")
        {
            gameObject.transform.position = portal2pos;
            cam.transform.position = portal2pos;
        }
    }
}
