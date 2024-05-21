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

    void Update()
    {
        if(m_remainTime > 0){
            m_remainTime -= Time.deltaTime;
        }
        else {
            m_remainTime = 0;
            m_timerText.color = Color.red;
        }
        
        var minutes = Mathf.FloorToInt((float)m_remainTime / 60);
        var seconds = Mathf.FloorToInt((float)m_remainTime % 60);
        
        m_timerText.text = string.Format($"{minutes:00} : {seconds:00}");
    }
}
