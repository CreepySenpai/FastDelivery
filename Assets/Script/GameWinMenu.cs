using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameWinMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject m_menuController;

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NextLevel(){
        m_menuController.GetComponent<MenuController>().ActiveLevelMenu();
    }
}