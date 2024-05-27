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
    private GameObject m_playerMovement;

    [SerializeField]
    private GameObject m_menuController;

    private void Start(){
        var minutes = Mathf.FloorToInt((float)m_remainTime / 60);
        var seconds = Mathf.FloorToInt((float)m_remainTime % 60);
        m_timerText.text = string.Format($"{minutes:00}:{seconds:00}");
    }

    private void Update()
    {

        if(m_remainTime > 0){
            m_remainTime -= Time.deltaTime;
        }
        else {
            m_remainTime = 0;
            m_timerText.color = Color.red;

            var menuController = m_menuController.GetComponent<MenuController>();

            menuController.ActiveGameOverMenu();
            menuController.DisablePauseButton();

            m_playerMovement.GetComponent<PlayerMovement>().SignalStop();

            menuController.DisableRemainTime();

        }
        
        var minutes = Mathf.FloorToInt((float)m_remainTime / 60);
        var seconds = Mathf.FloorToInt((float)m_remainTime % 60);
        
        m_timerText.text = string.Format($"{minutes:00}:{seconds:00}");
    }
}
