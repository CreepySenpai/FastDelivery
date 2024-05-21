using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_timerText;
    
    [SerializeField]
    private double m_remainTime;

    [SerializeField]
    private GameObject m_gameOverMenu;

    [SerializeField]
    private GameObject m_pauseButton;

    [SerializeField]
    private GameObject m_playerMovement;

    private bool m_isPlaying = false;

    private void Start(){
        var minutes = Mathf.FloorToInt((float)m_remainTime / 60);
        var seconds = Mathf.FloorToInt((float)m_remainTime % 60);
        m_timerText.text = string.Format($"{minutes:00}:{seconds:00}");
    }

    private void Update()
    {
        if(!m_isPlaying) return;

        if(m_remainTime > 0){
            m_remainTime -= Time.deltaTime;
        }
        else {
            m_remainTime = 0;
            m_timerText.color = Color.red;
            m_gameOverMenu.SetActive(true);
            m_pauseButton.SetActive(false);
            m_playerMovement.GetComponent<PlayerMovement>().SignalStop();
        }
        
        var minutes = Mathf.FloorToInt((float)m_remainTime / 60);
        var seconds = Mathf.FloorToInt((float)m_remainTime % 60);
        
        m_timerText.text = string.Format($"{minutes:00}:{seconds:00}");
    }

    public void SignalActive() => m_isPlaying = true;
    public void SignalStop() => m_isPlaying = false;
}
