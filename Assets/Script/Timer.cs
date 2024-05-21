using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_timerText;
    
    [SerializeField]
    private double m_remainTime;

    [SerializeField]
    private GameObject m_playerMovement;

    [SerializeField]
    private GameObject m_remainTimeCounter;

    void Update()
    {
        if(m_remainTime > 0){
            m_remainTime -= Time.deltaTime;
        }
        else {
            m_remainTime = 0;
            m_timerText.color = Color.red;
            m_remainTimeCounter.GetComponent<TimeCounter>().SignalActive();
            m_playerMovement.GetComponent<PlayerMovement>().SignalActive();
        }
        
        var seconds = Mathf.FloorToInt((float)m_remainTime % 60);

        m_timerText.text = seconds switch {
            > 4 => "Start",
            4 => "3",
            3 => "2",
            2 => "1",
            1 => "Ready",
            _ => ""
        };
    }
}
