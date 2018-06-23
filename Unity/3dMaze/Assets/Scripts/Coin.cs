using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float startAngle = 0.0f;
    private float spinSpeed = 100.0f;

    // Use this for initialization
    void Start()
    {
        startAngle = Random.value * 90;
        transform.Rotate(Vector3.forward, startAngle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(gameObject.name + " was triggerd by " + collider.gameObject.name);
        if (collider.gameObject.name == "Player")
        {
            //Debug.Log("TRUE");
            Destroy(gameObject);
        }
    }
}
