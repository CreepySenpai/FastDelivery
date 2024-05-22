using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    // [SerializeField]
    // private GameObject m_gameOverPanel;

    [SerializeField]
    private GameObject m_optionPanel;

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void PlayAgain(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Option(){
        m_optionPanel.SetActive(true);
    }
}
