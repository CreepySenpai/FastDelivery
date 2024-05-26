using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            m_gameWinMenu.SetActive(true);
        }
    }

    // public void AddScore(int score){
    //     m_scoreManager.GetComponent<ScoreManager>().AddScore(score);
    // }

    public void ResetScore() => Score = 0;
}