using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private float speed = 10.0f;
    private Transform target;
    private int wavepointIndex = 0;
    private bool increasingIndex = true;

	// Use this for initialization
	void Start () {
        target = Enemy1Waypoints.waypoints[0];
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWayPoint();
        }
        //Debug.Log("position: " + target.position + "index: " + wavepointIndex);
	}

    void GetNextWayPoint()
    {
        if (increasingIndex)
        {
            wavepointIndex++;
            if (wavepointIndex >= Enemy1Waypoints.waypoints.Length - 1)
            {
                increasingIndex = false;
            }
        }
        else
        {
            wavepointIndex--;
            if (wavepointIndex <= 0)
            {
                increasingIndex = true;
            }
        }
        

        target = Enemy1Waypoints.waypoints[wavepointIndex];
    }
}
