using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDangerZone : MonoBehaviour {

    private bool inDangerZone = false;
    private bool enemyClose = false;

    public GameObject DangerCanvas;

    public GameObject EnemyObject;
    private EnemyMovement enemyMovementAccess;

    private Vector3 currentPos;
    private Vector3 enemyPos;
    public Vector3 deltaPos;

    private void Start()
    {
        enemyMovementAccess = EnemyObject.GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        currentPos = transform.position;
        enemyPos = enemyMovementAccess.transform.position;
        deltaPos = enemyPos - currentPos;

        if (inDangerZone /*&& Vector3.Magnitude(deltaPos)<10*/)
        {

            DangerCanvas.SetActive(true);
            //Debug.Log(Vector3.Magnitude(deltaPos));
        }
        else
        {
            enemyClose = false;
            DangerCanvas.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        //Debug.Log(gameObject.name + " was triggerd by " + collider.name);
        if (collision.transform.root.gameObject.name == "DangerZone")
        {
            DangerCanvas.SetActive(true);
            inDangerZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.gameObject.name == "DangerZone")
        {
            inDangerZone = false;
            DangerCanvas.SetActive(false);
        }
    }
}
