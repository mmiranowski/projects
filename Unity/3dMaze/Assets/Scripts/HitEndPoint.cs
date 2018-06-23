using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitEndPoint : MonoBehaviour {

    public GameObject endMenu;
    public GameObject inGameCanvas;
    public GameObject TimerObject;
    private Timer TimerAccess;
    private int activeScene;
   
    public static bool Level1Completed;
    
    // Use this for initialization
    void Start () {
        TimerAccess = TimerObject.GetComponent<Timer>();
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "END")
        {
            TimerAccess.setToPause = true;
            inGameCanvas.SetActive(false);
            endMenu.SetActive(true);
        }
    }

}
