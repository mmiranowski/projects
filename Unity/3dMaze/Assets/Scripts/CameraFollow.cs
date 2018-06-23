using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    private Vector3 offsetPos;
    private Quaternion offsetRot;

    private float smoothRotSpeed = 0.125f;
    private float smoothPosSpeed = 0.125f;

    //access variable 'state' from Movement class
    public GameObject MovementObject;
    private Movement movementObjAccess;
    private int stateMovement;

    void Start()
    {
        // get component from Movement script
        movementObjAccess = MovementObject.GetComponent<Movement>();
    }

    // Update is called once per frame
    void LateUpdate () {
        //state variable from movement Script
        stateMovement = movementObjAccess.state;
        if (stateMovement == 0) //move forward
        {
            //rotate y = 0 
            offsetRot = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            //offsetPos (0,2,-7)
            offsetPos.x = 0.0f;
            offsetPos.y = 2.0f;
            offsetPos.z = -4.0f;
        }
        else if (stateMovement == 1) // move left
        {
            //rotate y = -90
            offsetRot = Quaternion.Euler(0.0f, -90.0f, 0.0f);
            //ofsetPos (7,2,0)
            offsetPos.x = 4.0f;
            offsetPos.y = 2.0f;
            offsetPos.z = 0.0f;
        }
        else if (stateMovement == 2) // move back
        {
            //rotate y = 180
            offsetRot = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            //offsetPos (0,2,7)
            offsetPos.x = 0.0f;
            offsetPos.y = 2.0f;
            offsetPos.z = 4.0f;
        }
        else // (stateMovement == 3) move right  
        {
            //rotate y = 90
            offsetRot = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            //offsetPos (-7,2,0)
            offsetPos.x = -4.0f;
            offsetPos.y = 2.0f;
            offsetPos.z = 0.0f;
        }

        // Perform a smooth transision if it is instructed to change direction

        //smoothing camera transision
        Quaternion smoothRotation = Quaternion.Lerp(transform.rotation, offsetRot, smoothRotSpeed);
        Vector3 desiredPosition = player.position + offsetPos;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothPosSpeed);

        //position and rotation of the camera
        transform.position = smoothPosition;
        transform.rotation = smoothRotation;

       


        //Debug.Log(stateMovement);

	}
}
