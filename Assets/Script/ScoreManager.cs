using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Image m_currentScoreImage;
    
    [SerializeField]
    private int m_totalScore = 0;

    [SerializeField]
    private int m_currentScore = 0;

    public void AddScore(int score) {
        m_currentScore += score;

        m_currentScore = Math.Clamp(m_currentScore, 0, m_totalScore);

        m_currentScoreImage.fillAmount = (float)m_currentScore / (float)m_totalScore;
    }

    public void SetTotalScore(int totalScore) => m_totalScore = totalScore;
}
