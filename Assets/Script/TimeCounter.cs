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
    private LevelInfo m_levelInfo;

    [SerializeField]
    private GameObject m_playerMovement;

    private void Start(){
        var minutes = Mathf.FloorToInt((float)m_levelInfo.RemainTime / 60);
        var seconds = Mathf.FloorToInt((float)m_levelInfo.RemainTime % 60);
        m_timerText.text = string.Format($"{minutes:00}:{seconds:00}");
    }

    private void Update()
    {

        if(m_levelInfo.RemainTime > 0){
            m_levelInfo.RemainTime -= Time.deltaTime;
        }
        else {
            AudioController.GetInstance().StopMusic("GameBattle");
            AudioController.GetInstance().PlayMusic("YouLoose");

            m_levelInfo.RemainTime = 0;
            m_timerText.color = Color.red;

            MenuController.GetInstance().ActiveGameOverMenu();
            MenuController.GetInstance().DisablePauseButton();

            m_playerMovement.GetComponent<PlayerMovement>().SignalStop();

            MenuController.GetInstance().DisableRemainTime();

            GameAssetsController.GetInstance().PlayerBackPack.SetActive(false);
            GameAssetsController.GetInstance().ScoreBar.SetActive(false);
        }
        
        var minutes = Mathf.FloorToInt((float)m_levelInfo.RemainTime / 60);
        var seconds = Mathf.FloorToInt((float)m_levelInfo.RemainTime % 60);
        
        m_timerText.text = string.Format($"{minutes:00}:{seconds:00}");
    }
}
