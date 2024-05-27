using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    public long Score;

    // TODO(Creepy): Move to level manager
    public long LevelScore;

    [SerializeField]
    private GameObject m_gameWinMenu;

    // [SerializeField]
    // private GameObject m_scoreManager;

    void Update()
    {
        if(Score >= LevelScore) {
            UnlockNewLevel();
            m_gameWinMenu.SetActive(true);
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

    // public void AddScore(int score){
    //     m_scoreManager.GetComponent<ScoreManager>().AddScore(score);
    // }

    public void ResetScore() => Score = 0;
}