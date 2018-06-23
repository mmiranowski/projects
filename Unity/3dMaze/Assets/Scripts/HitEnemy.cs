using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour {

    public GameObject killMenu;
    public GameObject inGameCanvas;
    public GameObject TimerObject;
    public GameObject DangerCanvasObject;
    private Timer TimerAccess;

    public GameObject EnemyObject;


    // Use this for initialization
    void Start()
    {
        TimerAccess = TimerObject.GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Enemy1")
        {
           // Debug.Log(other);
            TimerAccess.setToPause = true;
            killMenu.SetActive(true);
            inGameCanvas.SetActive(false);
            DangerCanvasObject.SetActive(false);
            Destroy(gameObject);
            Destroy(EnemyObject);
        }
    }
}
