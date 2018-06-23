using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CanvasButtons : MonoBehaviour {

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        //load next scene -> next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(1);
    }

    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LevelSelectMenu()
    {
       // SceneManager.LoadScene(0);

    }
}

