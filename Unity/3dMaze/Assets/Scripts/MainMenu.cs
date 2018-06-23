using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private int numScenes;

    public class LevelCompletedFlags{

        

        public static int LevelNumber;
        public static bool Completed;

        public LevelCompletedFlags(int lNum, bool comp)
        {
            LevelNumber = lNum;
            Completed = comp;
        }

        }

    private void Start()
    {
        numScenes = SceneManager.sceneCountInBuildSettings;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelSelectMenu()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
