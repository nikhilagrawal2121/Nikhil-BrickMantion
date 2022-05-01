using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPause = false;
    public GameObject PauseMenuUIa; //Pause menu UI
    public void Update()
    {
        //if (Input.GetMouseButtonDown(0)) //When we press  
        //    //if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //    if(GameIsPause)//When we press escape key if game is already pasue
        //    {
        //        Resume();  //resume the game

        //    }
        //    else //if not
        //    {
        //        Pause(); //Pause the game
        //    }
        //}
    }

    public void PauseButton()
    {
        PauseMenuUIa.SetActive(true);
        if (GameIsPause)//When we press escape key if game is already pasue
        {
            Resume();  //resume the game

        }
        else //if not
        {
            Pause1(); //Pause the game
        }

    }


    public void Resume()
    {
        PauseMenuUIa.SetActive(false); //Pause menu disabled
        Time.timeScale = 1f; // Used to normal the game
        GameIsPause = false; //Game is resume
    }
    void Pause1()
    {
        PauseMenuUIa.SetActive(true); //Pause menu enabled
        Time.timeScale = 0f; // Used to freez the game
        GameIsPause = true; //Game is pause 
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); //Load the scene we want

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
