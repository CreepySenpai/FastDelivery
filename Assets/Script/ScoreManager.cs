using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField]
    private GameObject m_scoreText;

    public void AddScore(int score) {
        m_currentScore += score;

        m_currentScore = Math.Clamp(m_currentScore, 0, m_totalScore);

        m_currentScoreImage.fillAmount = (float)m_currentScore / (float)m_totalScore;

        m_scoreText.GetComponent<TextMeshProUGUI>().text = $"{m_currentScore}/{m_totalScore}";
    }

    public void SetTotalScore(int totalScore) => m_totalScore = totalScore;

    public void ResetScore() => m_currentScore = 0;
    
    public int GetCurrentScore() => m_currentScore;
    public int GetTotalScore() => m_totalScore;
}
