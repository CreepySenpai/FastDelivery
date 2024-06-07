using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private ScoreManager m_scoreManager;

    [SerializeField]
    private AudioController m_audioController;

    private bool m_isUnlocked = false;

    void Update()
    {
        if(!m_isUnlocked){
            if(m_scoreManager.GetCurrentScore() >= m_scoreManager.GetTotalScore()){
                UnlockNewLevel();

                MenuController.GetInstance().DisableTimeCounter();
                MenuController.GetInstance().DisablePauseButton();
                
                MenuController.GetInstance().ActiveWinMenu();
                GameAssetsController.GetInstance().PlayerBackPack.SetActive(false);
                GameAssetsController.GetInstance().ScoreBar.SetActive(false);
                
                m_isUnlocked = true;
            }
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
        m_scoreManager.AddScore(score);
        if(score < 0) {
            m_audioController.PlayMusic("SubScore");
        }
        else {
            m_audioController.PlayMusic("AddScore");
        }
        ScorePopup.Create(transform.position, score);
    }

    public void ResetScore() => m_scoreManager.ResetScore();

    public int GetScore() => m_scoreManager.GetCurrentScore();
}