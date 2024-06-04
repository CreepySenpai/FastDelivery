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

    void Update()
    {
        if(m_scoreManager.GetComponent<ScoreManager>().GetCurrentScore() > LevelScore){
            UnlockNewLevel();

            MenuController.GetInstance().DisableTimeCounter();
            MenuController.GetInstance().ActiveWinMenu();
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
        ScorePopup.Create(transform.position, score);
    }

    public void ResetScore() => m_scoreManager.GetComponent<ScoreManager>().ResetScore();

    public int GetScore() => m_scoreManager.GetComponent<ScoreManager>().GetCurrentScore();
}