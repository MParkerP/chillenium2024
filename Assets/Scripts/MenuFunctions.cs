using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{

    bool isPaused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }

    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseMenu()
    {
        if(!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            GetComponent<Canvas>().enabled = true;
        }else{
            Time.timeScale = 1;
            isPaused = false;
            GetComponent<Canvas>().enabled = false;
        }
        

    }

    public void resumeButton(){
        PauseMenu();
    }

    public void mainMenuButton(){
        Time.timeScale = 1;
        isPaused = false;
        ChangeScene(0);
    }
}
