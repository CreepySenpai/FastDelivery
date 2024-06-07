using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameWinMenu : MonoBehaviour
{
    [SerializeField]
    private LevelLoader m_levelLoader;

    public void Home()
    {
        m_levelLoader.LoadLevel("Main_Menu");
        Time.timeScale = 1;
    }

    public void PlayAgain(){
        m_levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NextLevel(){
        MenuController.GetInstance().ActiveLevelMenu();
    }
}