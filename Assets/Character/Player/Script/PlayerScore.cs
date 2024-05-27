using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    // TODO(Creepy): Move to level manager
    public long LevelScore;

    [SerializeField]
    private GameObject m_scoreManager;

    [SerializeField]
    private GameObject m_menuController;

    void Update()
    {
        if(m_scoreManager.GetComponent<ScoreManager>().GetCurrentScore() > LevelScore){
            UnlockNewLevel();

            var menuController = m_menuController.GetComponent<MenuController>();
            menuController.DisableTimeCounter();
            menuController.ActiveWinMenu();
            // gameObject.SetActive(false);
        }

    }

    void UnlockNewLevel(){
        PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
        // if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedLevel")){
        //     PlayerPrefs.SetInt("ReachedLevel", SceneManager.GetActiveScene().buildIndex);
        //     PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
        //     PlayerPrefs.Save();
        // }
    }

    public void AddScore(int score){
        m_scoreManager.GetComponent<ScoreManager>().AddScore(score);
    }

    public void ResetScore() => m_scoreManager.GetComponent<ScoreManager>().ResetScore();

    public int GetScore() => m_scoreManager.GetComponent<ScoreManager>().GetCurrentScore();
}