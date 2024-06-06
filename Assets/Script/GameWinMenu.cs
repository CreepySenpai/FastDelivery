using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameWinMenu : MonoBehaviour
{
    public void Home()
    {
        SceneManager.LoadScene("Main_Menu");
        Time.timeScale = 1;
    }

    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NextLevel(){
        MenuController.GetInstance().ActiveLevelMenu();
    }
}