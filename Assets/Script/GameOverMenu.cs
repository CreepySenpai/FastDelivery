using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private LevelLoader m_levelLoader;
    public void Home()
    {
        // GameAssetsController.GetInstance().LoadingScene.SetActive(false);
        m_levelLoader.LoadLevel("Main_Menu");
        Time.timeScale = 1;
    }

    public void PlayAgain(){
        // GameAssetsController.GetInstance().LoadingScene.SetActive(false);

        m_levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void SelectLevel(){
        MenuController.GetInstance().ActiveLevelMenu();
    }
}
