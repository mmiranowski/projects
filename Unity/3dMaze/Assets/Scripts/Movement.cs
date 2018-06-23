

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;
    private float moveSpeed;
    public int state; // has to be public so cameraFollow can access it
    private float gravityFactor = -10.0f;
    //public bool enemyBehind;

    //touch screen varaible
    private float minSwipeDistY = 300.0f;
    private float minSwipeDistX = 300.0f;
    Vector2 startTouchPos;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        moveSpeed = 30.0f;
        state = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //swipeControl();
        keyboardControl();
        gravity();
        //move
        controller.Move(moveVector * Time.fixedDeltaTime);

    }

    void swipeControl()
    {
        moveSpeed = moveSpeed * 2;
        /***************************************************
        * directional state machine:
        *  state = 0 -> forward
        *  state = 1 -> left
        *  state = 2 -> backwards
        *  state = 3 -> right
        **********************************************/
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPos = touch.position;
                    break;

                case TouchPhase.Stationary:
                    if (state == 0) // move forward
                    {
                        moveVector.z = moveSpeed;
                    }
                    else if (state == 1) // move left
                    {
                        moveVector.x = -moveSpeed;
                    }
                    else if (state == 2) // move backward
                    {
                        moveVector.z = -moveSpeed;
                    }
                    else // (state == 3 ) move right
                    {
                        moveVector.x =  moveSpeed;
                    }
                    break;

                case TouchPhase.Ended:
                    moveVector = Vector3.zero;
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startTouchPos.y, 0)).magnitude;
                    if (swipeDistVertical > minSwipeDistY)
                    {
                        float swipeValue = Mathf.Sign(touch.position.y - startTouchPos.y);
                        if (swipeValue > 0) // up
                        {
                            // Do something
                            //Debug.Log("Swipe up");
                        }
                        else if (swipeValue < 0) // down
                        {
                            //Do something
                            //Debug.Log("Swipe down");
                        }
                    }
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startTouchPos.x, 0, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startTouchPos.x);
                        if (swipeValue > 0) // right
                        {
                            if (state > 0)
                            {
                                state--;
                            }
                            else
                            {
                                state = 3;
                            }
                            //Debug.Log("Swipe Right");
                        }
                        else if (swipeValue < 0) // left
                        {
                            if (state < 3)
                            {
                                state++;
                            }
                            else
                            {
                                state = 0;
                            }

                            //Debug.Log("Swipe Left");
                        }
                    }
                    break;

            }
            
        }
    }

    void keyboardControl()
    {
        /***************************************************
         * directional state machine:
         *  state = 0 -> forward
         *  state = 1 -> left
         *  state = 2 -> backwards
         *  state = 3 -> right
         **********************************************/
        moveVector = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Debug.Log("Left Arrow Pressed");
            if (state < 3)
            {
                state++;
            }
            else
            {
                state = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Debug.Log("Right Arrow Pressed");
            if (state > 0)
            {
                state--;
            }
            else
            {
                state = 3;
            }

        }
        // Debug.Log(state);

        //movement based on direction set by the state
        if (state == 0) // move forward
        {
            moveVector.z = Input.GetAxisRaw("Vertical") * moveSpeed;
        }
        else if (state == 1) // move left
        {
            moveVector.x = -Input.GetAxisRaw("Vertical") * moveSpeed;
        }
        else if (state == 2) // move backward
        {
            moveVector.z = -Input.GetAxisRaw("Vertical") * moveSpeed;
        }
        else // (state == 3 ) move right
        {
            moveVector.x = Input.GetAxisRaw("Vertical") * moveSpeed;
        }
        //Debug.Log(Input.GetAxisRaw("Vertical"));
    }

    void gravity()
    {
        //Debug.Log(controller.isGrounded);
        if (!controller.isGrounded)
        {
            moveVector.y = gravityFactor;
        }
        else
        {
            moveVector.y = 0.0f;
        }

    }
}
