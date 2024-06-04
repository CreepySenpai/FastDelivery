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

    void Start(){
        m_remainTimeCounter.SetActive(false);
    }

    void Update()
    {
        if(m_remainTime > 0){
            m_remainTime -= Time.deltaTime;
        }
        else {
            m_remainTimeCounter.SetActive(true);
            MenuController.GetInstance().ActivePauseButton();
            m_playerMovement.GetComponent<PlayerMovement>().SignalActive();
            
            m_remainTime = 0;
            gameObject.SetActive(false);
        }
        
        var seconds = Mathf.FloorToInt((float)m_remainTime % 60);

        m_timerText.text = seconds switch {
            > 4 => "Ready",
            4 => "3",
            3 => "2",
            2 => "1",
            1 => "Start",
            _ => ""
        };
    }
}
